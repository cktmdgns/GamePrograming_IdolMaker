using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {

    public static GameManagerScript instance;
    public void Awake()
    {
        GameManagerScript.instance = this;
    }

    public UIControlScript uiControlScript = null;

    

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
        uiControlScript.Popup.SetActive(false);
    }

}
