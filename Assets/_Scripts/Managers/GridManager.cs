using UnityEngine;
using JDevTools.Runtime.GameSystemComponents.Timers;

public class GridManager : MonoBehaviour
{
    #region GridManager Single Instance;
    public static GridManager _Instance;   
    private void Awake() {
        _Instance = this;
    }
    #endregion
    public static int dimension => PlayerPrefs.GetInt("Even");
    public static int colorNumber => PlayerPrefs.GetInt("Another");

    private PointingSystem pointer;
    [SerializeField]private Scorer scorer;
    [SerializeField]private Swapper swapper;
    [SerializeField]private Timer timer;
    private Row[] rows; 
    [SerializeField]private Tile tile;
    [SerializeField]private Row columns;

    public static Color[] colors => new[]{
        Color.green,
        Color.red, 
        Color.white,
        Color.blue,
        Color.magenta
    };

    [SerializeField] private GridGeneration _gridGenerator;
    
    private void Start() {      
        _gridGenerator.GeneratingGrid(tile, columns, dimension, colorNumber);
        pointer = new PointingSystem(TileSelection.GetScore, TileSelection.GetSwapped);
        swapper.PointerSetup(pointer);
        scorer.PointerSetup(pointer);
        
        //_timer.OnTimerEnd += () => SceneController._Instance.LoadLevelDetails("GameOverScene");
        
    }

    private void FixedUpdate() {
        timer.OnTimerChanged();
        scorer.OnScoreChanged(TileSelection.GetScore);
        swapper.OnSwapChanged(TileSelection.GetSwapped);
    }


    /* <summary> the code below were refactored to various classes............................
     */
    //GridGeneration Class
    /* public void GeneratingGrid(Tile tile, Row columns, int dimension, int colorNumber){
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
    } */



    //TileSelection Class
    
    /* private readonly List<Tile> _selection = new List<Tile>();

    public async void SelectingTiles(Tile tile){

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
    } */

    /* public async Task SwappingTiles(Tile tile1, Tile tile2){
        var icon1 = tile1.icon;
        var icon2 = tile2.icon;

        var icon1Transform = icon1.transform;
        var icon2Transform = icon2.transform;

        icon1Transform = tile2.transform;
        icon2Transform = tile1.transform;
       
        var icon1 = tile1.icon.color;

        tile1.icon.color = tile2.icon.color;
        tile2.icon.color = icon1;

        await Task.CompletedTask;        
    }

    public bool CanPop(){
        for(int x = 0; x < dimension; x++)
            for(int y = 0; y < dimension; y++)
                if (Tiles[x, y].GetConnectedTiles().Skip(1).Count() >= 2) return true;
        
        return false;
    }

    public async void Pop(){
        for(int x = 0; x < dimension; x++){
            for(int y = 0; y < dimension; y++){
                var tile = Tiles[x, y];

                var connectedTiles = tile.GetConnectedTiles();

                if (connectedTiles.Skip(1).Count() < 2) continue;//skips the first tile on the iterations

                foreach (var connectedTile in connectedTiles) {
                    connectedTile.transform.localScale = Vector3.zero; //minimizes the scale of the connected tiles
                }

                await Task.Delay(1);

                foreach (var connectedTile in connectedTiles){
                    connectedTile.ColorChange = colors[UnityEngine.Random.Range(0, colorNumber)];

                    connectedTile.transform.localScale = Vector3.one; //returns back to the normal scale of the connected tiles
                }

                await Task.CompletedTask;;
            }

        }
    } */
}

