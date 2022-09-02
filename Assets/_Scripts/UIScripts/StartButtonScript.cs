using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonScript : ButtonBase
{
    public override void ButtonEventCalling()
    {
        base.ButtonEventCalling();
        //SceneController._Instance.LoadLevel("MainGameScene");
        StartCoroutine(SceneController._Instance.LoadLevelDetails("MainGameScene"));
        //SceneController._Instance.UnloadLevel(SceneController._Instance.GetCurrentScene().ToString());
    }
}
