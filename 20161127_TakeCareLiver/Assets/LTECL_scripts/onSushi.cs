using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onSushi : MonoBehaviour {
    [Header("旋轉速度")]
    public float myRollSpeed;

	// Use this for initialization
	void Start () {
        myRollSpeed = Random.Range(0.9f, 1.9f);

    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, myRollSpeed, 0));
	}
}
