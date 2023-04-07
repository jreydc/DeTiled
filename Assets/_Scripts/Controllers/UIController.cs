using UnityEngine;

public abstract class UIController : MonoBehaviour
{
    [SerializeField]private GameObject _ui;

    public void UIVisibility(bool isVisible){
        _ui.SetActive(isVisible);
    }

    public virtual void UIDisplay(string textContent){

    }

}
