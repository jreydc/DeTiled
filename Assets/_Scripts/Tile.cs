using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : ButtonBase
{
    public TileAttrib tileAt3b;
    public Transform tileSprite, tileHighlights;
    public void Init(int id, Vector3 pos, Sprite sp){
        tileAt3b.tileID = id;
        tileAt3b.tilePosition = pos;
        tileSprite.GetComponent<SpriteRenderer>().sprite = sp;
    }

    protected override void ButtonEventCalling()
    {
        base.ButtonEventCalling();
    }
}
