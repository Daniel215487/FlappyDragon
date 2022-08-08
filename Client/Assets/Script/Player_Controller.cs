using System;
using UnityEngine;
using UnityEngine.UI;
using LinChTools;

public class Player_Controller : SingletonMono<Player_Controller>
{
    public Player Plyr;
    private int Point=0;
    private GameUI _gameui;
    private GameOverUI _gameoverui;
    public void Begin(){
        _gameui = UIMgr.Ins.GetUI(Main.GameProcess.InGame) as GameUI;
        _gameoverui = UIMgr.Ins.GetUI(Main.GameProcess.GameOver) as GameOverUI;
        if(Plyr!=null){
            Plyr.Bind(this);
            GameOver();
            Reborn();
        }
        else
            Debug.LogWarning("沒掛玩家物件");
    }
    public void InGame(){
        Plyr.swtichSimlluated(true);
    }
    public void GameOver(){
        Point=0;
        Plyr.swtichSimlluated(false);
    }
    public void Reborn(){
        _gameui.ReSetPoint();
        Plyr.Reborn();
    }
    public void OnClickToJump(){
        Plyr.Jump();
    }
    public void PlayerDead(){
        _gameoverui.GetGamePoint();

        // Main.Ins.ChangeProcess(Main.GameProcess.GameOver);
        _gameui.ClickNext();
    }
    public void GetPoint(){
        Point++;
        _gameui.SetPoint(Point);
    }
}
