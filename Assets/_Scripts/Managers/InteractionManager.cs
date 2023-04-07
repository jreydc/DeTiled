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

    public void Init(Tile[,] tiles){

    }

    public void OnTileClickedEvent(Tile _selected){
        int index = _selectedTiles[0] is not null ? 1 : 0;
        _selectedTiles[index] = _selected;
                
        if(index > 0){
            /* foreach(var item in _selectedTiles){
                if(_selected.tileAt3b.tileID == item.tileAt3b.tileID){
                    item.gameObject.SetActive(false);
                    Debug.Log(item.tileAt3b.tileID+"-"+_selected.tileAt3b.tileID+" passed ID");
                }
            } */
            if(_selectedTiles[0].tileAt3b.tileID == _selected.tileAt3b.tileID){
                _selectedTiles[0].gameObject.SetActive(false);
                _selectedTiles[1].gameObject.SetActive(false);
            }else{
                _selectedTiles[0].tileHighlights.gameObject.SetActive(false);
                _selectedTiles[1].tileHighlights.gameObject.SetActive(false);
            }
            Array.Clear(_selectedTiles, 0, _selectedTiles.Length);
        }

        //bool isPresent = Array.Exists(_selectedTiles, element => element = _selected);
    }
}
