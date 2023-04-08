using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InteractionManager : Singleton<InteractionManager>
{
    public delegate void InteractionEventHandler();
    public static event InteractionEventHandler OnTileInteraction;

    public delegate void CorrectPairInteractionEventHandler();
    public static event CorrectPairInteractionEventHandler OnCorrectInteraction;

    public delegate void GameOverEventHandler();
    public static event GameOverEventHandler OnAllTileIsDisabled;

    [SerializeField] private Tile[] _selectedTiles;// Selected Tiles
    [SerializeField] private Tile[,] _tiles;//Spawned Tiles
    private int _tileActive;
    private bool isGameOver;
    private void Start()
    {
        Tile.OnTileClicked += OnTileClickedEvent;
        _selectedTiles = new Tile[2];
        isGameOver = false;
    }

    public void Init(Tile[,] _tiles){
        this._tiles = _tiles;
        _tileActive = this._tiles.Length;
    }

    private void OnDestroy() {
        Tile.OnTileClicked -= OnTileClickedEvent;
    }

    public void OnTileClickedEvent(Tile _selected){
         //bool isPresent = Array.Exists(_selectedTiles, element => element = _selected);
        int index = _selectedTiles[0] is not null ? 1 : 0;
        _selectedTiles[index] = _selected;
                
        if (index > 0){
            OnTileInteraction.Invoke();
            if (_selectedTiles[0].tileAt3b.tileID == _selected.tileAt3b.tileID)
            {
                OnCorrectInteraction.Invoke();
                DeactivateTileObjects(_selectedTiles[0], _selectedTiles[1]);
                //TileActiveChecker();
                AudioManager._Instance.PlaySFX(AudioController._Instance.SFXClips[2]);
            }
            else
            {
                DeactivateTileHighlights(_selectedTiles[0], _selectedTiles[1]);
                AudioManager._Instance.PlaySFX(AudioController._Instance.SFXClips[3]);
            }
            Array.Clear(_selectedTiles, 0, _selectedTiles.Length);
        }
    }

    // Helper method to deactivate tile objects and set their isActive flag
    private void DeactivateTileObjects(Tile tile1, Tile tile2)
    {
        tile1.gameObject.SetActive(false);
        tile2.gameObject.SetActive(false);
        tile1.tileAt3b.isActive = false;
        tile2.tileAt3b.isActive = false;
    }

    // Helper method to deactivate tile highlights
    private void DeactivateTileHighlights(Tile tile1, Tile tile2)
    {
        tile1.tileHighlights.gameObject.SetActive(false);
        tile2.tileHighlights.gameObject.SetActive(false);
    }

    /* public void TileActiveChecker(){
        bool allDeactivated = true;
        foreach(var item in _tiles){
            if(item.tileAt3b.isActive is false) allDeactivated = item.tileAt3b.isActive;
        }
        if(_tileActive <= 0 && allDeactivated) isGameOver = true;
        _tileActive -= 2;
        Debug.Log(_tileActive);
        if (isGameOver){
            OnAllTileIsDisabled.Invoke();//Raise an event for Game Over
            Debug.Log("GameOver");
        }
    } */
}
