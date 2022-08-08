using UnityEngine;

/// <summary>
/// 所有UI介面要掛載的底層
/// </summary>
public class UI : MonoBehaviour 
{
    public Main.GameProcess GPros;  //此UI所對應的流程
    private UIMgr _mgr;             //UI管理器 向上綁定
    private CanvasGroup _cavGp;     //Canves Component
    public void Awake(){
        _cavGp = this.GetComponent<CanvasGroup>();
    }
    public void Bind(UIMgr mgr){
        _mgr=mgr;
    }
    /// <summary>
    /// 隱藏UI
    /// </summary>
    public void HideUI(){
        _cavGp.alpha=0;
        _cavGp.interactable=false;
        _cavGp.blocksRaycasts=false;
    }
    /// <summary>
    /// 開啟UI
    /// </summary>
    public void OpneUI(){
        _cavGp.alpha=1;
        _cavGp.interactable=true;
        _cavGp.blocksRaycasts=true;

    }
    /// <summary>
    /// UI按鈕用於切換下一階段流程
    /// </summary>
    virtual public void ClickNext(){
        int next = (int)GPros+1;
        if(next>=(int)Main.GameProcess.End){
            next=0;
        }
        Main.Ins.ChangeProcess(next);
    }
}
