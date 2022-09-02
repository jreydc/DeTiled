public class PlayButtonScript : ButtonBase
{
    public override void ButtonEventCalling()
    {
        base.ButtonEventCalling();
        UIController._Instance.PromptBoxVisibility(true);
    }
}
