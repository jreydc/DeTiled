using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TileSelection : MonoBehaviour
{
    #region TileSelection Single Instance;
    public static TileSelection _Instance;   
    private void Awake() {
        _Instance = this;
    }
    #endregion
    private readonly List<Tile> _selection = new List<Tile>();

    public async void SelectingTiles(Tile tile){

        if(!_selection.Contains(tile)) _selection.Add(tile);

         if(_selection.Count < 2) return;

        Debug.Log($"Selected tiles at ({_selection[0].x}, {_selection[0].y} and ({_selection[1].x}, {_selection[1].y}))");

        await SwappingTiles(_selection[0], _selection[1]);

        _selection.Clear();
    }

    public async Task SwappingTiles(Tile tile1, Tile tile2){
        var icon1 = tile1.icon;
        var icon2 = tile2.icon;

        tile1.icon.color = tile2.icon.color;
        tile2.icon.color = icon1.color;
        
        await Task.Delay(1);
        
    }
}
