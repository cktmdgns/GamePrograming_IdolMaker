using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManagerScript : MonoBehaviour {

    public static GameManagerScript instance;
    public void Awake()
    {
        GameManagerScript.instance = this;
    }

    public UIControlScript uiControlScript = null;
    public int currentScrollSellectIndex = 0;

    

    public void LobbySceneLoad()
    {
        Application.LoadLevel("1Lobby");
    }


    public void ScoutOpen()
    {
        uiControlScript.Panel_Management.SetActive(true);
        uiControlScript.Training.SetActive(false);
        uiControlScript.Release.SetActive(false);
        uiControlScript.Scout.SetActive(true);
    }
    

    public void TrainingOpen()
    {
        uiControlScript.Panel_Management.SetActive(true);
        uiControlScript.Release.SetActive(false);
        uiControlScript.Scout.SetActive(false);
        uiControlScript.Training.SetActive(true);
    }
    

    public void ReleaseOpen()
    {
        uiControlScript.Panel_Management.SetActive(true);
        uiControlScript.Training.SetActive(false);
        uiControlScript.Scout.SetActive(false);
        uiControlScript.Release.SetActive(true);
    }

    public void ManagementClose()
    {
        uiControlScript.Panel_Management.SetActive(false);
    }

    public void PopUpClose()
    {
        uiControlScript.PopUpMessage.SetActive(false);
    }



    public void Scout()
    {
        if(IdolManagerScript.instance.idolList[currentScrollSellectIndex].myState == IdolScript.state.NoHave)
        {
            if(PlayerScript.instance.money >= IdolManagerScript.instance.idolList[currentScrollSellectIndex].money)
            {
                PlayerScript.instance.money -= IdolManagerScript.instance.idolList[currentScrollSellectIndex].money;
                IdolManagerScript.instance.idolList[currentScrollSellectIndex].myState = IdolScript.state.Have;

                UIControlScript.instance.PopUpMessage.GetComponentInChildren<Text>().text = "스카우트 성공!";
                UIControlScript.instance.PopUpMessage.SetActive(true);
            }
        }
        else
        {
            UIControlScript.instance.PopUpMessage.GetComponentInChildren<Text>().text = "보유중!";
            UIControlScript.instance.PopUpMessage.SetActive(true);
        }
    }

    public void Training()
    {
        if(IdolManagerScript.instance.idolList[GameManagerScript.instance.currentScrollSellectIndex].myState == IdolScript.state.Have)
        {
            if (PlayerScript.instance.money >= System.Convert.ToInt32(
                    (IdolManagerScript.instance.idolList[GameManagerScript.instance.currentScrollSellectIndex].money
                    + 10) * (0.1 + IdolManagerScript.instance.idolList[GameManagerScript.instance.currentScrollSellectIndex].step)))
            {
                PlayerScript.instance.money -= System.Convert.ToInt32(
                    (IdolManagerScript.instance.idolList[GameManagerScript.instance.currentScrollSellectIndex].money
                    + 10) * (0.1 + IdolManagerScript.instance.idolList[GameManagerScript.instance.currentScrollSellectIndex].step));

                int randNum = Random.Range(0, 100);
                if (randNum >= 100 - (2 - Mathf.Log10(10 + (IdolManagerScript.instance.idolList[GameManagerScript.instance.currentScrollSellectIndex].step * 5))) * 100)
                {
                    UIControlScript.instance.PopUpMessage.GetComponentInChildren<Text>().text = "트레이닝 성공!";
                    UIControlScript.instance.PopUpMessage.SetActive(true);
                    IdolManagerScript.instance.idolList[GameManagerScript.instance.currentScrollSellectIndex].step += 1;
                }
                else
                {
                    UIControlScript.instance.PopUpMessage.GetComponentInChildren<Text>().text = "트레이닝 실패!";
                    UIControlScript.instance.PopUpMessage.SetActive(true);
                }
            }
            else
            {
                UIControlScript.instance.PopUpMessage.GetComponentInChildren<Text>().text = "소지금 부족!";
                UIControlScript.instance.PopUpMessage.SetActive(true);
            }
        }
        else
        {
            UIControlScript.instance.PopUpMessage.GetComponentInChildren<Text>().text = "미보유!";
            UIControlScript.instance.PopUpMessage.SetActive(true);
        }
    }

    public void Release()
    {
        if (IdolManagerScript.instance.idolList[GameManagerScript.instance.currentScrollSellectIndex].myState == IdolScript.state.Have)
        {
            int addMoney = System.Convert.ToInt32((IdolManagerScript.instance.idolList[GameManagerScript.instance.currentScrollSellectIndex].money + 10) *
                (1 + IdolManagerScript.instance.idolList[GameManagerScript.instance.currentScrollSellectIndex].step
                + IdolManagerScript.instance.idolList[GameManagerScript.instance.currentScrollSellectIndex].step * IdolManagerScript.instance.idolList[GameManagerScript.instance.currentScrollSellectIndex].step));

            PlayerScript.instance.money += addMoney;
            PlayerScript.instance.score += addMoney;

            IdolManagerScript.instance.idolList[GameManagerScript.instance.currentScrollSellectIndex].step = 0;
            IdolManagerScript.instance.idolList[GameManagerScript.instance.currentScrollSellectIndex].myState = IdolScript.state.NoHave;
            UIControlScript.instance.PopUpMessage.GetComponentInChildren<Text>().text = "방출 완료!";
            UIControlScript.instance.PopUpMessage.SetActive(true);
        }
        else
        {
            UIControlScript.instance.PopUpMessage.GetComponentInChildren<Text>().text = "미보유!";
            UIControlScript.instance.PopUpMessage.SetActive(true);
        }
    }
}
