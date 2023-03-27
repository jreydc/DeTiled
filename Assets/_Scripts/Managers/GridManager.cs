using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _width, _height;
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private Sprite[] _sprite;
    [SerializeField] private Transform _camera;

    private void Start() => GenerateGrid();

    private void GenerateGrid(){
        for(int x = 0; x < _width; x++){
            for(int y = 0; y < _height; y++){
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x,y), Quaternion.identity);
                spawnedTile.name = $"Tile{x}{y}";
                int id = Random.Range(0, 5);
                spawnedTile.Init(id, new Vector3(x,y), _sprite[id]);
            
                var isOffset = (x + y) % 2 == 1;

            }
        }

        _camera.transform.position = new Vector3((float)_width / 2 - 0.5f,(float)_height / 2 - 0.5f, _camera.transform.position.z);
    }
}
