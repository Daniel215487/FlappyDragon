using UnityEngine.UI;
public class GameUI : UI
{
    public Text PointTxt;
    private int _point;

    public void SetPoint(int p){
        _point = p;
        PointTxt.text = _point.ToString();
    }
    public void ReSetPoint(){
        PointTxt.text = "0";
    }
    public int GetPoint(){
        return _point;
    }
}
