public class PlayButtonScript : ButtonBase
{
    protected override void ButtonEventCalling()
    {
        base.ButtonEventCalling();
        SceneController._Instance.LoadLevelDetails("GameScene");
    }
}
