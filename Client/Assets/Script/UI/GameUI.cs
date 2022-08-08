using UnityEngine.UI;
public class GameUI : UI
{
    public Text PointTxt;
    private int _point;
    /// <summary>
    /// 設定分數
    /// </summary>
    /// <param name="p"></param>
    public void SetPoint(int p){
        _point = p;
        PointTxt.text = _point.ToString();
    }
    /// <summary>
    /// 歸零
    /// </summary>
    public void ReSetPoint(){
        PointTxt.text = "0";
    }
    /// <summary>
    /// 回傳分數
    /// </summary>
    /// <returns></returns>
    public int GetPoint(){
        return _point;
    }
    /// <summary>
    /// Btn點擊事件 通知玩家控制器跳躍
    /// </summary>
    public void ClickJump(){
        Player_Controller.Ins.OnClickToJump();
    }
}
