using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float ForcePower = 400f;
    private bool _isFalling = true;
    private Player_State _pState;
    private Rigidbody2D _rig;
    private Player_Controller _plcolr;
    private float _timer,T=1;

    public void Bind(Player_Controller colr)
    {
        _plcolr = colr;
        _pState = new Player_State();
        _pState.Bind(this.transform);
        _rig=this.gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update(){
        if(_pState.IsJump()){
            _timer+=Time.deltaTime;
            if(_timer>T){
                _pState.SetPlayerState(Player_State.PState.Fall);
            }
        }
    }
    public void swtichSimlluated(bool b){
        _rig.simulated = b;
    }
    public void Jump(){
        _pState.SetPlayerState(Player_State.PState.Jump);
        _rig.AddForce(Vector2.up*ForcePower);
        _timer=0;
    }
    public void Reborn(){
        _rig.velocity=Vector2.zero;
        _pState.SetPlayerState(Player_State.PState.None);
    }

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
