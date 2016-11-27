using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainCharacterChangeScript : MonoBehaviour {

    public GameObject mainCharacter = null;
    public GameObject pupUpMainCharacter = null;

    public void MainCharacterChangePopUp()
    {
        pupUpMainCharacter.SetActive(true);
    }

    public void MainCharacterChange()
    {
        mainCharacter.GetComponent<Image>().sprite = this.GetComponent<Image>().sprite;
        pupUpMainCharacter.SetActive(false);
    }
}
