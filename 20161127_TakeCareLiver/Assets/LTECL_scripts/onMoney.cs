using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onMoney : MonoBehaviour {
    [Header("金錢看板(生)")]
    public GameObject myTicket_boart;
    [Header("金錢看板(存)")]
    public GameObject myTicket_boart_save;
    [Header("多少錢")]
    public int myMoneyValue;
    
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
    }
}
