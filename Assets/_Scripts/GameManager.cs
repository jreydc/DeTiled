using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public static event Action<GameState> OnBeforeStateChanged;
    public static event Action<GameState> OnAfterStateChanged;

    public GameState State { get; private set; }

    // Kick the game off with the first state
    void Start() => ChangeState(GameState.STARTING);

    public void ChangeState(GameState newState) {
        OnBeforeStateChanged?.Invoke(newState);

        State = newState;
        switch (newState) {
            case GameState.PREGAME:
                HandleStarting();
                break;
            case GameState.GAME:
                HandleSpawningHeroes();
                HandleSpawningEnemies();
                break;
            case GameState.POSTGAME:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnAfterStateChanged?.Invoke(newState);
        
        Debug.Log($"New state: {newState}");
    }
}

[Serializable]
public enum GameState {
    PREGAME = 0,
    GAME = 1,
    POSTGAME = 2    
}
