using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class onMyMessageBoard : MonoBehaviour {
    public GameObject myMessage_text;
    public GameObject[] myHidShowPoint;
    public float myMoveSpeed;
    public bool isNeedShowSomeMessage;
    public float myHidTimer;
    public float myHidTime;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isNeedShowSomeMessage) {
            transform.position = Vector3.Lerp(transform.position, myHidShowPoint[0].transform.position, Time.deltaTime * myMoveSpeed);
            if (myHidTimer > myHidTime)
            {
                isNeedShowSomeMessage = false;
                myHidTimer = 0;
            }
            else {
                myHidTimer += Time.deltaTime;
            }
        }
        else {
            transform.position = Vector3.Lerp(transform.position, myHidShowPoint[1].transform.position, Time.deltaTime * myMoveSpeed);
        }
	}
    public void mySaySomethingFN(string myMessage) {
        myMessage_text.GetComponent<Text>().text = myMessage;
    }
}
