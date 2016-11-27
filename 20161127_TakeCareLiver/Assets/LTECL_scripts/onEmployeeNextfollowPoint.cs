using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onEmployeeNextfollowPoint : MonoBehaviour {
    public GameObject myFather;
    public int myFathermod;
	// Use this for initialization
	void Start () {
     //   myFather = transform.parent.gameObject;

    }
	
	// Update is called once per frame
	void Update () {
        if (myFather.name == "IamBossVer2") { }
        else {
            myFathermod = myFather.GetComponent<onEmployee>().myMod;
        }
        

    }
}
