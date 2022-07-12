using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Obstacle_Controller _contlor = null;
    private Transform objTra;
    public void Bind(Obstacle_Controller con){
        _contlor=con;
        objTra=this.gameObject.transform;
        objTra.SetPositionAndRotation(Vector3.zero,Quaternion.identity);
    }
    void Update(){
        if(_contlor!=null){
            Move();
        }
    }
    private void Move(){
        
    }
    private void Delet(){

    }
}
