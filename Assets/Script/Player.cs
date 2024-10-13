using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.EventSystems;
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
    public Button R, L;
    
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        AddEventTrigger(R, EventTriggerType.PointerDown, () => xVelocity = -1); // R按下，xVelocity = -1
        AddEventTrigger(R, EventTriggerType.PointerUp, () => xVelocity = 0);    // R抬起，xVelocity = 0
        AddEventTrigger(L, EventTriggerType.PointerDown, () => xVelocity = 1);  // L按下，xVelocity = 1
        AddEventTrigger(L, EventTriggerType.PointerUp, () => xVelocity = 0);    // L抬起，xVelocity = 0= 0
        // R.onClick.AddListener((() =>
        // {
        //     xVelocity = -1;
        //    
        // }));
        // R.onMouseUp.AddListener(() => {
        //     xVelocity = 0;
        // });
        // L.onClick.AddListener((() =>
        // {
        //     xVelocity = 1;
        //     
        // }));
        // L.onMouseUp.AddListener(() => {
        //     xVelocity = 0;
        // });
        
    }
    void AddEventTrigger(Button button, EventTriggerType triggerType, System.Action action)
    {
        EventTrigger trigger = button.gameObject.AddComponent<EventTrigger>();
        var entry = new EventTrigger.Entry { eventID = triggerType };
        entry.callback.AddListener((eventData) => { action.Invoke(); });
        trigger.triggers.Add(entry);
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
       //  xVelocity = Input.GetAxisRaw("Horizontal");
       // Debug.Log(xVelocity);
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
        GameManager.GameOver(_playerdead);
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
