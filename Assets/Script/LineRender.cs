using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRender : MonoBehaviour
{
    private LineRenderer _lineRendererl;

    public Transform _starpos;

    public Transform _endpos;
    // Start is called before the first frame update
    void Start()
    {
        _lineRendererl = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _lineRendererl.SetPosition(0, _starpos.position);
        
        _lineRendererl.SetPosition(1,_endpos.position);
    }
}
