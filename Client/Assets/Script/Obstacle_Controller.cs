using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;
using LinChTools;
public class Obstacle_Controller : SingletonMono<Obstacle_Controller>
{
    public GameObject ObstacleObj;
    public Transform ObstacleTrans;
    public Action MoveAct = () => {};
    private ObjectPool<Obstacle> _obspool;
    private float _timer,T;
   
    public void Begin(){

        if(ObstacleObj==null||ObstacleTrans==null)
            Debug.LogWarning("沒有掛載障礙物件Or父物件");
        else{
            _obspool = ObjectPool<Obstacle>.Ins;
            _obspool.InitPool(ObstacleObj,ObstacleTrans,5);
        }
        GameOver();
    }
    public void GameOver(){
        _timer=0;
        T=0.5f;
        MoveAct = () => {};
    }
    public void Reborn(){
        DelAll();
    }
    void Update(){
        if(Main.Ins.GProcess == Main.GameProcess.InGame){
            if(_timer>T){
                Add();
                _timer=0;
                T=UnityEngine.Random.Range(4.5f,5f);
            }
            _timer+=Time.deltaTime;
            MoveAct();
        }
    }
    public void Add(){
        Obstacle obj = _obspool.GetItem();
        obj.Bind(this);
        obj.InitPos();
        MoveAct+=obj.Move;
    }
    public void Del(Obstacle obs){
        MoveAct-=obs.Move;
        _obspool.RecycleItem(obs);
    }
    public void DelAll(){
        List<Obstacle> _list = ObstacleTrans.GetComponentsInChildren<Obstacle>().ToList();
        foreach(var o in _list){
            if(o.gameObject.activeSelf)
                Del(o);
        }
    }
}
