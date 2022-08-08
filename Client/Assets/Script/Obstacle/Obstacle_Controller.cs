using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;
using LinChTools;

/// <summary>
/// 障礙物控制器 (控制面)
/// </summary>
public class Obstacle_Controller : SingletonMono<Obstacle_Controller>
{
    public GameObject ObstacleObj;          //欲生成障礙物的Prefab
    public Transform ObstacleTrans;         //障礙物的父物件
    public Action MoveAct = () => {};       //"全部的障礙物" 移動用 Action
    private ObjectPool<Obstacle> _obspool;  //障礙物物件池
    private float _timer,T;                   //生成障礙物計時
    public float MinSpawnT;                 //最低生成障礙物時間間隔
    
    /// <summary>
    /// 遊戲開始 障礙物控制器設定 池生成
    /// </summary>
    public void Begin(){

        if(ObstacleObj==null||ObstacleTrans==null)
            Debug.LogWarning("沒有掛載障礙物件Or父物件");
        else{
            _obspool = ObjectPool<Obstacle>.Ins;
            _obspool.InitPool(ObstacleObj,ObstacleTrans,5);
        }
        GameOver();
    }
    /// <summary>
    /// 遊戲結束時設定 停止所有障礙物移動
    /// </summary>
    public void GameOver(){
        _timer=0;
        T=0.5f;
        MoveAct = () => {};
    }
    /// <summary>
    /// 刪除所有障礙物
    /// </summary>
    public void Reborn(){
        DelAll();
    }
    /// <summary>
    /// 障礙物生成邏輯，在遊戲進行階段 計時並生成
    /// </summary>
    void Update(){
        if(Main.Ins.GProcess == Main.GameProcess.InGame){
            if(_timer>T){
                Add();
                _timer=0;
                T=UnityEngine.Random.Range(MinSpawnT,MinSpawnT+0.5f);
            }
            _timer+=Time.deltaTime;
            MoveAct();
        }
    }
    /// <summary>
    /// 添加障礙物
    /// </summary>
    public void Add(){
        Obstacle obj = _obspool.GetItem();
        obj.Bind(this);
        obj.InitPos();
        MoveAct+=obj.Move;
    }
    /// <summary>
    /// 刪除障礙物
    /// </summary>
    /// <param name="obs"></param>
    public void Del(Obstacle obs){
        MoveAct-=obs.Move;
        _obspool.RecycleItem(obs);
    }
    /// <summary>
    /// 刪除全部的障礙物
    /// </summary>
    public void DelAll(){
        List<Obstacle> _list = ObstacleTrans.GetComponentsInChildren<Obstacle>().ToList();
        foreach(var o in _list){
            if(o.gameObject.activeSelf)
                Del(o);
        }
    }
}
