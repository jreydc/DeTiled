using System;
using UnityEngine;

public class GridGeneration : MonoBehaviour
{
    private Row[] rows; 
    public static Tile[,] Tiles;
    public static Tile[,] GetTiles {
        get {return Tiles;}
    }
   
    public void GeneratingGrid(Tile tile, Row columns, int dimension, int colorNumber){
        rows = new Row[dimension];

        Tiles = new Tile[dimension, rows.Length]; 
        for(int x = 0; x < dimension; x++){
            
            rows[x] = Instantiate(columns, transform.position, Quaternion.identity);
            rows[x].transform.SetParent(transform);
            rows[x].transform.localScale = Vector3.one;
            
            rows[x]._tiles = new Tile[dimension];

            for(int y = 0; y < rows[x]._tiles.Length; y++){
                rows[x]._tiles[y] = Instantiate(tile, rows[x].transform.position, Quaternion.identity);
                rows[x]._tiles[y].transform.SetParent(rows[x].transform);
                rows[x]._tiles[y].transform.localScale = Vector3.one;
                rows[x]._tiles[y].name = $"Tile {x}{y}";
                rows[x]._tiles[y].x = x;
                rows[x]._tiles[y].y = y;

                rows[x]._tiles[y].ColorChange = GridManager.colors[UnityEngine.Random.Range(0, colorNumber)];             
                
                Tiles[x, y] = rows[x]._tiles[y];
            }
        }
    }
}
