using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using LinChTools;

public class UIMgr : SingletonMono<UIMgr>
{
    private List<UI> UiList;    // 所有UI的列表
    private UI _curUi;          // 目前的UI

    /// <summary>
    /// 取得Canves底下 所有掛載UI的物件
    /// </summary>
    public void Bind(){
        UiList=this.gameObject.GetComponentsInChildren<UI>().ToList();
        // Debug.Log(UiList);
    }
    /// <summary>
    /// 根據流程切換UI介面
    /// </summary>
    /// <param name="gp"></param>
    public void ChangeUIByPros(Main.GameProcess gp){
        if(_curUi!=null)
            _curUi.HideUI();
        _curUi=UiList.Find(x=>x.GPros==gp);
        if(_curUi!=null)
            _curUi.OpneUI();
    }
    /// <summary>
    /// 取得特定UI
    /// </summary>
    /// <param name="gp"></param>
    /// <returns></returns>
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
