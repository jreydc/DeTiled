using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class Tile: ButtonBase
{
    private TileSelection tileSelector; 
    public int x;
    public int y;
    public int value;
    public Image icon;
    private Color _color;
    
    public Color ColorChange{
        get => _color;
        set{
            if(_color ==  value)return;

            _color = value;

            icon.color = _color;
        }
    }

    private void Start() =>  tileSelector = GetComponent<TileSelection>();

    public override void ButtonEventCalling()//responsible on the tile selection , inheriting the Button Base virtual method
    {
        base.ButtonEventCalling();
       TileSelection._Instance.SelectingTiles(this);
    }

    //Checking Neighbours
    public Tile _left => x > 0 ? GridGeneration.Tiles[x - 1, y] : null;
    public Tile _top => y > 0 ? GridGeneration.Tiles[x, y - 1] : null;
    public Tile _right => x < GridManager.dimension - 1? GridGeneration.Tiles[x + 1, y] : null;
    public Tile _bottom => y < GridManager.dimension - 1 ? GridGeneration.Tiles[x, y + 1] : null;

    public Tile[] Neighbours => new Tile[]{
        _left,
        _top,
        _right,
        _bottom
    };

    public List<Tile> GetConnectedTiles(List<Tile> exclude = null){
        var result = new List<Tile>{this,};
        
        //To avoid infinite recursion and excluding this tile after checking
        if (exclude == null){
            exclude = new List<Tile>{this,};
        }else{
            exclude.Add(this);
        }

        //Iterates all of the neighbouring tile and checks the conditions 
        foreach (var neighbour in Neighbours){
            if (neighbour == null || exclude.Contains(neighbour) || neighbour.icon.color != icon.color) continue;

            result.AddRange(neighbour.GetConnectedTiles(exclude));
        }
        return result;
    }
}
