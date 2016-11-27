using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class onPlayerTrigger : MonoBehaviour {
    public GameObject myFather;
	// Use this for initialization
	void Start () {
        myFather = transform.parent.gameObject;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "unemployment":
                if (myFather.GetComponent<onMyController>().myCompany.GetComponent<onMyCompany>().myKCounter >= other.GetComponent<onEmployee>().myK)
                {
                    myFather.GetComponent<onMyController>().myCompany.GetComponent<onMyCompany>().myKCounter -= other.GetComponent<onEmployee>().myK;
                    if (other.GetComponent<onEmployee>().myMod == 0)
                    {
                        myFather.GetComponent<onMyController>().myEmployeeCounter++;
                        myFather.GetComponent<onMyController>().mySocial.GetComponent<onSocialForCreatEmployee>().SendMessage("myNoJobManCreaterFN");
                        other.GetComponent<onEmployee>().myID = myFather.GetComponent<onMyController>().myEmployeeCounter;
                        other.GetComponent<onEmployee>().myMod_PeopleOrAnimal[0].SetActive(false);
                        other.GetComponent<onEmployee>().myMod_PeopleOrAnimal[1].SetActive(true);
                        other.name = "Employee_" + other.GetComponent<onEmployee>().myID.ToString();
                        other.GetComponent<BoxCollider>().enabled = false;

                        if (other.GetComponent<onEmployee>().myID == 1)
                        {
                            other.tag = "employee";
                            other.GetComponent<onEmployee>().myTarget = myFather.GetComponent<onMyController>().myEmployeeFollowPoint;
                            other.GetComponent<onEmployee>().myMod = 1;
                            other.GetComponent<onEmployee>().myFollowSpeed = Random.Range(7.0f, 10.0f);
                            other.GetComponent<onEmployee>().myBoss = myFather;
                            other.GetComponent<onEmployee>().myBoard_Liver.GetComponent<onLiverBoard>().myMessage_text.text = "員工" + other.GetComponent<onEmployee>().myID.ToString();
                            other.gameObject.transform.parent = myFather.GetComponent<onMyController>().myCompany.transform;
                            myFather.GetComponent<onMyController>().dis_short_employee = 999;
                            myFather.GetComponent<onMyController>().myTarget = null;
                            myFather.GetComponent<onMyController>().SendMessage("myFindEmployeeFN");
                            myFather.GetComponent<onMyController>().myCompany.GetComponent<onMyCompany>().myProjectDevelopEFF += other.GetComponent<onEmployee>().myProduction;
                        }
                        else {
                            other.tag = "employee";
                            other.GetComponent<onEmployee>().myTarget = GameObject.Find("Employee_" + (other.GetComponent<onEmployee>().myID - 1).ToString()).GetComponent<onEmployee>().myNextFollowPoint;
                            other.GetComponent<onEmployee>().myMod = 1;
                            other.GetComponent<onEmployee>().myFollowSpeed = Random.Range(7.0f, 10.0f);
                            other.GetComponent<onEmployee>().myBoss = myFather;
                            other.GetComponent<onEmployee>().myBoard_Liver.GetComponent<onLiverBoard>().myMessage_text.text = "員工" + other.GetComponent<onEmployee>().myID.ToString();
                            other.gameObject.transform.parent = myFather.GetComponent<onMyController>().myCompany.transform;
                            myFather.GetComponent<onMyController>().dis_short_employee = 999;
                            myFather.GetComponent<onMyController>().myTarget = null;
                            myFather.GetComponent<onMyController>().SendMessage("myFindEmployeeFN");
                            myFather.GetComponent<onMyController>().myCompany.GetComponent<onMyCompany>().myProjectDevelopEFF += other.GetComponent<onEmployee>().myProduction;
                        }
                    }
                }
                else {
                    other.GetComponent<onEmployee>().isNeedToSaySomething = true;
                    other.GetComponent<onEmployee>().myBoard_Liver.GetComponent<onLiverBoard>().myMessage_text.text = "臭廢物！" +"\n"+"連"+ other.GetComponent<onEmployee>().myK.ToString()+"K都付不起";
                }
              
                break;
            case "qkobject":
                if (myFather.GetComponent<onMyController>().isQKTime == false)
                {
                    myFather.GetComponent<onMyController>().myTitle_text.text = "專案進度呢？";
                }
                else {
                    Destroy(other.gameObject);
                    myFather.GetComponent<onMyController>().dis_short_qkobject = 999;
                    myFather.GetComponent<onMyController>().myTarget = null;
                    myFather.GetComponent<onMyController>().SendMessage("myFindQKObjectFN");
                    if (myFather.GetComponent<onMyController>().speed < 40) { myFather.GetComponent<onMyController>().speed += 4; }
                    else { }
                }
                break;
            case "airticket":
                myFather.GetComponent<onMyController>().isQKTime = true;

                //other.GetComponent<onAirTickets>()
                Instantiate(other.GetComponent<onAirTickets>().myQKTimePlace, other.GetComponent<onAirTickets>().myQKTimeSpawnPoint.transform.position, other.GetComponent<onAirTickets>().myQKTimeSpawnPoint.transform.rotation);
                //Instantiate(other.GetComponent<onAirTickets>().myQKTimePlace, other.transform.position, other.transform.rotation);
                myFather.GetComponent<onMyController>().dis_short_qkobject = 999;
                myFather.GetComponent<onMyController>().myTarget = null;
                myFather.GetComponent<onMyController>().SendMessage("myFindQKObjectFN");
                
                Destroy(other.gameObject);
                break;
            case "money":
                //myMoneyCounterFN
                //GameObject.Find("myobjectCreater").GetComponent<onSocialForCreatEmployee>().SendMessage("myMoneyCounterFN");
                //myFather.GetComponent<onMyController>().myCompany.GetComponent<onMyCompany>().myCompanyMoney += other.GetComponent<onMoney>().myMoneyValue;
                GameObject.Find("myobjectCreater").GetComponent<onSocialForCreatEmployee>().myMoneyCounter--;
                myFather.GetComponent<onMyController>().myCompany.GetComponent<onMyCompany>().myKCounter++;
                Destroy(other.gameObject);
                break;
            default:
                break;
        }
    }
    void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {
            case "qkobject":
                myFather.GetComponent<onMyController>().myTitle_text.text = myFather.GetComponent<onMyController>().myTitle_string;
                break;
            default:
                break;
        }
    }
}
