using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanPlatforn : MonoBehaviour
{
    private Animator _animator;
   
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            _animator.Play("FanPlatform_run");
        }
    }
}
