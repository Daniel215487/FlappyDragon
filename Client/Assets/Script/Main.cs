using LinChTools;

public class Main : SingletonMono<Main>
{ 
    private GameProcess _gProcess;  // 目前流程
    public GameProcess GProcess{
        get {return _gProcess;}
    }
    /// <summary>
    /// 遊戲執行 程式出發點
    /// </summary>
    void Start(){
        UIMgr.Ins.Bind();
        ChangeProcess(GameProcess.Begin);
    }
    public void ChangeProcess(int pi){
        ChangeProcess((GameProcess)pi);
    }
    /// <summary>
    /// 流程切換，各控制器執行該階段工作
    /// </summary>
    /// <param name="p"></param>
    public void ChangeProcess(GameProcess p){
        UIMgr.Ins.ChangeUIByPros(p);
        _gProcess=p;
        switch(p){
            case GameProcess.Begin:
            Player_Controller.Ins.Begin();
            Obstacle_Controller.Ins.Begin();
            break;
            case GameProcess.InGame:
            Player_Controller.Ins.InGame();
            break;
            case GameProcess.GameOver:
            Obstacle_Controller.Ins.GameOver();
            Player_Controller.Ins.GameOver();
            break;
            case GameProcess.Reborn:
            Player_Controller.Ins.Reborn();
            Obstacle_Controller.Ins.Reborn();
            break;
        }
    }
    /// <summary>
    /// 流程控制Enum
    /// </summary>
    public enum GameProcess{
        Begin=0,
        InGame=1,
        GameOver=2,
        Reborn=3,
        End
    }
}
