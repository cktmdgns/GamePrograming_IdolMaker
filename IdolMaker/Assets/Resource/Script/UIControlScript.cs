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
    public GameObject PopUpMessage = null;

    public GameObject ScrollDetail1 = null;
    public GameObject ScrollDetail2 = null;

    public GameObject image_SellectCharacter = null;


    void Update()
    {
        Text_Scale.text = System.Convert.ToString(playerScript.myScale);
        Text_Score.text = System.Convert.ToString(playerScript.score);
        Text_Money.text = System.Convert.ToString(playerScript.money);

        if(playerScript.score > 8000000)
        {
            playerScript.myScale = PlayerScript.scale.신의손;
        }
        else if (playerScript.score > 1500000)
        {
            playerScript.myScale = PlayerScript.scale.대박치는;
        }
        else if (playerScript.score > 300000)
        {
            playerScript.myScale = PlayerScript.scale.잘나가는;
        }
        else if (playerScript.score > 62500)
        {
            playerScript.myScale = PlayerScript.scale.부끄럽지않은;
        }
        else if (playerScript.score > 12500)
        {
            playerScript.myScale = PlayerScript.scale.그럭저럭인;
        }
        else if (playerScript.score > 2500)
        {
            playerScript.myScale = PlayerScript.scale.굶주리지않는;
        }
        else if (playerScript.score > 500)
        {
            playerScript.myScale = PlayerScript.scale.허름한;
        }
        else if (playerScript.score > 100)
        {
            playerScript.myScale = PlayerScript.scale.하찮은;
        }
        else
        {
            playerScript.myScale = PlayerScript.scale.인지도Zero의;
        }

        if (IdolManagerScript.instance.idolList[GameManagerScript.instance.currentScrollSellectIndex].step >= 6)
        {
            image_SellectCharacter.GetComponent<Image>().sprite = IdolManagerScript.instance.idolList[GameManagerScript.instance.currentScrollSellectIndex].idolImage[2];
        }
        else
        {
            image_SellectCharacter.GetComponent<Image>().sprite = IdolManagerScript.instance.idolList[GameManagerScript.instance.currentScrollSellectIndex].idolImage[IdolManagerScript.instance.idolList[GameManagerScript.instance.currentScrollSellectIndex].step / 3];
        }

        if (UIControlScript.instance.Training.activeSelf == true)
        {
            int money = IdolManagerScript.instance.idolList[GameManagerScript.instance.currentScrollSellectIndex].money;
            int step = IdolManagerScript.instance.idolList[GameManagerScript.instance.currentScrollSellectIndex].step;

            ScrollDetail1.GetComponentsInChildren<Text>()[1].text = IdolManagerScript.instance.idolList[GameManagerScript.instance.currentScrollSellectIndex].idolName;
            ScrollDetail1.GetComponentsInChildren<Text>()[2].text = IdolManagerScript.instance.idolList[GameManagerScript.instance.currentScrollSellectIndex].step + "단계";
            ScrollDetail1.GetComponentsInChildren<Text>()[3].text = ((2 - Mathf.Log10(10 + (step * 3))) * 100).ToString("N2") + "%";
            ScrollDetail1.GetComponentsInChildren<Text>()[4].text = System.Convert.ToInt32( (money + 10) * (0.1 + step * 0.05)) + "$";
        }
        else if (UIControlScript.instance.Release.activeSelf == true)
        {
            int money = IdolManagerScript.instance.idolList[GameManagerScript.instance.currentScrollSellectIndex].money;
            int step = IdolManagerScript.instance.idolList[GameManagerScript.instance.currentScrollSellectIndex].step;

            ScrollDetail2.GetComponentsInChildren<Text>()[1].text = IdolManagerScript.instance.idolList[GameManagerScript.instance.currentScrollSellectIndex].idolName;
            ScrollDetail2.GetComponentsInChildren<Text>()[2].text = step + "단계";
            ScrollDetail2.GetComponentsInChildren<Text>()[3].text = System.Convert.ToInt32((money + 10) * (1 + (step * step * step * 0.008))) + "$";
        }
    }


}
