using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableControl : MonoBehaviour
{
    //Display da contagem da moeda:
    public static int coinCount;
    public GameObject coinCountDisplay;
    public GameObject coinEndDisplay;

       void Update()
    {
        coinCountDisplay.GetComponent<Text>().text = ""+coinCount;

    }
}
