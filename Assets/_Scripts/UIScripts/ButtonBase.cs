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

    public virtual void ButtonEventCalling(){}
}
