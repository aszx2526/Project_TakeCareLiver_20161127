using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onMoneyForRotate : MonoBehaviour {
    [Header("自我轉速")]
    public float myRollSpeed;
    // Use this for initialization
    void Start()
    {
        //myQKTimeSpawnPoint = GameObject.Find("QKPlaceSpawnPoint");
        myRollSpeed = Random.Range(0.1f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, myRollSpeed, 0));
    }
}
