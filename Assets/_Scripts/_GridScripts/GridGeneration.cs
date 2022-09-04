using System;
using UnityEngine;

public class GridGeneration : MonoBehaviour
{
    private static int dimension => PlayerPrefs.GetInt("Even");
    private static int colorNumber => PlayerPrefs.GetInt("Another");
    private Row[] rows; 
    [SerializeField]private Tile tile;
    [SerializeField]private Row columns;

    private static Color[] colors => new[]{
        Color.green,
        Color.red, 
        Color.white,
        Color.blue,
        Color.magenta
    };

    public static Tile[,] Tiles;
    public static Tile[,] GetTiles {
        get {return Tiles;}
    }
    public static int Dimension {
        get {return dimension;} 
    }

    public static int GetColorNumber {
        get {return colorNumber;} 
    }

    public static Color[] GetColors{
        get {return colors;}
    }
    public void GeneratingGrid(){
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

                rows[x]._tiles[y].ColorChange = colors[UnityEngine.Random.Range(0, colorNumber)];             
                
                Tiles[x, y] = rows[x]._tiles[y];
            }
        }
    }
}
