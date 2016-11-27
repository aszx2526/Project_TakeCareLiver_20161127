using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class onAirticketBoard : MonoBehaviour {
    public GameObject myBoardtarget;
    public Image myAirTicket_BG;
    public Text myAirTicket_text;
    public Vector3 Offset;
    // Use this for initialization
    void Start()
    {
        myAirTicket_BG = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myBoardtarget.gameObject) { myAirTicket_BG.transform.position = Camera.main.WorldToScreenPoint(myBoardtarget.transform.position) + Offset; }
        else { Destroy(gameObject); }
    }
}
