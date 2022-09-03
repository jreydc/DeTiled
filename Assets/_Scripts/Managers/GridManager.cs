using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int dimension => PlayerPrefs.GetInt("Even");
    public int colorNumber => PlayerPrefs.GetInt("Another");
    public Row[] rows => new Row[dimension];
    public Tile[,] Tiles{get; private set;}
    private void Start() {      

        Tiles = new Tile[rows.Max(row => row._tiles.Length), rows.Length];

        for(int y = 0; y < dimension; y++){
            for (int x = 0; x < dimension; x++){
                var tile = rows[y]._tiles[x];
                Tiles[x, y] = tile;

                tile.ColorChange = Random.ColorHSV(colorNumber, colorNumber);
            }
        }
    }
}

