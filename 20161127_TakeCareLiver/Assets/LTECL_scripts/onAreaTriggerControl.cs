using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onAreaTriggerControl : MonoBehaviour {
    public string myAreaName;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        switch (myAreaName) {
            case "qkarea":
                switch (other.tag)
                {
                    case "boss":
                        print("老闆來QK！");
                        break;
                    case "employee":
                        print("員工進場QK");
                        other.GetComponent<onEmployeePoint>().myFather.GetComponent<onEmployee>().myMod_PeopleOrAnimal[1].SetActive(false);
                        other.GetComponent<onEmployeePoint>().myFather.GetComponent<onEmployee>().myMod_PeopleOrAnimal[3].SetActive(true);
                        other.GetComponent<onEmployeePoint>().myFather.GetComponent<onEmployee>().myMod = 3;
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
    }
    void OnTriggerExit(Collider other)
    {
        switch (myAreaName)
        {
            case "qkarea":
                switch (other.tag)
                {
                    case "boss":
                        print("老闆掰！");
                        break;
                    case "employee":
                        print("員工掰");
                        other.GetComponent<onEmployeePoint>().myFather.GetComponent<onEmployee>().myMod_PeopleOrAnimal[1].SetActive(true);
                        other.GetComponent<onEmployeePoint>().myFather.GetComponent<onEmployee>().myMod_PeopleOrAnimal[3].SetActive(false);
                        other.GetComponent<onEmployeePoint>().myFather.GetComponent<onEmployee>().myMod = 1;
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
    }

}
