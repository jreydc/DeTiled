using UnityEngine;
using UnityEngine.UI;

public class ButtonBase : MonoBehaviour
{
    public Button _button;
    
    private void Start() {
        _button = GetComponent<Button>();

        _button.onClick.AddListener( ()=>{
            ButtonEventCalling();
        });
    }

    public virtual void ButtonEventCalling(){
        Debug.Log(_button.name);
    }
}
