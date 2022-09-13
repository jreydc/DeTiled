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
        if (timeLeft == 0f){
            //SceneController._Instance.LoadLevelDetails("GameOverScene");
            Debug.Log("Time Ends");
        }
    }

    public void OnTimerChanged(){
        //timerText.text = $"{timeLeft}";
        timerText.text = ((int)timeLeft).ToString();
    }
}
