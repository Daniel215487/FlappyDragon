using UnityEngine;

/// <summary>
/// 障礙物邏輯 (邏輯面)
/// </summary>
public class Obstacle : MonoBehaviour
{
    private Obstacle_Controller _contlor = null;    //障礙物控制器
    private Transform objTra;                       //障礙物Trans
    public Transform UpObj;                         //障礙物Prefab 上方物件
    public Transform DownObj;                       //障礙物Prefab 下方物件
    public Vector3 SpawnPos;                        //生成初始位置
    public float UDRandonRange;                     //生成隨機差異(上下 Y軸)

    /// <summary>
    /// 向上綁定控制器
    /// </summary>
    /// <param name="con"></param>
    public void Bind(Obstacle_Controller con){
        _contlor=con;
        objTra=this.gameObject.transform;
    }
    /// <summary>
    /// 生成初始設定 設定位置 上下距離差異 火焰隨機大小
    /// </summary>
    public void InitPos(){
        int updown = Random.Range(0,2);
        Vector3 pos=SpawnPos+Vector3.down*Random.Range(UDRandonRange*-1,UDRandonRange);
        Quaternion rot=Quaternion.identity;
        if(updown==0){
            rot=Quaternion.Euler(180,0,0);
        }
        objTra.SetPositionAndRotation(pos,rot);

        UpObj.localScale=Vector3.one+Vector3.up*Random.Range(0f,1f);
        DownObj.localScale=Vector3.one+Vector3.up*Random.Range(0f,1f);
    }
    /// <summary>
    /// 障礙物移動 向上對障礙物控制器的Action綁定 並進行Update
    /// </summary>
    public void Move(){
        objTra.localPosition+=Vector3.left*Time.deltaTime*5;
        if(objTra.localPosition.x<=-16){
            _contlor.Del(this);
        }
    }
}
