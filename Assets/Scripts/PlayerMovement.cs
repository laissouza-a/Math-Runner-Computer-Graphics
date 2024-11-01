using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Movimentação em frente e lado a lado
    public float playerSpeed = 6.9f;
    public float speedIncreaseRate = 0.067f;
    public float horizontalSpeed = 3;
    public float rightLimit = 5.5f;
    public float leftLimit = -5.5f;
    static public bool canMove = false;

    public bool isJumping = false;
    public bool comingDown = false;
    public GameObject playerObject;



    // Parâmetros de pulo
    public float jumpForce = 7.0f;
    public bool isGrounded = true; 
    private Rigidbody rb;

    // Inicialização
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        // Aumentar gradualmente a velocidade do jogador
        if(playerSpeed < 25.0f)
        {
            horizontalSpeed += speedIncreaseRate * Time.deltaTime;
            playerSpeed += speedIncreaseRate * Time.deltaTime;
        }
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World);
        
        if(canMove)
        {
            // Movimentação lateral
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (transform.position.x > leftLimit)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);
                }
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if (transform.position.x < rightLimit)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed);
                }
            }

            // Pular, só pula se estiver no chão
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) ||  Input.GetKey(KeyCode.Space))
            {
                if(isJumping == false){
                    isJumping = true;
                    playerObject.GetComponent<Animator>().Play("Jump");
                    
                }
            }
        }
        if(isJumping == true){
            if(comingDown == false){
                transform.Translate(Vector3.up * Time.deltaTime * 3, Space.World)
            }
            if(comingDown == true){
                transform.Translate(Vector3.up * Time.deltaTime * -3, Space.World)
            }
        }
    }

    // Verifica se o jogador está tocando o chão
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }


    IEnumerator JumpSequence(){
        yield return WaitForSeconds(0.45f);
        comingDown = true;
        yield return WaitForSeconds(0.45f);
        isJumping = false;
        comingDown = false;
        playerObject.GetComponent<Animator>().Play("Standard Run");

    }
}
