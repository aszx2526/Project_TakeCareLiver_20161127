using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LTECL_CameraFollow : MonoBehaviour {
    [Header("我的跟隨目標")]
    public GameObject myFollowTarget;
    [Header("我的跟隨速度")]
    public float myFollowSpeed;
    [Header("是否跟隨")]
    public bool isNeedFollow;
    [Header("是否相同面相")]
    public bool isNeedRotation;
    [Header("我的攝影機")]
    public GameObject myMainCamera;
    [Header("攝影點清單")]
    public GameObject[] myCameraPointList;
    public GameObject myCameraLookAtTarget;
    [Header("攝影機移動速度")]
    public float myCamearMoveSpeed;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isNeedFollow) { transform.position = Vector3.Lerp(transform.position, myFollowTarget.transform.position, Time.deltaTime * myFollowSpeed); }
        if (isNeedRotation) { transform.rotation = Quaternion.Lerp(transform.rotation, myFollowTarget.transform.rotation, Time.deltaTime * myFollowSpeed); }
        /*
        if (myFollowTarget.GetComponent<onMyController>().isQKTime) {
            if (myFollowTarget.GetComponent<onMyController>().speed < 30)
            {
                myMainCamera.transform.position = Vector3.Lerp(myMainCamera.transform.position, myCameraPointList[1].transform.position, Time.deltaTime * myCamearMoveSpeed);
                myMainCamera.transform.LookAt(myCameraLookAtTarget.transform);
            }
            else {
                myMainCamera.transform.position = Vector3.Lerp(myMainCamera.transform.position, myCameraPointList[0].transform.position, Time.deltaTime * myCamearMoveSpeed);
                myMainCamera.transform.LookAt(myFollowTarget.transform);
            }
            
        }
        else {
            myMainCamera.transform.position = Vector3.Lerp(myMainCamera.transform.position, myCameraPointList[0].transform.position, Time.deltaTime * myCamearMoveSpeed);
            myMainCamera.transform.LookAt(myFollowTarget.transform);
        }*/
	}
}
