using UnityEngine;
using UnityEngine.UI;

public static class TileInstantiator 
{
    public static Object TileInstance {get; private set;}
    public static Object RowInstance {get; private set;}
    [RuntimeInitializeOnLoadMethod]private static void InitializeTile() => TileInstance = Resources.Load("Prefabs/Tile", typeof(Object));
    [RuntimeInitializeOnLoadMethod]private static void InitializeRow() => RowInstance = Resources.Load("Prefabs/Row", typeof(Object));
}
