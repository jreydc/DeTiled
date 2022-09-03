using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    public int dimension => PlayerPrefs.GetInt("Even");
    public int colorNumber => PlayerPrefs.GetInt("Another");
    public Tile tile;
    public Row columns;
    public Row[] rows;
    
    public Tile[,] Tiles{get; private set;}

    private void Start() {      
        rows = new Row[dimension];
        
        //Tiles = new Tile[rows.Max(row => row._tiles.Length), rows.Length]; 
        for(int x = 0; x < rows.Length; x++){
            //columns = transform.GetChild(0).GetComponent<Row>();
            columns = Instantiate(TileInstantiator.RowInstance) as Row;
            columns._tiles = new Tile[dimension];
            for(int y = 0; y < columns._tiles.Length; y++){
                var spawnedTile = Instantiate(TileInstantiator.TileInstance, new Vector3(x, y), Quaternion.identity) as Tile;
                spawnedTile.name = $"Tile {x}{y}";
            }
        }


        /* for(int y = 0; y < dimension; y++){
            for (int x = 0; x < dimension; x++){
                var spawnedTile = Instantiate(TileInstantiator.TileInstance) as Tile;

                rows[y]._tiles[x] = spawnedTile;
                
                Tiles[x, y] = spawnedTile;

                //tileObject.transform.localPosition = tile.transform.localPosition;
                spawnedTile.ColorChange = Random.ColorHSV(colorNumber, colorNumber);
            }
        } */
    }
}

