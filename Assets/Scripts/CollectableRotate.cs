using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableRotate : MonoBehaviour
{
    //Rotação da moeda:
    [SerializeField] int rotateSpeed = 1;
    void Update()
    {
        //Transformação rotação
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }
}