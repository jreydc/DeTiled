using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _width, _height;
    [SerializeField] private RectTransform _canvasTrans;
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private Tile[,] _tiles;
    [SerializeField] private Sprite[] _sprite;
    [SerializeField] private Transform _camera;
    [SerializeField] private Vector2 _tileSize;

    private void Start() => GenerateGrid();

    private void GenerateGrid(){
        
        _tiles = new Tile[_width, _height];
        for(int x = 0; x < _width; x++){
            for(int y = 0; y < _height; y++){
                var spawnedTile = Instantiate(_tilePrefab, new Vector2(x,y), Quaternion.identity);
                spawnedTile.name = $"Tile{x}{y}";
                _tiles[x,y] = spawnedTile;
                spawnedTile.transform.SetParent(_canvasTrans);
                spawnedTile.GetComponent<RectTransform>().anchoredPosition = new Vector2(x * _tileSize.x, y * _tileSize.y);
                int id = Random.Range(0, 5);
                spawnedTile.Init(id, new Vector3(x,y), _sprite[id]);
            
                var isOffset = (x + y) % 2 == 1;

            }
        }
        _camera.transform.position = new Vector3((float)(Screen.width / 2),(float)(Screen.height / 2) , _camera.transform.position.z);
    }
}
