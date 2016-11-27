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
        찌질한, 허름한, 잘나가는
    }
    public scale myScale;

    
}
