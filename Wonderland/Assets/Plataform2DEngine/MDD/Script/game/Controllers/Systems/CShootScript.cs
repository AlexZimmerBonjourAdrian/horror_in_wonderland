using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CShootScript : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController2D _controller;
    [SerializeField] private Transform _positionShoot;
    private float _vel= 40f;
    private float _rote=1;
   // private int _SelectWeapond=1;
    private Vector2 _SpawnShooterDir;
    private void Start()
    {
        _controller = GetComponent<CharacterController2D>();
       //_positionShoot.Find("Shoot");
       
    }

    private void Update()
    {
        /*
        if(Input.GetKeyDown(KeyCode.Q))
        {
            
            _SelectWeapond = _SelectWeapond + 1;
            CBulletManager.Inst.setWeapon(_SelectWeapond);
            if(_SelectWeapond > 5)
            {
                _SelectWeapond = 1;
            }
        }
        */
        ControlFlip();

        // if(Input.GetKey(KeyCode.X))
        // {
        //         CBulletManager.Inst.Spawn(_positionShoot.position, _SpawnShooterDir,_rote);
        // }
        // Debug.Log(_rote);
        
    }

    private void ControlFlip()
   {
       if(_controller.getFlip().x > 0)
        {
            _rote = 1;
            _SpawnShooterDir = Vector3.right * _vel;
        }
       else if(_controller.getFlip().x<0)
        {
            _rote = -1;
            _SpawnShooterDir = Vector3.right * -_vel;
        } 
    }
 



}
