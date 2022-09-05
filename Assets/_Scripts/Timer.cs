using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI timerText;
    private float timeLeft = 10f;

        // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft == 0){
            SceneController._Instance.LoadLevelDetails("GameOverScene");
        }
    }

    public void OnTimerChanged(){
        //timerText.text = $"{timeLeft}";
        timerText.text = ((int)timeLeft).ToString();
    }
}
