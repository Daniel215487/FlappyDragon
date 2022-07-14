using UnityEngine;
using DG.Tweening;
public class Obstacle : MonoBehaviour
{
    private Obstacle_Controller _contlor = null;
    private Transform objTra;
    public Transform UpObj;
    public Transform DownObj;
    public void Bind(Obstacle_Controller con){
        _contlor=con;
        objTra=this.gameObject.transform;
    }
    public void InitPos(){
        int updown = Random.Range(0,2);
        Vector3 pos=Vector3.right*16+Vector3.down*Random.Range(-0.6f,0.6f);
        Quaternion rot=Quaternion.identity;
        if(updown==0){
            rot=Quaternion.Euler(180,0,0);
        }
        objTra.SetPositionAndRotation(pos,rot);

        UpObj.localScale=Vector3.one+Vector3.up*Random.Range(0f,1f);
        DownObj.localScale=Vector3.one+Vector3.up*Random.Range(0f,1f);
    }
    public void Move(){
        objTra.DOLocalMoveX(-16,10).SetEase(Ease.Linear).OnComplete(
            ()=>{
                _contlor.Del(this);
            }
        );
    }
}
