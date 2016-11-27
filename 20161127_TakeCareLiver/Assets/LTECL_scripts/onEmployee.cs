using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class onEmployee : MonoBehaviour {

    [Header("我的老闆")]
    public GameObject myBoss;
    [Header("我的員工編號")]
    public int myID;
    [Header("我的跟隨目標")]
    public GameObject myTarget;
    [Header("我的跟隨速度")]
    public float myFollowSpeed;
    [Header("我的模式控制")]//0=待業1=就業2=死
    public int myMod;
    [Header("後輩跟隨目標")]
    public GameObject myNextFollowPoint;
   /* [Header("與前輩角度")]
    public float myDegreewithFollowPoint;
    [Header("轉動目標值")]
    public float myDegreeRotaTarget;*/
    [Header("人畜")]
    public GameObject[] myMod_PeopleOrAnimal;//0世人1是處
    [Header("我與老闆的距離")]
    public float myDisWithBoss;
    [Header("看板(生)")]
    public GameObject myNameBoard;
    [Header("狀態看板_")]
    public GameObject myBoard;
    [Header("肝指數看板(生)")]
    public GameObject myLiverBoard;
    [Header("肝指數看板_")]
    public GameObject myBoard_Liver;

    [Header("肝指數")]
    public float myLiverPanel;
    [Header("健康指數(小=好)")]
    public float myHealthyIndex;
    [Header("產能")]
    public float myProduction;
    [Header("升遷次數")]
    public int myUpgradeTimesCounter;
    public float myChangeTime;
    public float myChangeTimer;


    // Use this for initialization
    void Start () {
        myChangeTime = 0.1f;
        myHealthyIndex = Random.Range(0.0f, 1.5f);
        //myNextFollowPoint = transform.GetChild(0).gameObject;
        //肝的健康直
        myLiverPanel = 100;
        

        myMod_PeopleOrAnimal[1].SetActive(false);
        myMod_PeopleOrAnimal[2].SetActive(false);
        myMod_PeopleOrAnimal[3].SetActive(false);
        myBoard = Instantiate(myNameBoard) as GameObject;
        myBoard.transform.parent = GameObject.Find("Canvas").GetComponent<onCanvas>().myEmployeeBoardManager.transform;
        myBoard.GetComponent<onNameBoard>().target = this.gameObject;
        myBoard.GetComponent<onNameBoard>().Offset.y = 40;
        myBoard.GetComponent<Text>().text = "人才22K";

        myBoard_Liver = Instantiate(myLiverBoard) as GameObject;
        myBoard_Liver.transform.parent = GameObject.Find("Canvas").GetComponent<onCanvas>().myEmployeeBoardManager.transform;
        myBoard_Liver.GetComponent<onLiverBoard>().target = this.gameObject;
        myBoard_Liver.GetComponent<onLiverBoard>().Offset.y = 20;
        myBoard_Liver.GetComponent<onLiverBoard>().myLiver_Black_image.fillAmount = 1 - (myLiverPanel / 100);
        //myBoard_Liver.GetComponent<Text>().text = "肝指數："+myLiverPanel.ToString();


    }

    // Update is called once per frame
    void Update () {
        if (myTarget) {
            switch (myMod)
            {
                case 0:
                    break;
                case 1:
                    if (myTarget.GetComponent<onEmployeeNextfollowPoint>().myFather.name == "IamBossVer2")
                    {
                        if (myTarget.GetComponent<onEmployeeNextfollowPoint>().myFather.GetComponent<onMyController>().isQKTime)
                        {
                            if (myChangeTimer > myChangeTime) {
                                myMod = 3;
                                myChangeTimer = 0;
                            }
                            else
                            {
                                myChangeTimer += Time.deltaTime;
                            }
                        }
                    }
                    else if (myTarget.GetComponent<onEmployeeNextfollowPoint>().myFathermod == 2)
                    {
                        //print("mytarget mod = 2");
                        myUpgradeFN();
                    }
                    else if (myTarget.GetComponent<onEmployeeNextfollowPoint>().myFathermod == 3)
                    {
                        if (myChangeTimer > myChangeTime)
                        {
                            myMod = 3;
                            myChangeTimer = 0;
                        }
                        else
                        {
                            myChangeTimer += Time.deltaTime;
                        }
                    }
                    else { }
                    myMod_PeopleOrAnimal[1].SetActive(true);
                    myMod_PeopleOrAnimal[3].SetActive(false);
                    myEmployeeMoveFN();
                    LiverPanelCheckFN();
                    break;
                case 2:
                    /* print("case 2 be call");
                     myLiverBoard.GetComponent<onLiverBoard>().myLiver_Color.a = 0;
                     myLiverBoard.GetComponent<onLiverBoard>().myLiver_Black_image.color = myLiverBoard.GetComponent<onLiverBoard>().myLiver_Color;
                     myLiverBoard.GetComponent<onLiverBoard>().myLiver_Red_image.color = myLiverBoard.GetComponent<onLiverBoard>().myLiver_Color;*/
                    //myLiverBoard.SetActive(false);
                    break;
                case 3:
                    myLiverPanel += Time.deltaTime * myHealthyIndex * 10;
                    myBoard_Liver.GetComponent<onLiverBoard>().myLiver_Black_image.fillAmount = 1 - (myLiverPanel / 100);
                    if (myTarget.GetComponent<onEmployeeNextfollowPoint>().myFather.name == "IamBossVer2") {
                        if (myTarget.GetComponent<onEmployeeNextfollowPoint>().myFather.GetComponent<onMyController>().isQKTime == false)
                        {
                            if (myChangeTimer > myChangeTime)
                            {
                                myMod = 1;
                                myChangeTimer = 0;
                            }
                            else
                            {
                                myChangeTimer += Time.deltaTime;
                            }
                        }
                    }
                    else if (myTarget.GetComponent<onEmployeeNextfollowPoint>().myFathermod == 2)
                    {
                        //print("mytarget mod = 2");
                        myUpgradeFN();
                    }
                    else if(myTarget.GetComponent<onEmployeeNextfollowPoint>().myFathermod == 1) {
                        if (myChangeTimer > myChangeTime)
                        {
                            myMod = 1;
                            myChangeTimer = 0;
                        }
                        else
                        {
                            myChangeTimer += Time.deltaTime;
                        }
                    }
                    myMod_PeopleOrAnimal[1].SetActive(false);
                    myMod_PeopleOrAnimal[3].SetActive(true);
                    myEmployeeMoveFN();
                    break;
                default:
                    break;
            }
        }
        //if (isNeedToFollow && Input.anyKey)
      
	}
    public void myEmployeeMoveFN() {
        if (Vector3.Distance(transform.position, myTarget.transform.position) > 0.2)
        {
            transform.position = Vector3.Lerp(transform.position, myTarget.transform.position, Time.deltaTime * myFollowSpeed);
            /* if (Quaternion.Angle(transform.rotation, myTarget.transform.rotation) > myDegreeRotaTarget) {
                 //transform.rotation = Quaternion.Lerp(transform.rotation, myTarget.transform.rotation, Time.deltaTime*0.1f);
             }*/
            //transform.rotation = Quaternion.Lerp(transform.rotation, myTarget.transform.rotation, Time.deltaTime*myFollowSpeed);
            transform.LookAt(myTarget.transform);
            // myDegreewithFollowPoint = Quaternion.Angle(transform.rotation, myTarget.transform.rotation);
        }
    }
    public void LiverPanelCheckFN() {
        myBoard.GetComponent<Text>().text = "";
        myBoard_Liver.GetComponent<Text>().text = "";
        if (myLiverPanel < 10) {
            myMod = 2;
            myMod_PeopleOrAnimal[1].SetActive(false);
            myMod_PeopleOrAnimal[2].SetActive(true);
            myLiverUpdaetFN();
        }
        else if (myLiverPanel < 30)
        {
            myLiverUpdaetFN();
        }
        else if (myLiverPanel < 50)
        {
            myLiverUpdaetFN();
        }
        else {
            myLiverUpdaetFN();
        }
    }
    public void myLiverUpdaetFN() {
        //myBoard_Liver.GetComponent<onLiverBoard>().myLiver_Color.r = myLiverPanel / 100;
        //myBoard.GetComponent<Text>().text = "員工" + myID.ToString() + "(肝不好)";
        myLiverPanel -= Time.deltaTime * myHealthyIndex;
        //myBoard_Liver.GetComponent<Text>().text = "肝指數：" + myLiverPanel.ToString();
        myBoard_Liver.GetComponent<onLiverBoard>().myLiver_Black_image.fillAmount = 1 - (myLiverPanel / 100);//myBoard_Liver.GetComponent<onLiverBoard>().myLiver_Color;
    }
    public void myUpgradeFN() {
        //print("myUpgradeFN be call");
        myUpgradeTimesCounter++;
        if (myID - myUpgradeTimesCounter < 1) {
            myTarget = myBoss.GetComponent<onMyController>().myEmployeeFollowPoint;
        }
        else {
            myTarget = GameObject.Find("Employee_" + (myID - myUpgradeTimesCounter).ToString()).GetComponent<onEmployee>().myNextFollowPoint;
        }
        
    }
}
