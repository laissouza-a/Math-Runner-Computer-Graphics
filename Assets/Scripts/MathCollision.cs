using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class MathCollision : MonoBehaviour
{
    //Geração da formula aleatoria + Geração do numero errado e certo e os aplica na parede esquerda/direita
    public TextMeshPro leftNumberText;
    public TextMeshPro rightNumberText;
    public TextMeshPro operationText;

    public GameObject wallLeft;   // GameObject da parede (com Collider)
    public GameObject wallRight;  // GameObject da parede (com Collider)
    public TextMeshPro wallLeftText;  // TextMeshPro para o número na parede esquerda
    public TextMeshPro wallRightText; // TextMeshPro para o número na parede direita

    private int leftNumber;
    private int rightNumber;
    private int answer;
    private string operation;

    public bool leftWall;
    public bool rightWall;


    private string[] operations = { "+", "-", "*" };

    void Start()
    {
        GenerateMathProblem();
    }

    void GenerateMathProblem()
    {
        leftNumber = Random.Range(1, 10);
        rightNumber = Random.Range(1, 10);

        operation = operations[Random.Range(0, operations.Length)];

        switch (operation)
        {
            case "+":
                answer = leftNumber + rightNumber;
                break;
            case "-":
                answer = leftNumber - rightNumber;
                break;
            case "*":
                answer = leftNumber * rightNumber;
                break;
        }

        leftNumberText.text = leftNumber.ToString();
        rightNumberText.text = rightNumber.ToString();
        operationText.text = operation;

        Debug.Log("Answer:" + answer);
        AssignAnswersToWalls();
    }

    void AssignAnswersToWalls()
    {
        int wrongAnswer = answer + Random.Range(-2, 3); 
        if (wrongAnswer == answer)
        {
            wrongAnswer += 1; 
        }

    
        if (Random.value < 0.5f)
        {
            wallLeftText.text = answer.ToString();
            wallRightText.text = wrongAnswer.ToString();
            rightWall = false;
            leftWall = true;
            Debug.Log("Respostas atribuídas: esquerda = correta, direita = errada");
        }
        else
        {
            wallLeftText.text = wrongAnswer.ToString();
            wallRightText.text = answer.ToString();
            rightWall = true;
            leftWall = false;
            Debug.Log("Respostas atribuídas: direita = correta, esquerda = errada");
        }
        
    }
}