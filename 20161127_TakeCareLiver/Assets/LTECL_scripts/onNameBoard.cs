using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class onNameBoard : MonoBehaviour {
    public GameObject target;
    public Text ShowNameText;
    public Vector3 Offset;
    // Use this for initialization
    void Start()
    {
        ShowNameText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target.gameObject){ShowNameText.transform.position = Camera.main.WorldToScreenPoint(target.transform.position) + Offset;}
        else{Destroy(gameObject);}
    }
}
