using UnityEngine.UI;

public class GameOverUI : UI
{
    public Text FinPointTxt;
    private int _finpoint;
    public Text TopPointTxt;
    private int _toppoint;
    private GameUI _gameUi;
    /// <summary>
    /// 顯示最後的分數
    /// </summary>
    public void GetGamePoint(){
        if(_gameUi==null)
            _gameUi=UIMgr.Ins.GetUI(Main.GameProcess.InGame) as GameUI;
        _finpoint = _gameUi.GetPoint();
        _toppoint = int.Parse(TopPointTxt.text);
        if(_finpoint >= _toppoint){
            _toppoint=_finpoint;
        }
        FinPointTxt.text = _finpoint.ToString();
        TopPointTxt.text = _toppoint.ToString();
    }
}
