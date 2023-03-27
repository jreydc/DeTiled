using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    #region UIController Single Instance;
    public static UIController _Instance;   
    private void Awake() {
        _Instance = this;
    }
    #endregion 

    [SerializeField]private GameObject promptBox;
    [SerializeField]private TMP_InputField inputEvenNumber;
    [SerializeField]private TMP_InputField inputAnotherNumber;
     
    public void PromptBoxVisibility(bool isVisible){
        promptBox.SetActive(isVisible);
    }

    public int GetEvenNumberInput(){
        return int.Parse(inputEvenNumber.text);
    }

    public int GetAnotherNumberInput(){
        return int.Parse(inputAnotherNumber.text);
    }

}
