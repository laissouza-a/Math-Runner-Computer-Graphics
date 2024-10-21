using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerWall : MonoBehaviour
{
    //Controla colisão com as paredes de acordo com as coordenadas, se for a errada player para + animação de queda:
    public GameObject player;
    public GameObject charModel;

    public GameObject mathCollisionObject; // GameObject que contém o script MathCollision
    private MathCollision mathCollision;


    //Debug:
    void Start()
    {
        // Verifica se o mathCollisionObject foi atribuído e tenta obter o componente MathCollision
        if (mathCollisionObject != null)
        {
            mathCollision = mathCollisionObject.GetComponent<MathCollision>();
            if (mathCollision == null)
            {
                Debug.LogError("MathCollision component not found on the assigned GameObject.");
            }
        }
        else
        {
            Debug.LogError("mathCollisionObject is not assigned in the inspector.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (mathCollision == null) return; // Evita o erro se o mathCollision for nulo

        float playerX = player.transform.position.x;
        Debug.Log("Player x pos: " + playerX);

        if (mathCollision.rightWall)
        {
            if (playerX > 0)
            {
                Debug.Log("Parede correta");
            }
            else
            {
                Debug.Log("Parede Incorreta");
                HandleIncorrectWall();
            }
        }
        else if (mathCollision.leftWall)
        {
            if (playerX < 0)
            {
                Debug.Log("Parede correta");
            }
            else
            {
                Debug.Log("Parede Incorreta");
                HandleIncorrectWall();
            }
        }
    }

    void HandleIncorrectWall()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        player.GetComponent<PlayerMovement>().enabled = false;
        charModel.GetComponent<Animator>().Play("Stumble Backwards");
    }
}
