using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonScript : ButtonBase
{
    public override void ButtonEventCalling()
    {
        base.ButtonEventCalling();
        StartCoroutine(SceneController._Instance.LoadingDetails());
        SceneController._Instance.LoadLevel("GamePlayScene");
    }
}
