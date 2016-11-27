using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onQKSystem : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("IamBossVer2").GetComponent<onMyController>().isQKTime == false) {
            Destroy(this.gameObject);
        }
	}
}
