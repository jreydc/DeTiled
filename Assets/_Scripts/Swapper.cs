using UnityEngine;
using TMPro;

public class Swapper : MonoBehaviour
{
    #region Swapper Single Instance;
    public static Swapper _Instance;   
    private void Awake() {
        _Instance = this;
    }
    #endregion
    private PointingSystem _pointer;
    [SerializeField]private TextMeshProUGUI swapText;
    public void PointerSetup(PointingSystem pointer){
        _pointer = pointer;
        _pointer.OnSwapChanged += Swapping_OnSwapChanged;
    }
    
    private void Swapping_OnSwapChanged(object sender, System.EventArgs e){
        swapText.text = $"Swap {_pointer.GetSwap()}";
    }

    public void OnSwapChanged(int swaps){
        swapText.text = $"Swap {swaps}";
    }
}
