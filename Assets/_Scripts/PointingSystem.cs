using System;
public class PointingSystem
{
    public event EventHandler OnScoreChanged;
    public event EventHandler OnSwapChanged;

    private int _score;
    private int _swapPoints;

    public PointingSystem(int score, int swapPoints){
        _score = score;
        _swapPoints = swapPoints;
    }

    public int GetScore(){
        return _score;
    }
    public int GetSwap(){
        return _swapPoints;
    }
    public void ScoreComputer(int value){
        _score += value;
        if (OnScoreChanged != null) OnScoreChanged(this, EventArgs.Empty);
    }
    public void SwapComputer(int value){
        _swapPoints += value;
        if (OnSwapChanged != null) OnSwapChanged(this, EventArgs.Empty);
    }
}
