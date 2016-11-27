using System.Collections.Generic;
using UnityEngine;

public class IdolManagerScript : MonoBehaviour {

    public static IdolManagerScript instance;
    public void Awake()
    {
        IdolManagerScript.instance = this;
    }

    public List<IdolScript> idolList = null;
}
