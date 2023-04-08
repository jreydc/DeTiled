using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDManager : PersistentSingleton<HUDManager>
{
    [SerializeField]private TMP_Text _scoreText;
    [SerializeField]private TMP_Text _movesText;
    [SerializeField]private int move, score;

    private void Start() {
        InteractionManager.OnTileInteraction += OnMovementCompleteEvent;
    }

    public void OnMovementCompleteEvent(){
        // Depending on the level difficulty, we could implement a max movements logic to the gameplay
        move += 1;
        _movesText.text = move.ToString();
        OnScoreComputation();
    }

    public void OnScoreComputation(){
        // Depending on the game balance computation of the points per completed pairings.       
        score += 2;
        _scoreText.text = score.ToString();
    }
}
