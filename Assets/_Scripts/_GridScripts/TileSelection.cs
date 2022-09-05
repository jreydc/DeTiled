using System.Linq;
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

    private int dimension => GridManager.dimension;// pointing to the GridManager's dimension
    private Color[] colors => GridManager.colors;//pointing to the GridManager's colors


    public async void SelectingTiles(Tile tile){//Responsible for the Selection of tiles

        if(!_selection.Contains(tile)) _selection.Add(tile);

        if(_selection.Count < 2) return;

        Debug.Log($"Selected tiles at ({_selection[0].x}, {_selection[0].y} and ({_selection[1].x}, {_selection[1].y}))");

        await SwappingTiles(_selection[0], _selection[1]); 

        if (CanPop()){
            Pop();
        }else{
            await SwappingTiles(_selection[0], _selection[1]);
        }

        _selection.Clear();
    }

    public async Task SwappingTiles(Tile tile1, Tile tile2){ //Responsible for the Swapping of Tiles     
        var tempTile1 = tile1;
        tile1 = tile2;      
        tile2 = tempTile1;

        Debug.Log($"Swapped tiles at ({tile1.x}, {tile1.y} and ({tile2.x}, {tile2.y}))");
        Debug.Log($"Swapped colors ({tile1.icon.color} and ({tile2.icon.color}))");

        await Task.CompletedTask;        
    }

    public bool CanPop(){
        for(int x = 0; x < dimension; x++){
            for(int y = 0; y < dimension; y++){
                if (GridGeneration.Tiles[x, y].GetConnectedTiles().Skip(1).Count() > 2) return true;
            }
        }
        return false;
    }

    public async void Pop(){
        for(int x = 0; x < dimension; x++){
            for(int y = 0; y < dimension; y++){
                var tile = GridGeneration.Tiles[x, y];

                var connectedTiles = tile.GetConnectedTiles();

                if (connectedTiles.Skip(1).Count() < 2) continue;//skips the first tile on the iterations

                foreach (var connectedTile in connectedTiles) {
                    connectedTile.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
                    await Task.Delay(1);
                    connectedTile.transform.localScale = Vector3.zero; //minimizes the scale of the connected tiles
                }

                foreach (var connectedTile in connectedTiles){
                    connectedTile.ColorChange = colors[UnityEngine.Random.Range(0, GridManager.colorNumber)];

                    connectedTile.transform.localScale = Vector3.one; //returns back to the normal scale of the connected tiles
                }

                await Task.Delay(1);
            }

        }
    }
}

