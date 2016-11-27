using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onHappyTimeEmployee : MonoBehaviour {
    public float myUpdownSpeed;
    public float myTimer;
    public float myTimerTarget;
    // Use this for initialization
    void Start () {
        myTimerTarget = 0.5f;
        //myUpdownSpeed = Random.Range(0.1f, 1.6f);
        myUpdownSpeed = Random.Range(0.01f, 0.1f);
    }
	
	// Update is called once per frame
	void Update () {
        if (myTimer < myTimerTarget)
        {
            myTimer += Time.deltaTime;
            transform.Translate(new Vector3(0, +myUpdownSpeed, 0));
        }
        else if (myTimer > myTimerTarget && myTimer < myTimerTarget*2)
        {
            myTimer += Time.deltaTime;
            transform.Translate(new Vector3(0, -myUpdownSpeed, 0));
        }
        else { myTimer = 0; }
	}
}
