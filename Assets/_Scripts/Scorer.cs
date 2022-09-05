using UnityEngine;
using TMPro;

public class Scorer : MonoBehaviour
{
    #region Scorer Single Instance;
    public static Scorer _Instance;   
    private void Awake() {
        _Instance = this;
    }
    #endregion
    private PointingSystem _pointer;
    [SerializeField]private TextMeshProUGUI scoreText;
    public void PointerSetup(PointingSystem pointer){
        _pointer = pointer;
        _pointer.OnScoreChanged += Scoring_OnScoreChanged;
    }
    
    private void Scoring_OnScoreChanged(object sender, System.EventArgs e){
        scoreText.text = $"Score {_pointer.GetScore()}";
    }

    public void OnScoreChanged(int score){
        scoreText.text = $"Score: {score}";
    }
}
