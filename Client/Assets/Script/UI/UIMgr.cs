using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using LinChTools;

public class UIMgr : SingletonMono<UIMgr>
{
    private List<UI> UiList;
    private UI _curUi;
    public void Bind(){
        UiList=this.gameObject.GetComponentsInChildren<UI>().ToList();
        // Debug.Log(UiList);
    }
    public void ChangeUIByPros(Main.GameProcess gp){
        if(_curUi!=null)
            _curUi.HideUI();
        _curUi=UiList.Find(x=>x.GPros==gp);
        if(_curUi!=null)
            _curUi.OpneUI();
    }
    public UI GetUI(Main.GameProcess gp){
        UI ui = UiList.Find(x=>x.GPros==gp);
        if(ui!=null)
         return ui;
        else{
            Debug.LogError($"找不到UI:{gp}");
            return null;
        }
    } 
}
