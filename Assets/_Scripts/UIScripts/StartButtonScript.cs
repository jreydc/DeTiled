using UnityEngine;
public class StartButtonScript : ButtonBase
{   
    public override void ButtonEventCalling()
    {
        base.ButtonEventCalling();
        StartCoroutine(SceneController.Instance.LoadLevelDetails("MainGameScene"));
        //SceneController._Instance.UnloadLevel(SceneController._Instance.GetCurrentScene().ToString());
        PlayerPrefs.SetInt("Even", UIController._Instance.GetEvenNumberInput());
        PlayerPrefs.SetInt("Another", UIController._Instance.GetAnotherNumberInput());
        Debug.Log(UIController._Instance.GetAnotherNumberInput()+ " - " +UIController._Instance.GetEvenNumberInput());
    }
}
