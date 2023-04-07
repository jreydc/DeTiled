using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButtonScript : ButtonBase
{
    protected override void ButtonEventCalling()
    {
        base.ButtonEventCalling();
        GameManager._Instance.QuitGame();
    }
}
