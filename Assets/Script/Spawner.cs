using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> platforms = new List<GameObject>();
    public float spwanTime;
    private float countTime; //记录当前时间
    private Vector3 spwanPos;//随机生成的位置
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpwanPlatform();
    }
    //随机生成的方法
    private  void SpwanPlatform()
    {
        countTime += Time.deltaTime;
        spwanPos = transform.position;
        spwanPos.x = Random.Range(-3.5f, 3.5f);

        if (countTime >= spwanTime)
        {
            CreatPlatform();
            countTime = 0;
        }
        
    }
    
    //生成跳台
    private  void CreatPlatform()
    {
        int index = Random.Range(0, platforms.Count);
        int spikeNum = 0;
        if (index ==4)
        {
            spikeNum++;
        }

        if (spikeNum>1)
        {
            spikeNum = 0;
            countTime = spwanTime;
            return;
        }
        GameObject newPlatform= Instantiate(platforms[index],spwanPos,Quaternion.identity);
        newPlatform.transform.SetParent(this.gameObject.transform);
    }
    
    
    
}
