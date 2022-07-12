using UnityEngine;
using System.Collections.Generic;
using LinChTools;
public class Obstacle_Controller : MonoBehaviour
{
    public GameObject ObstacleObj;
    public Transform ObstacleTrans;
    private ObjectPool<Obstacle> _obspool;
    private Dictionary<int,Obstacle> Dir= new Dictionary<int, Obstacle>();
    private int Snum,Enum;
    // Start is called before the first frame update
    void Start()
    {
        if(ObstacleObj==null||ObstacleTrans==null)
            Debug.LogWarning("沒有掛載障礙物件Or父物件");
        else{
            _obspool = ObjectPool<Obstacle>.Ins;
            _obspool.InitPool(ObstacleObj,ObstacleTrans,5);
        }
    }
    public void Add(){
        Obstacle obj = _obspool.GetItem();
        obj.transform.position=Vector3.right*Snum;
        Dir.Add(Snum,obj);
        Snum++;
    }
    public void Del(){
        _obspool.RecycleItem(Dir[Enum]);
        Enum++;
    }
}
