using UnityEngine;
using UnityEngine.UI;

public sealed class Tile: MonoBehaviour
{
    [SerializeField]private GameObject highlight;
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

    private void OnMouseEnter() {
         highlight.SetActive(true);
    }

    private void OnMouseExit() {
        highlight.SetActive(false);
    }
}
