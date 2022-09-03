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
}

