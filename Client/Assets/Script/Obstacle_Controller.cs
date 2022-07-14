using UnityEngine;
using System.Collections.Generic;
using LinChTools;
public class Obstacle_Controller : MonoBehaviour
{
    public GameObject ObstacleObj;
    public Transform ObstacleTrans;
    private ObjectPool<Obstacle> _obspool;
    private float _timer,T;
   
    // Start is called before the first frame update
    void Start()
    {
        if(ObstacleObj==null||ObstacleTrans==null)
            Debug.LogWarning("沒有掛載障礙物件Or父物件");
        else{
            _obspool = ObjectPool<Obstacle>.Ins;
            _obspool.InitPool(ObstacleObj,ObstacleTrans,5);
        }
        _timer=0;
        T=0.5f;
    }
    void Update(){
        if(_timer>T){
            Add();
            _timer=0;
            T=Random.Range(4.5f,5f);
        }
        _timer+=Time.deltaTime;
    }
    public void Add(){
        Obstacle obj = _obspool.GetItem();
        obj.Bind(this);
        obj.InitPos();
        obj.Move();
    }
    public void Del(Obstacle obs){
        _obspool.RecycleItem(obs);
    }
}
