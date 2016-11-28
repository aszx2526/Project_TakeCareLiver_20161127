using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onMyGameManager : MonoBehaviour {
    [Header("遊戲啟動器")]
    public bool isGameStar;
    [Header("是否展示專案訊息框")]
    public bool isNeedToShowProjectMessage;
    [Header("專案訊息框")]
    public GameObject myProjectMessage;
    [Header("專案訊息框展示點")]
    public GameObject myProjectMessage_show;
    [Header("專案訊息框收起點")]
    public GameObject myProjectMessage_hid;
    [Header("移動速度")]
    public float myMoveSpeed;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isNeedToShowProjectMessage) {
            if (Vector3.Distance(myProjectMessage.transform.position,myProjectMessage_show.transform.position)<5) {
                myProjectMessage.transform.position = myProjectMessage_show.transform.position;
                Vector3 scal = myProjectMessage.GetComponent<RectTransform>().localScale;
                if (scal.x < 1) {
                    Vector3 a;
                    a.x = a.y = a.z = 1.1f;
                    myProjectMessage.GetComponent<RectTransform>().localScale = Vector3.Lerp(myProjectMessage.GetComponent<RectTransform>().localScale, a, Time.deltaTime * myMoveSpeed * 3);
                    //-------
                    /*scal.x += Time.deltaTime * myMoveSpeed * 3;
                    scal.y = scal.x;
                    myProjectMessage.GetComponent<RectTransform>().localScale = scal;*/
                }
                else {
                    scal.x = 1;
                    scal.y = scal.x;
                    myProjectMessage.GetComponent<RectTransform>().localScale = scal;
                }
            }
            else {
                myProjectMessage.transform.position = Vector3.Lerp(myProjectMessage.transform.position, myProjectMessage_show.transform.position, Time.deltaTime * myMoveSpeed*1.3f);
            }
        }
        else {
            Vector3 scal = myProjectMessage.GetComponent<RectTransform>().localScale;
            if (scal.x > 0.1f)
            {
                Vector3 a;
                a.x = a.y = a.z = 0.05f;
                myProjectMessage.GetComponent<RectTransform>().localScale = Vector3.Lerp(myProjectMessage.GetComponent<RectTransform>().localScale, a, Time.deltaTime * myMoveSpeed*3);

                /*scal.x -= Time.deltaTime * myMoveSpeed * 1;
                scal.y = scal.x;
                myProjectMessage.GetComponent<RectTransform>().localScale = scal;*/
            }
            else {
                scal.x = 0.1f;
                scal.y = scal.x;
                myProjectMessage.GetComponent<RectTransform>().localScale = scal;
                if (myProjectMessage.transform.position == myProjectMessage_hid.transform.position) { }
                else {
                    myProjectMessage.transform.position = Vector3.Lerp(myProjectMessage.transform.position, myProjectMessage_hid.transform.position, Time.deltaTime * myMoveSpeed);
                }
            }
        }
	}
    public void BTN_KeepFightFN() {
        isGameStar = true;
        isNeedToShowProjectMessage = false;
    }
}
