using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforn : MonoBehaviour
{
    private Vector3 movement;
    public GameObject top;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        movement.y = speed;
        //top = GameObject.Find("TopLine");
    }

    // Update is called once per frame
    void Update()
    {
        movePlatforn();
    }

    private void movePlatforn()
    {
        transform.position += movement * Time.deltaTime;
        if (transform.position.y>top.transform.position.y)
        {
            Destroy(gameObject);
        }
    }
}
