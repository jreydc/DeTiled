using UnityEngine;

public class GridGeneration : MonoBehaviour
{
    private int dimension => PlayerPrefs.GetInt("Even");
    private int colorNumber => PlayerPrefs.GetInt("Another");
    private Row[] rows; 
    [SerializeField]private Tile tile;
    [SerializeField]private Row columns;

    public void GeneratingGrid(){
        rows = new Row[dimension];

        //Tiles = new Tile[rows.Max(row => row._tiles.Length), rows.Length]; 
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

                rows[x]._tiles[y].ColorChange = new Color(
                    Random.Range(0f, colorNumber), 
                    Random.Range(0f, colorNumber), 
                    Random.Range(0f, colorNumber)
                );

                
                //Tiles[x, y] = tile;
            }
        }
    }
}
