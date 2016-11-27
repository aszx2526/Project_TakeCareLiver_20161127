using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class onMyCompany : MonoBehaviour {
    public Text myEmployeeCount_text;
    [Header("公司資本額")]
    public float myCompanyValue;
    [Header("公司流動資金")]
    public float myCompanyMoney;
    [Header("公司資金條")]
    public Image myCompanyMoney_image;
    [Header("專案研發代號")]
    public int myProjectID;
    [Header("專案研發標題")]
    public Text myProjectTitle_text;
    [Header("專案研發效率")]
    public float myProjectDevelopEFF;
    [Header("專案研發效率條")]
    public Image myProjectDevelopEFF_image;
    // Use this for initialization
    void Start () { 
		
	}
	
	// Update is called once per frame
	void Update () {
        //計算研發進度
        myProjectTitle_text.text = "Project" + myProjectID.ToString()+"_研發進度";
        if (myProjectDevelopEFF_image.fillAmount == 1){
            //賺錢囉！
            myCompanyMoney += 20;
            //把研發進度條歸零，要研發新的產品了
            myProjectDevelopEFF_image.fillAmount = 0;
            //專案代號+1
            myProjectID++;
            //講一句屁話
            print("產品" + myProjectID.ToString() + "研發好了");
        }
        else {myProjectDevelopEFF_image.fillAmount += Time.deltaTime * myProjectDevelopEFF;}

        //計算員工數量
        int chilecount = transform.GetChildCount();
        myEmployeeCount_text.text = "員工人數：" + chilecount.ToString();

        //公司資金檢查
        if (myCompanyMoney_image.fillAmount == 0) {
            print("公司倒閉囉～");
        }
        else {
            if (myCompanyMoney > myCompanyValue)
            {
                myCompanyValue = myCompanyMoney;
            }
            myCompanyMoney -= Time.deltaTime;
            myCompanyMoney_image.fillAmount = (float)myCompanyMoney / (float)myCompanyValue;
        }

        
    }
}
