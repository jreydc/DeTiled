
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private Grid _grid;
    [SerializeField] private GridGeneration _gridGenerator;
    
    private void Start() {      
        _gridGenerator.GeneratingGrid();
    }

    private void Update() {
        //for testing on the connected tiles
        if(!Input.GetKeyDown(KeyCode.Space)) return;

        foreach(var connectedTiles in GridGeneration.Tiles[0,0].GetConnectedTiles()){
            connectedTiles.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
        }
    }
}

