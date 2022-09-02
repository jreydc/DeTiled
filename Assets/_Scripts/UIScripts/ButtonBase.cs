using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonBase : MonoBehaviour
{
    public Button _button;

    private void Awake() {
        _button = GetComponent<Button>();

        _button.onClick.AddListener( ()=>{
            ButtonEventCalling();
        });
    }


    public Button GetButtonComponent(){
        return GetComponent<Button>();
    }

    public virtual void ButtonEventCalling(){
        Debug.Log(_button.name + "clicked!");
    }
}
