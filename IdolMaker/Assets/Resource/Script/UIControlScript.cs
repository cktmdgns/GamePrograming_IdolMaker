using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIControlScript : MonoBehaviour {

    public static UIControlScript instance;
    public void Awake()
    {
        UIControlScript.instance = this;
    }

    public PlayerScript playerScript = null;
    public Text Text_Scale = null;
    public Text Text_Score = null;
    public Text Text_Money = null;

    public GameObject Panel_Management = null;
    public GameObject Scout = null;
    public GameObject Training = null;
    public GameObject Release = null;
    public GameObject Popup = null;


    void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        Text_Scale.text = System.Convert.ToString(playerScript.myScale);
        Text_Score.text = System.Convert.ToString(playerScript.score);
        Text_Money.text = System.Convert.ToString(playerScript.money);
    }


    

}
