using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
    private Vector2 movement;
    public Vector2 sleep;
    private Material _material;
    // Start is called before the first frame update
    void Start()
    {
        _material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        movement += sleep*Time.deltaTime;
        Debug.Log(movement);
        _material.mainTextureOffset = movement;


    }
}
