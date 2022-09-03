using UnityEngine;
using UnityEngine.UI;

public sealed class Tile: ButtonBase
{
    public int x;
    public int y;
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

    public override void ButtonEventCalling()
    {
        base.ButtonEventCalling();
        TileSelection._Instance.SelectingTiles(this);
    }
}
