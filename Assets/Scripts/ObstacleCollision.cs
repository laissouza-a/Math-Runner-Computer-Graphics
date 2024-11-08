using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    //Colisão com arvores/pedras e animação da queda, alem de parar o movimento do player
    public GameObject thePlayer;
    public GameObject charModel;

    public GameObject levelControl;

    public GameObject mainCam;
    void OnTriggerEnter(Collider other)
    {   
        this.gameObject.GetComponent<BoxCollider>().enabled=false;
        thePlayer.GetComponent<PlayerMovement>().enabled = false;
        charModel.GetComponent<Animator>().Play("Stumble Backwards");
        levelControl.GetComponent<LevelDistance>().enabled = false;
        levelControl.GetComponent<EndRunSequence>().enabled = true;
    }
}