using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 6.9f;
    public float speedIncreaseRate = 0.067f;
    public float horizontalSpeed = 3;
    static public bool canMove = false;

    public float jumpForce = 5f; // Força de salto
    private float forcaY; // Força aplicada no eixo Y para gravidade e salto

    private CharacterController controller; // Controlador do personagem
    private Animator animator; // Controlador de animações

    [SerializeField] private Transform peDoPersonagem; // Ponto de checagem no pé do personagem
    [SerializeField] private LayerMask colisaoLayer; // Layer para detectar colisões com o chão
    private bool isGrounded; // Variável para verificar se o personagem está no chão

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Aumentar gradualmente a velocidade do jogador
        if (playerSpeed < 25.0f)
        {
            horizontalSpeed += speedIncreaseRate * Time.deltaTime;
            playerSpeed += speedIncreaseRate * Time.deltaTime;
        }

        // Movimento para frente constante
        controller.Move(Vector3.forward * Time.deltaTime * playerSpeed);

        if (canMove)
        {
            // Movimentação lateral
            Vector3 lateralMove = Vector3.zero;
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                lateralMove = Vector3.left * horizontalSpeed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                lateralMove = Vector3.right * horizontalSpeed * Time.deltaTime;
            }
            controller.Move(lateralMove);

            // Verifica se o personagem está no chão
            isGrounded = Physics.CheckSphere(peDoPersonagem.position, 0.3f, colisaoLayer);
            animator.SetBool("noChao", isGrounded);

            // Aplicação da força de salto
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                forcaY = jumpForce;
                animator.SetTrigger("saltar");
            }

            // Aplicação da gravidade
            if (forcaY > -9.81f)
            {
                forcaY += -9.81f * Time.deltaTime;
            }

            // Move o personagem no eixo Y (gravidade e salto)
            controller.Move(new Vector3(0, forcaY, 0) * Time.deltaTime);
        }
    }
}
