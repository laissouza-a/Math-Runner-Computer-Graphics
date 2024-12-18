using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStarter : MonoBehaviour
{

    //Enumerador do Start (321GO)
    public GameObject countDown3;
    public GameObject countDown2;
    public GameObject countDown1;
    public GameObject countDownGo;
    public GameObject fadeIn;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(countSequence());
    }
    IEnumerator countSequence(){
        yield return new WaitForSeconds(1.5f);
        countDown3.SetActive(true);
        yield return new WaitForSeconds(1);
        countDown2.SetActive(true);
        yield return new WaitForSeconds(1);
        countDown1.SetActive(true);
        yield return new WaitForSeconds(1);
        countDownGo.SetActive(true);
        PlayerMovement.canMove = true;
    }
}
