using UnityEngine;
using DG.Tweening;

public class Player_State {
    public Transform PlayerTrf;
    private PState _pState;
    private SpriteRenderer _sirt;

    public void Bind(Transform ptf){
        PlayerTrf = ptf;
        _sirt = PlayerTrf.GetComponent<SpriteRenderer>();
    }
    public void SetPlayerState(PState state){
        _pState=state;
        ChangeState();
    }
    
    private void ChangeState(){
        switch(_pState){
            case PState.None:
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
    public bool IsDead(){
        return _pState==PState.Dead;
    } 
    public bool IsJump(){
        return _pState==PState.Jump;
    } 

    public enum PState{
        None,
        Fall,
        Jump,
        Dead,
    }
}
