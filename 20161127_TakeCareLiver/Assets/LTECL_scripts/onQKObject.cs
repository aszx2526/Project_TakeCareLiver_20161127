using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onQKObject : MonoBehaviour {
    [Header("娛樂設施清單")]
    public GameObject[] myQKObjectList;
    [Header("娛樂設施清單亂數")]
    public int myQKObjectrandom;
    [Header("我與老闆的距離")]
    public float myDisWithBoss;

    // Use this for initialization
    void Start()
    {
        myQKObjectrandom = Random.Range(0, 2);
        if (myQKObjectrandom == 0)
        {
            myQKObjectList[0].SetActive(true);
            myQKObjectList[1].SetActive(false);
        }
        else {
            myQKObjectList[0].SetActive(false);
            myQKObjectList[1].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
