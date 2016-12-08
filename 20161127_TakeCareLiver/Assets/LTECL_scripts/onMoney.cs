using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onMoney : MonoBehaviour {
    [Header("K數")]
    public int myKValue;
    public GameObject myTarget;
    public float myMoveSpeed;
    // Use this for initialization
    void Start()
    {
        //myQKTimeSpawnPoint = GameObject.Find("QKPlaceSpawnPoint");
    /*    myTicket_boart_save = Instantiate(myTicket_boart) as GameObject;
        myTicket_boart_save.transform.parent = GameObject.Find("Canvas").GetComponent<onCanvas>().myAirTicketManager.transform;
        myTicket_boart_save.GetComponent<onAirticketBoard>().myBoardtarget = this.gameObject;
        myTicket_boart_save.GetComponent<onAirticketBoard>().Offset.y = 30;*/
    }

    // Update is called once per frame
    void Update()
    {
        if (myTarget) {
            transform.position = Vector3.Lerp(transform.position, myTarget.transform.position, Time.deltaTime * myMoveSpeed);
        }
    }
}
