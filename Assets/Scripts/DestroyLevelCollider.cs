using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLevelCollider : MonoBehaviour
{
    DestroyLevelCollider dlc;
    public bool isDestroy;
    public int mynumber;
    CountLevel cl;
    PlayerController pc;
    public bool isStartground;

    public int Getmynumber()
    {
        return mynumber;
    }
    private void Awake()
    {
        cl = FindObjectOfType<CountLevel>();
        pc = FindObjectOfType<PlayerController>();
    }

    private void Start()
    {

        cl.Addnumber();
        mynumber = cl.GetisNUmber();
        
        
    }
    private void Update()
    {
        if (pc.GetisLevelClear() == true&&isStartground==false)
        {
            Destroy(gameObject, 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.tag == "Level")
        {
            
            dlc = collision.GetComponent<DestroyLevelCollider>();
            if (mynumber < dlc.Getmynumber())
            {
                Destroy(gameObject, 5f);
            }
            else if(mynumber < dlc.Getmynumber())
            {
                Destroy(collision, 5f);
            }
        }

    }
    
}
