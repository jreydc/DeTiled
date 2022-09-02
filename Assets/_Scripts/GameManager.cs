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
            case GameState.STARTING:
                HandleStarting();              
                break;
            case GameState.PREGAME:
                HandlePreGame();                
                break;
            case GameState.GAME:
                break;
            case GameState.POSTGAME:

                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnAfterStateChanged?.Invoke(newState);
        
        Debug.Log($"New state: {newState}");
    }

    private void HandleStarting() {
        // Do some start setup, could be rendering environment, cinematics etc

        // Eventually call ChangeState again with your next state
        ChangeState(GameState.PREGAME);
    }

    private void HandlePreGame(){
        
        ChangeState(GameState.GAME);
    }

}

[Serializable]
public enum GameState {

    STARTING = 0,
    PREGAME = 1,
    GAME = 2,
    POSTGAME = 3
        
}
