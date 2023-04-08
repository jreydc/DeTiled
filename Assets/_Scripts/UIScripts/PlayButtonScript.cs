public class PlayButtonScript : ButtonBase
{
    protected override void ButtonEventCalling()
    {
        base.ButtonEventCalling();
        SceneController._Instance.LoadLevel("GameScene");
        GameManager._Instance.ChangeState(GameState.GAME);
    }
}
