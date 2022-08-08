using UnityEngine;
using LinChTools;

/// <summary>
/// 玩家控制器 (控制面)
/// </summary>
public class Player_Controller : SingletonMono<Player_Controller>
{
    public Player Plyr;             //玩家
    private int Point=0;            //玩家分數
    private GameUI _gameui;         //顯示的GameUI
    private GameOverUI _gameoverui; //死亡後顯示的GameOverUI
    /// <summary>
    /// 遊戲開始 玩家控制器初始設定
    /// </summary>
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
    /// <summary>
    /// 開啟玩家鋼體模擬
    /// </summary>
    public void InGame(){
        Plyr.swtichSimlluated(true);
    }
    /// <summary>
    /// 玩家死亡 關閉模擬防止無限下墜
    /// </summary>
    public void GameOver(){
        Point=0;
        Plyr.swtichSimlluated(false);
    }
    /// <summary>
    /// 玩家重生設定
    /// </summary>
    public void Reborn(){
        _gameui.ReSetPoint();
        Plyr.Reborn();
    }
    /// <summary>
    /// 通知玩家跳躍
    /// </summary>
    public void OnClickToJump(){
        Plyr.Jump();
    }
    /// <summary>
    /// 傳送最後得分 並於玩家死亡後切換UI及流程
    /// </summary>
    public void PlayerDead(){
        _gameoverui.GetGamePoint();
        _gameui.ClickNext();
    }
    /// <summary>
    /// 玩家(class player)向上通知控制器得分
    /// </summary>
    public void GetPoint(){
        Point++;
        _gameui.SetPoint(Point);
    }
}
