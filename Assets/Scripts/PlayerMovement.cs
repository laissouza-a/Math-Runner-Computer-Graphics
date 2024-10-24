using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Movimento em frente e lado a lado
    public float playerSpeed = 6.9f;
    public float speedIncreaseRate = 0.067f;
    public float horizontalSpeed = 3;
    public float rightLimit = 5.5f;
    public float leftLimit = -5.5f;
    static public bool canMove = false;
    
    void Update()
    {
        //Transformação:
        if(playerSpeed < 25.0f)
        {
            horizontalSpeed += speedIncreaseRate * Time.deltaTime;
            playerSpeed += speedIncreaseRate * Time.deltaTime;
        }
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World);
        
        //playerSpeed *= playerSpeed*0.05
        if(canMove == true){
        //Interação Teclado:
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > leftLimit)
            {
                //Transformação
                transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);
            }
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < rightLimit)
            {
                //Transformação:
                transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed * -1);
            }
        }
    }
    
}}
