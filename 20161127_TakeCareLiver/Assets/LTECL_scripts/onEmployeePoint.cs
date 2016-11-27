using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onEmployeePoint : MonoBehaviour {
    public GameObject myFather;
    // Use this for initialization
    void Start () {
        myFather = transform.parent.gameObject;
    }
	
	// Update is called once per frame
	void Update () {

	}
}
