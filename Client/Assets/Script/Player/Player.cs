using UnityEngine;

/// <summary>
/// 玩家自身行為邏輯 (邏輯面)
/// </summary>
public class Player : MonoBehaviour
{
    private float ForcePower = 400f;    //跳躍強度
    private Player_State _pState;       //玩家狀態機
    private Rigidbody2D _rig;           //玩家鋼體
    private Player_Controller _plcolr;  //玩家控制器
    private float _timer,T=1;           //跳躍狀態切換計時
    /// <summary>
    /// 向上綁定玩家控制器並初始化
    /// </summary>
    /// <param name="colr"></param>
    public void Bind(Player_Controller colr)
    {
        _plcolr = colr;
        _pState = new Player_State();
        _pState.Bind(this.transform);
        _rig=this.gameObject.GetComponent<Rigidbody2D>();
    }
    /// <summary>
    /// 計時跳躍時間 切換"玩家落下"狀態
    /// </summary>
    private void Update(){
        if(_pState.IsJump()){
            _timer+=Time.deltaTime;
            if(_timer>T){
                _pState.SetPlayerState(Player_State.PState.Fall);
            }
        }
    }
    /// <summary>
    /// 鋼體模擬開關
    /// </summary>
    /// <param name="b"></param>
    public void swtichSimlluated(bool b){
        _rig.simulated = b;
    }
    /// <summary>
    /// 玩家跳躍 賦予鋼體向上的力
    /// </summary>
    public void Jump(){
        _pState.SetPlayerState(Player_State.PState.Jump);
        _rig.AddForce(Vector2.up*ForcePower);
        _timer=0;
    }
    /// <summary>
    /// 重生設定
    /// </summary>
    public void Reborn(){
        _rig.velocity=Vector2.zero;
        _pState.SetPlayerState(Player_State.PState.None);
    }
    /// <summary>
    /// 2D Trigger碰撞設定 碰到tag Obstacle死亡、tag point得分
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerEnter2D(Collider2D col){
        // Debug.Log(col.name);
        if(col.tag == "Obstacle" && !_pState.IsDead()){
            _pState.SetPlayerState(Player_State.PState.Dead);
            _plcolr.PlayerDead();
        }
        if(col.tag == "Point"){
            _plcolr.GetPoint();
        }
    }
}
