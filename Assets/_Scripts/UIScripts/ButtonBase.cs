using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonBase : MonoBehaviour
{
    
    public Button _button;

    protected virtual void Awake() {
        _button = GetComponent<Button>();

        _button.onClick.AddListener( ()=>{
            ButtonEventCalling();
        });
    }

    protected virtual void ButtonEventCalling(){
        Debug.Log(_button.name + "clicked!");
    }
}
