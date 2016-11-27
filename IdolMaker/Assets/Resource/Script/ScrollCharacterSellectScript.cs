using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScrollCharacterSellectScript : MonoBehaviour {

    public int index = 0;

    void Start()
    {
        index = System.Convert.ToInt32(this.name.Substring(13));
    }

    void Update()
    {
        if(IdolManagerScript.instance.idolList[index].myState == IdolScript.state.NoHave)
        {
            this.GetComponentsInChildren<Text>()[1].text = IdolManagerScript.instance.idolList[index].money + "$";
        }
        else
        {
            this.GetComponentsInChildren<Text>()[1].text = "보유중";
        }
    }

    public void CharacterSellect()
    {
        GameManagerScript.instance.currentScrollSellectIndex = index;
    }
}

