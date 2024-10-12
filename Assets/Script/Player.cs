using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    private Rigidbody2D rd;
    private Animator _animator;
   public float _speed;
    private float xVelocity;
    public bool _isGround;
    public float checkRadius; //检测范围
    public LayerMask platform; //检测得图层
    public GameObject grundCheck; //地面
    public bool _playerdead;
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //为当前物体画一个圆检测是否在地面
        _isGround = Physics2D.OverlapCircle(grundCheck.transform.position, checkRadius, platform);
        _animator.SetBool("isGrund",_isGround);
        Movement();
    }

    private void Movement()
    {
        xVelocity = Input.GetAxisRaw("Horizontal");
        rd.velocity = new Vector2(xVelocity*_speed ,rd.velocity.y);
        _animator.SetFloat("speed",Mathf.Abs(rd.velocity.x));
        if (xVelocity!=0)
        {
            transform.localScale = new Vector3(xVelocity, 1, 1);
        }
        
    }

    private void PlayerDead()
    {
        _playerdead = true;
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Fan"))
        {
            rd.velocity = new Vector2(rd.velocity.x, 7.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Splike"))
        {
            _animator.SetTrigger("dead");
           
        }
    }

   
}
