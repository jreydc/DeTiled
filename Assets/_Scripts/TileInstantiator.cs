using UnityEngine;

public static class TileInstantiator 
{
    public static Tile TileInstance {get; private set;}
    [RuntimeInitializeOnLoadMethod]private static void Initialize() => TileInstance = Resources.Load<Tile>("Prefab/");
}
