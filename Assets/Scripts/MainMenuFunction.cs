using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunction : MonoBehaviour
{
    [SerializeField] private string nomeLevel;

    public void PlayGame(){
        SceneManager.LoadScene(1);
    }
   
}
