using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class onMyController : MonoBehaviour {

    [Header("員工數量統計")]
    public int myEmployeeCounter;
    [Header("我的公司")]
    public GameObject myCompany;
    [Header("我的Title_字串")]
    public string myTitle_string;
    [Header("我的Title_text")]
    public Text myTitle_text;
    [Header("我的員工跟隨點")]
    public GameObject myEmployeeFollowPoint;
    [Header("社會")]
    public GameObject mySocial;
    [Header("待業中的勞工")]
    public GameObject[] findallunEmployment;
    [Header("自動獵才")]
    public bool isAutoHuntPeople;
    [Header("自動獵才_toggle")]
    public Toggle isAutoHuntPeople_toggle;
    [Header("出國囉！")]
    public bool isQKTime;
    [Header("休息物件清單")]
    public GameObject[] findallqkobject;

    //---------
    [Header("自動往前")]
    public bool isAutoMoveForword;
    [Header("自動轉向控制清單")]
    public GameObject[] myAutoMove_targetRotation;
    [Header("移動判定")]
    public int myMoveMod;
    //---------

    public float speed = 10.0F;
    public float rotationSpeed = 100.0F;
    public GameObject myTarget;
    public float dis_short_employee;
    public float dis_short_qkobject;
    // Use this for initialization
    void Start () {
        myTitle_text.text = myTitle_string;
        dis_short_employee = 999;
        dis_short_qkobject = 999;
        //myFindEmployeeFN();
    }
	
	// Update is called once per frame
	void Update () {
        myEmployeeFollowPoint.transform.rotation = gameObject.transform.rotation;

        if (isAutoHuntPeople_toggle.isOn)
        {//開始獵才
            if (isQKTime)
            {
                if (findallqkobject.Length == 0)
                {
                    speed = 8;
                    isQKTime = false;
                }
                if (myTarget == null) { myFindQKObjectFN(); }
                else {
                    transform.LookAt(myTarget.transform);
                    //transform.position = Vector3.Lerp(transform.position, myTarget.transform.position, Time.deltaTime * speed);
                    transform.position = Vector3.MoveTowards(transform.position, myTarget.transform.position, Time.deltaTime * speed);
                }
            }
            else {
                //------
                if (findallunEmployment.Length == 0|| myTarget == null) { myFindEmployeeFN(); }
                if (myTarget != null)
                {
                    transform.LookAt(myTarget.transform);
                    //transform.position = Vector3.Lerp(transform.position, myTarget.transform.position, Time.deltaTime * speed);
                    transform.position = Vector3.MoveTowards(transform.position, myTarget.transform.position, Time.deltaTime * speed);
                }
                //-----
            }
            
        }
        else {
            if (isQKTime)
            {
                if (findallqkobject.Length == 0)
                {
                    speed = 8;
                    isQKTime = false;
                }
                if (myTarget == null) { myFindQKObjectFN(); }
                else {
                    transform.LookAt(myTarget.transform);
                    //transform.position = Vector3.Lerp(transform.position, myTarget.transform.position, Time.deltaTime * speed);
                    transform.position = Vector3.MoveTowards(transform.position, myTarget.transform.position, Time.deltaTime * speed);
                }
            }
            else {
                if (isAutoMoveForword)
                {
                    myAutoMoveForwordFN();
                    myInputFN();
                }
                else { myControllFN(); }
            }
        }
    }
    public void myControllFN() {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
        //if(Input)
    }
    public void myInputFN() {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) { myMoveMod = 0; }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) { myMoveMod = 1; }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) { myMoveMod = 2; }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) { myMoveMod = 3; }
        //GameObject.Find("myTouchControlManager").GetComponent<myTouchControlManager>().m
    }
    public void myFingerMoveWayFN_up() { myMoveMod = 2; }
    public void myFingerMoveWayFN_down() { myMoveMod = 3; }
    public void myFingerMoveWayFN_left() { myMoveMod = 1; }
    public void myFingerMoveWayFN_righ() { myMoveMod = 0; }
    public void myAutoMoveForwordFN() {
        switch (myMoveMod) {
            case 0:
                transform.Translate(0, 0, speed * 0.025f);
                transform.rotation = myAutoMove_targetRotation[0].transform.rotation;
                break;
            case 1:
                transform.Translate(0, 0, speed * 0.025f);
                transform.rotation = myAutoMove_targetRotation[1].transform.rotation;
                break;
            case 2:
                transform.Translate(0, 0, speed * 0.025f);
                transform.rotation = myAutoMove_targetRotation[2].transform.rotation;
                break;
            case 3:
                transform.Translate(0, 0, speed*0.8f * 0.025f);
                transform.rotation = myAutoMove_targetRotation[3].transform.rotation;
                break;
            default:
                break;
        }
    }
    //找尋人才，並且找到距離我最近的人才
    public void myFindEmployeeFN()
    {
        findallunEmployment = GameObject.FindGameObjectsWithTag("unemployment");
        for (int a = 0; a < findallunEmployment.Length; a++)
        {
            if (Vector3.Distance(findallunEmployment[a].transform.position, transform.position) < dis_short_employee)
            {
                dis_short_employee = Vector3.Distance(findallunEmployment[a].transform.position, transform.position);
                findallunEmployment[a].GetComponent<onEmployee>().myDisWithBoss = dis_short_employee;
            }
        }
        for (int b = 0; b < findallunEmployment.Length; b++)
        {
            if (findallunEmployment[b].GetComponent<onEmployee>().myDisWithBoss == dis_short_employee)
            {
                myTarget = findallunEmployment[b];
            }
        }
    }
    //找尋人才，並且找到距離我最近的人才
    public void myFindQKObjectFN()
    {
        dis_short_qkobject = 999;
        findallqkobject = GameObject.FindGameObjectsWithTag("qkobject");
        for (int a = 0; a < findallqkobject.Length; a++)
        {
            if (Vector3.Distance(findallqkobject[a].transform.position, transform.position) < dis_short_qkobject)
            {
                dis_short_qkobject = Vector3.Distance(findallqkobject[a].transform.position, transform.position);
                findallqkobject[a].GetComponent<onQKObject>().myDisWithBoss = dis_short_qkobject;
            }
        }
        for (int b = 0; b < findallqkobject.Length; b++)
        {
            if (findallqkobject[b].GetComponent<onQKObject>().myDisWithBoss == dis_short_qkobject)
            {
                myTarget = findallqkobject[b];
            }
        }
    }
    /*
    public void AutoHuntPeopleFN()
    {
        if (findallunEmployment.Length == 0) { myFindEmployeeFN(); }
        if (myTarget != null)
        {
            transform.LookAt(myTarget.transform);
            //transform.position = Vector3.Lerp(transform.position, myTarget.transform.position, Time.deltaTime * speed);
            transform.position = Vector3.MoveTowards(transform.position, myTarget.transform.position, Time.deltaTime * speed);
        }
    }
    */
}
