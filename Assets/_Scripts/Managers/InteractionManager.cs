using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InteractionManager : Singleton<InteractionManager>
{
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
                
        if(index > 0){
            if(_selectedTiles[0].tileAt3b.tileID == _selected.tileAt3b.tileID){
                _selectedTiles[0].gameObject.SetActive(false);
                _selectedTiles[1].gameObject.SetActive(false);
                AudioManager._Instance.PlaySFX(AudioController._Instance.SFXClips[2]);
            }else{
                _selectedTiles[0].tileHighlights.gameObject.SetActive(false);
                _selectedTiles[1].tileHighlights.gameObject.SetActive(false);
                AudioManager._Instance.PlaySFX(AudioController._Instance.SFXClips[3]);
            }
            Array.Clear(_selectedTiles, 0, _selectedTiles.Length);
        }
    }
}
