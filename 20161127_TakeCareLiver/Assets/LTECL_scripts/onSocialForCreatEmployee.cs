using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class onSocialForCreatEmployee : MonoBehaviour {
    public GameObject myNoJobMan;
    public GameObject myAirTicket;
    public GameObject myMoney;
    public GameObject[] myMoneyList;
    public bool isNeedCreatMoney;
    // Use this for initialization
    void Start () {
        myNoJobManCreaterFN();
        myMoneyCounterFN();
        //GameObject.FindGameObjectWithTag("boss").GetComponent<onMyController>().SendMessage("myFindEmployeeFN");
    }
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("unemployment") == null) { myNoJobManCreaterFN(); }
        //myMoneyCounterFN();
	}
    public void myMoneyCounterFN() {
        myMoneyList = GameObject.FindGameObjectsWithTag("money");
        if (myMoneyList.Length < 50) {
            myMoneyCreater_FN();
        }
    }
    public void myNoJobManCreaterFN() {
        int a = Random.Range(0, 11);
        if (a > 9)
        {
            int airticketrandom = Random.Range(0, 101);
            if (airticketrandom > 80&&GameObject.FindGameObjectWithTag("airticket") == false) {
                Vector3 airticketspawnPoint = gameObject.transform.position;
                airticketspawnPoint.y = 0.75f;
                airticketspawnPoint.x = Random.Range(airticketspawnPoint.x - gameObject.transform.localScale.x / 2 * 0.9f, airticketspawnPoint.x + gameObject.transform.localScale.x / 2 * 0.9f);
                airticketspawnPoint.z = Random.Range(airticketspawnPoint.z - gameObject.transform.localScale.z / 2 * 0.9f, airticketspawnPoint.z + gameObject.transform.localScale.z / 2 * 0.9f);
                Instantiate(myAirTicket, airticketspawnPoint, gameObject.transform.rotation);
                GameObject.Find("myMessageBoard").GetComponent<onMyMessageBoard>().isNeedShowSomeMessage = true;
                GameObject.Find("myMessageBoard").GetComponent<onMyMessageBoard>().mySaySomethingFN("有機票耶！" + "\n" + "希望能出國QAQ");
            }
            for (int b = 0; b < 3; b++)
            {
                Vector3 spawnPoint = gameObject.transform.position;
                spawnPoint.y = 0.75f;
                spawnPoint.x = Random.Range(spawnPoint.x - gameObject.transform.localScale.x / 2 * 0.9f, spawnPoint.x + gameObject.transform.localScale.x / 2 * 0.9f);
                spawnPoint.z = Random.Range(spawnPoint.z - gameObject.transform.localScale.z / 2 * 0.9f, spawnPoint.z + gameObject.transform.localScale.z / 2 * 0.9f);
                GameObject unemployment =  Instantiate(myNoJobMan, spawnPoint, gameObject.transform.rotation)as GameObject;
                unemployment.name = "unemployment";
            }
        }
        else if (a < 9 && a > 7)
        {
            
            int airticketrandom = Random.Range(0, 101);
            if (airticketrandom > 80&&GameObject.FindGameObjectWithTag("airticket") == false) {
                Vector3 airticketspawnPoint = gameObject.transform.position;
                airticketspawnPoint.y = 0.75f;
                airticketspawnPoint.x = Random.Range(airticketspawnPoint.x - gameObject.transform.localScale.x / 2 * 0.9f, airticketspawnPoint.x + gameObject.transform.localScale.x / 2 * 0.9f);
                airticketspawnPoint.z = Random.Range(airticketspawnPoint.z - gameObject.transform.localScale.z / 2 * 0.9f, airticketspawnPoint.z + gameObject.transform.localScale.z / 2 * 0.9f);
                Instantiate(myAirTicket, airticketspawnPoint, gameObject.transform.rotation);
                GameObject.Find("myMessageBoard").GetComponent<onMyMessageBoard>().isNeedShowSomeMessage = true;
                //GameObject.Find("myMessageBoard").GetComponent<onMyMessageBoard>().myMessage_text.GetComponent<Text>().text = "有機票耶！" + "\n" + "希望能出國QAQ";
                GameObject.Find("myMessageBoard").GetComponent<onMyMessageBoard>().mySaySomethingFN("有機票耶！" + "\n" + "希望能出國QAQ");
            }
            Vector3 spawnPoint = gameObject.transform.position;
            spawnPoint.y = 0.75f;
            spawnPoint.x = Random.Range(spawnPoint.x - gameObject.transform.localScale.x / 2 * 0.9f, spawnPoint.x + gameObject.transform.localScale.x / 2 * 0.9f);
            spawnPoint.z = Random.Range(spawnPoint.z - gameObject.transform.localScale.z / 2 * 0.9f, spawnPoint.z + gameObject.transform.localScale.z / 2 * 0.9f);
            Instantiate(myNoJobMan, spawnPoint, gameObject.transform.rotation);
            GameObject unemployment = Instantiate(myNoJobMan, spawnPoint, gameObject.transform.rotation) as GameObject;
            unemployment.name = "unemployment";
        }
    }
    public void myMoneyCreater_FN() {
        for (int a = 0; a < 10; a++) {
            Vector3 spawnPoint = gameObject.transform.position;
            spawnPoint.y = 0.75f;
            spawnPoint.x = Random.Range(spawnPoint.x - gameObject.transform.localScale.x / 2 * 0.9f, spawnPoint.x + gameObject.transform.localScale.x / 2 * 0.9f);
            spawnPoint.z = Random.Range(spawnPoint.z - gameObject.transform.localScale.z / 2 * 0.9f, spawnPoint.z + gameObject.transform.localScale.z / 2 * 0.9f);
            Instantiate(myMoney, spawnPoint, gameObject.transform.rotation);
        }
    }
}
