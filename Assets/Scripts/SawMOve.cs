using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMOve : MonoBehaviour
{
    public GameObject startpoint;
    public GameObject endPoint;
    public float speed;
    public bool positionisstart=true;
    Vector3 pos;
   
    void Start()
    {
       

    }
    IEnumerator MoveSaw()
    {
        


            transform.position = Vector2.MoveTowards(transform.position, pos, speed * Time.deltaTime);

            if (transform.position==pos)
            {
                positionisstart = !positionisstart;
                yield return new WaitForSeconds(4f);
               
            }

        
    }

    
    void Update()
    {

        if (positionisstart)
            pos = endPoint.transform.position;
        else if (!positionisstart)
            pos = startpoint.transform.position;

        StartCoroutine(MoveSaw());


    }
}
