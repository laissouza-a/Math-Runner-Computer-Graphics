using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegementGenerator : MonoBehaviour
{
    //Tem 3 segmentos alem do start e start countdown, eles vão ser postos aleatoriamente na frente do outro:
    public GameObject[] segment;
    [SerializeField] int zPos = 30;
    [SerializeField] bool creatingSegment = false;
    [SerializeField] int segmentNum;


    void Update()
    {
        if(creatingSegment == false)
        {
            creatingSegment = true;
            StartCoroutine(SegmentGen());
        }
        
    }

    IEnumerator SegmentGen()
    {
        segmentNum = Random.Range(0, 4);
        Instantiate(segment[segmentNum], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 30;
        yield return new WaitForSeconds(1);
        creatingSegment = false;
    }

}
