using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public static PlayerScript instance;
    public void Awake()
    {
        PlayerScript.instance = this;
    }

    public int score = 0;
    public int money = 0;
    public enum scale
    {
        인지도Zero의, 하찮은, 허름한, 굶주리지않는, 그럭저럭인, 부끄럽지않은, 잘나가는, 대박치는, 신의손
    }
    public scale myScale;

    
}
