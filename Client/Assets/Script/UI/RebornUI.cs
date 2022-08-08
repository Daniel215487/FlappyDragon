using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebornUI :  UI
{
    public override void ClickNext()
    {
        // base.ClickNext();
        Main.Ins.ChangeProcess(Main.GameProcess.InGame);
    }
}
