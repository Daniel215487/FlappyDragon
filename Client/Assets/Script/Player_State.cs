using UnityEngine;

public class Player_State {
    public Transform PlayerTrf;
    private PState _pState;

    public void Bind(Transform ptf){
        PlayerTrf = ptf;
    }
    public void SetPlayerState(PState state){
        _pState=state;
        ChangeState();
    }
    private void ChangeState(){
        switch(_pState){
            case PState.None:
                break;
            case PState.Fall:
                PlayerTrf.eulerAngles = Vector3.back*15;
                break;
            case PState.Jump:
                PlayerTrf.eulerAngles = Vector3.forward*25;
                break;
        }
    } 

    public enum PState{
        None,
        Fall,
        Jump
    }
}
