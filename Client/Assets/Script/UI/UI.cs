using System;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour 
{
    public Main.GameProcess GPros;
    private UIMgr _mgr;
    private Action _action;
    private CanvasGroup _cavGp;
    public void Awake(){
        _cavGp = this.GetComponent<CanvasGroup>();
    }
    public void Bind(UIMgr mgr){
        _mgr=mgr;
    }
    public void HideUI(){
        _cavGp.alpha=0;
        _cavGp.interactable=false;
        _cavGp.blocksRaycasts=false;
    }
    public void OpneUI(){
        _cavGp.alpha=1;
        _cavGp.interactable=true;
        _cavGp.blocksRaycasts=true;

    }
    virtual public void ClickNext(){
        int next = (int)GPros+1;
        if(next>=(int)Main.GameProcess.End){
            next=0;
        }
        Main.Ins.ChangeProcess(next);
    }
    // public void Get(Action a){
    //     _action=a;
    // }
}
