using UnityEngine;
using UnityEngine.UI;

public static class TileInstantiator 
{
    public static Tile TileInstance {get; private set;}
    public static Row RowInstance {get; private set;}
    
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize() {
        TileInstance = Resources.Load("Prefabs/Tile", typeof(Object)) as Tile;
        RowInstance = Resources.Load("Prefabs/Row", typeof(Object)) as Row;
    }
}
