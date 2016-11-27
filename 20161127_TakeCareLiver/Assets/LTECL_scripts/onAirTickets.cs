using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class onAirTickets : MonoBehaviour {
    [Header("機票Title")]
    public string myFlyTarget_string;
    [Header("機票看板(生)")]
    public GameObject myTicket_boart;
    [Header("機票看板(生)")]
    public GameObject myTicket_boart_save;
    [Header("機票種類")]
    public int myKindOfAirTicket;//0=日本
    [Header("自我轉速")]
    public float myRollSpeed;
    public GameObject myQKTimePlace;
    public GameObject myQKTimeSpawnPoint;


    // Use this for initialization
    void Start () {
        myQKTimeSpawnPoint = GameObject.Find("QKPlaceSpawnPoint");
        myRollSpeed = Random.Range(0.0f, 1.5f);
        myTicket_boart_save = Instantiate(myTicket_boart) as GameObject;
        myTicket_boart_save.transform.parent = GameObject.Find("Canvas").GetComponent<onCanvas>().myAirTicketManager.transform;
        myTicket_boart_save.GetComponent<onAirticketBoard>().myBoardtarget = this.gameObject;
        myTicket_boart_save.GetComponent<onAirticketBoard>().Offset.y = 30;
        myTicket_boart_save.GetComponent<onAirticketBoard>().myAirTicket_text.text = "飛往"+myFlyTarget_string+"的機票";
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, myRollSpeed, 0));
	}
}
