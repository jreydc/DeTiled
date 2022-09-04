using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TileSelection : MonoBehaviour
{
    private readonly List<Tile> _selection = new List<Tile>();

    public async void SelectingTiles(Tile tile){

        if(!_selection.Contains(tile)) _selection.Add(tile);

         if(_selection.Count < 2) return;

        Debug.Log($"Selected tiles at ({_selection[0].x}, {_selection[0].y} and ({_selection[1].x}, {_selection[1].y}))");

        await SwappingTiles(_selection[0], _selection[1]);

        /* if (CanPop()){
            Pop();
        }else{
            await SwappingTiles(_selection[0], _selection[1]);
        } */

        _selection.Clear();
    }

    public async Task SwappingTiles(Tile tile1, Tile tile2){      
        var icon1Color = tile1.icon.color;

        tile1.icon.color = tile2.icon.color;
        tile2.icon.color = icon1Color;

        await Task.CompletedTask;        
    }

    public bool CanPop(){
        for(int x = 0; x < GridManager.dimension; x++){
            for(int y = 0; y < GridManager.dimension; y++){
                if (GridManager.Tiles[x, y].GetConnectedTiles().Skip(1).Count() >= 2) return true;
            }

        }
        return false;
    }

    public async void Pop(){
        for(int x = 0; x < GridManager.dimension; x++){
            for(int y = 0; y < GridManager.dimension; y++){
                var tile = GridManager.Tiles[x, y];

                var connectedTiles = tile.GetConnectedTiles();

                if (connectedTiles.Skip(1).Count() < 2) continue;//skips the first tile on the iterations

                foreach (var connectedTile in connectedTiles) {
                    connectedTile.transform.localScale = Vector3.zero; //minimizes the scale of the connected tiles
                }

                await Task.Delay(1);

                foreach (var connectedTile in connectedTiles){
                    connectedTile.icon.color = GridManager.colors[UnityEngine.Random.Range(0, GridManager.colorNumber)];

                    connectedTile.transform.localScale = Vector3.one; //returns back to the normal scale of the connected tiles
                }

                await Task.Delay(1);
            }

        }
    }

    /* private IEnumerator ReduceTileScale(Transform tileTransform, Vector3 intendedScale){
        
        Vector3 scale2Change = new Vector3(0.25f, 0.25f, 0.25f);

        while (tileTransform.localScale != intendedScale)
        {
            tileTransform.localScale -= scale2Change;
        }
        yield return tileTransform;
    }

    private IEnumerator IncreaseTileScale(Transform tileTransform, Vector3 intendedScale){
        Vector3 scale2Change = new Vector3(0.25f, 0.25f, 0.25f);

        while (tileTransform.localScale != intendedScale)
        {
            tileTransform.localScale += scale2Change;
        }

        yield return tileTransform;
    } */
}

