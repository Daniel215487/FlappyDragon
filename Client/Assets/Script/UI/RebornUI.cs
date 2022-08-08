
public class RebornUI :  UI
{
    /// <summary>
    /// Reborn後 不讓他回Begin 直接切回InGame
    /// </summary>
    public override void ClickNext()
    {
        // base.ClickNext();
        Main.Ins.ChangeProcess(Main.GameProcess.InGame);
    }
}
