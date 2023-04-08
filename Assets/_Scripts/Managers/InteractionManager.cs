using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InteractionManager : Singleton<InteractionManager>
{
    public delegate void InteractionEventHandler();
    public static event InteractionEventHandler OnTileInteraction;
    [SerializeField] private Tile[] _selectedTiles;
    private void Start()
    {
        Tile.OnTileClicked += OnTileClickedEvent;
        _selectedTiles = new Tile[2];
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
                DeactivateTileObjects(_selectedTiles[0], _selectedTiles[1]);
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
}
