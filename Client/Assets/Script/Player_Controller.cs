using UnityEngine;
using DG.Tweening;

public class Player_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform PlayerTrf;
    private float JumpHeight = 1.5f;
    private float ForcePower = 0.01f;
    private bool _isFalling = true;
    private float _offset;
    private Vector3 _newpos;
    private Player_State PState;
    void Start()
    {
        PState = new Player_State();
        if(PlayerTrf!=null)
            PState.Bind(PlayerTrf);
        else
            Debug.LogWarning("沒掛玩家物件");
    }

    // Update is called once per frame
    void Update()
    {
        if(_isFalling)
            Fall();
        // else
        //     Jump();
    }
    public void OnClickToJump(){
        _newpos = PlayerTrf.localPosition+Vector3.up*JumpHeight;
        _isFalling=false;
        PState.SetPlayerState(Player_State.PState.Jump);
        PlayerTrf.DOJump(_newpos,1,1,0.5f).OnComplete(
            ()=>{
                _isFalling=true;
            }
        );
    }
    private void Fall(){
        PState.SetPlayerState(Player_State.PState.Fall);
        PlayerTrf.localPosition+=Vector3.down*ForcePower*3;
    }
    private void Jump(){
        // _offset = Vector3.Magnitude(_newpos-PlayerTrf.position);
        // // print($"offset:{_offset}");
        // if(_offset<0.5f){
        //     _isFalling=true;
        //     PState.SetPlayerState(Player_State.PState.Fall);
        // }
        // else{
        //     PlayerTrf.position+=Vector3.up*ForcePower;
        // }
    }
}
