using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    #region UIController Single Instance;
    public static UIController _Instance;   
    private void Awake() {
        _Instance = this;
    }

    #endregion
    

    [SerializeField]private GameObject promptBox;
     

    public void PromptBoxVisibility(bool isVisible){
        promptBox.SetActive(isVisible);
    }

}
