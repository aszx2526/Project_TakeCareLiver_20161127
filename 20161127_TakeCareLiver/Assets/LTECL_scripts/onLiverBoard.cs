using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class onLiverBoard : MonoBehaviour {
    public GameObject target;
    public Text ShowNameText;
    public Text myMessage_text;
    public Vector3 Offset;
    [Header("我的肝")]
    public Image myLiver_Red_image;
    public Image myLiver_Black_image;
    public Color myLiver_Color;
    public float r;
    public float g;
    public float b;
    public float a;

    // Use this for initialization
    void Start()
    {
        ShowNameText = GetComponent<Text>();
       // myLiver_Color = myLiver_Black_image.color;
    }

    // Update is called once per frame
    void Update()
    {
        /*  r = myLiver_Color.r;
          g = myLiver_Color.g;
          b = myLiver_Color.b;
          a = myLiver_Color.a;*/
        //myLiver_image.color = myLiver_Color;
        if (target.gameObject)
        {
            if (target.GetComponent<onEmployee>().myMod == 2)
            {
                this.gameObject.SetActive(false);
            }
            ShowNameText.transform.position = Camera.main.WorldToScreenPoint(target.transform.position) + Offset;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}
