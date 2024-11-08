using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDistance : MonoBehaviour
{
    //DIsplay da distancia + contagem da distancia:
  public GameObject DistanceDisplay;
 public GameObject disEndDisplay;

  public int disRun;
  public bool addingDis = false;
  public float disDelay = 0.35f;
    void Update()
    {
        if (addingDis == false){
            addingDis = true;
            StartCoroutine(AddingDis());
        }
    }
    IEnumerator AddingDis(){
        disRun+=1;
        DistanceDisplay.GetComponent<Text>().text=""+disRun;
        disEndDisplay.GetComponent<Text>().text=""+disRun;


        yield return new WaitForSeconds(0.35f);
        addingDis = false;
    }
}
