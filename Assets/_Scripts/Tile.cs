using UnityEngine;
using UnityEngine.UI;

public sealed class Tile: MonoBehaviour
{
    public int x;
    public int y;
    public Button _button;
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

}
