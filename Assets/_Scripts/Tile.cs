using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : ButtonBase
{
    public delegate void TileClickerEventHandler(Tile _tile);
    public static event TileClickerEventHandler OnTileClicked;
    public TileAttrib tileAt3b;
    public Transform tileSprite, tileHighlights;
    private bool isActive;

    private void Start(){
        isActive = false;
    }

    public void Init(int id, Vector3 pos, Sprite sp){
        tileAt3b.tileID = id;
        tileAt3b.tilePosition = pos;
        tileSprite.GetComponent<Image>().sprite = sp;
    }

    protected override void ButtonEventCalling()
    {
        //base.ButtonEventCalling();
        AudioManager._Instance.PlaySFX(AudioController._Instance.SFXClips[1]);
        isActive = isActive == false ? true : false;
        tileHighlights.gameObject.SetActive(isActive);
        
        OnTileClicked.Invoke(this);
    }
}
