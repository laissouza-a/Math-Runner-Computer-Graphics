using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    //Coleta moedas
    void OnTriggerEnter(Collider other)
    {   
        //Debug.Log("Coin trigger working");
        CollectableControl.coinCount+=1;
        this.gameObject.SetActive(false);
        
    }
}