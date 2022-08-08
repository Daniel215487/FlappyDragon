using UnityEngine;
using DG.Tweening;

/// <summary>
/// 玩家狀態 (表現面)
/// </summary>
public class Player_State {
    public Transform PlayerTrf;     //玩家Tran 用於控制旋轉及位置
    private PState _pState;         //玩家當前狀態
    private SpriteRenderer _sirt;   //用於設定死亡後燒焦顏色

    /// <summary>
    /// 綁定Trans 取得Renderer Component 
    /// </summary>
    /// <param name="ptf"></param>
    public void Bind(Transform ptf){
        PlayerTrf = ptf;
        _sirt = PlayerTrf.GetComponent<SpriteRenderer>();
    }
    /// <summary>
    /// 玩家狀態切換
    /// </summary>
    /// <param name="state"></param>
    public void SetPlayerState(PState state){
        _pState=state;
        ChangeState();
    }
    /// <summary>
    /// 狀態機切換，(顏色、位置、旋轉、動態)設定
    /// </summary>
    private void ChangeState(){
        switch(_pState){
            case PState.None:
                PlayerTrf.DOKill();
                PlayerTrf.position = Vector3.left*5;
                PlayerTrf.eulerAngles = Vector3.zero;
                _sirt.color=Color.white;
                break;
            case PState.Fall:
                PlayerTrf.eulerAngles = Vector3.back*35;
                break;
            case PState.Jump:
                PlayerTrf.eulerAngles = Vector3.forward*25;
                break;
            case PState.Dead:
                _sirt.DOColor(new Color(0.35f,0.11f,0),0.5f);
                PlayerTrf.DOLocalRotate(Vector3.forward*95,0.5f);
                PlayerTrf.DOLocalMoveY(PlayerTrf.position.y+4,0.5f).OnComplete(
                    ()=>{
                        PlayerTrf.DOMoveY(-10,1f);
                    }
                );
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// 回傳玩家是否死亡
    /// </summary>
    /// <returns></returns>
    public bool IsDead(){
        return _pState==PState.Dead;
    }
    /// <summary>
    /// 回傳是否正在向上跳躍
    /// </summary>
    /// <returns></returns>
    public bool IsJump(){
        return _pState==PState.Jump;
    } 
    /// <summary>
    /// 玩家狀態機Enum
    /// </summary>
    public enum PState{
        None,
        Fall,
        Jump,
        Dead,
    }
}
