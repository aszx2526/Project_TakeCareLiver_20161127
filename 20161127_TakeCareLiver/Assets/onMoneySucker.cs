using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onMoneySucker : MonoBehaviour {
    public GameObject myFather;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other) {
        switch (other.tag) {
            case "money":
                other.GetComponent<onMoney>().myTarget = myFather;
                other.GetComponent<onMoney>().myMoveSpeed = Random.Range(5.0f, 8.0f);
                break;
            default:
                break;
        }
    }
}
