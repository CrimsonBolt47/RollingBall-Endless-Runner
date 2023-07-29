using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public GameObject[] Levels;
    GameObject level;
    PlayerController pc;
    public bool isLeft;

    float RandomX;
    float RandomY;

    public bool isdone = false;

    CountLevel cl;
    
    public bool GetisDone()
    {
        return isdone;
    }

    

    private void Start()
    {
        pc = FindObjectOfType<PlayerController>();
        cl = FindObjectOfType<CountLevel>();
        AddLevel();
    }

    void AddLevel()
    {
        if(isLeft)
        {
            RandomX = Random.Range(-2, -5);

        }
        else if(isLeft==false)
        {
            RandomX = Random.Range(2, 5);

        }
        RandomY = Random.Range(-3, 3);
        Vector2 Spawndistance = new Vector2(transform.position.x+RandomX, transform.position.y+RandomY);
        level= Instantiate(Levels[RandomLevel()],Spawndistance, Quaternion.identity);
        isdone = true;

    }

   

    int RandomLevel()
    {
        int r = Random.Range(0, 100);
        if (r >= 0 && r <= 10)
        {
            return 0;
        }
        else
        {
            int k = Random.Range(1, Levels.Length);
            return k;

        }
           

    }
    

    private void Update()
    {
        DeleteLevel();
        if(gameObject.tag=="StartPoint")
        {
            if(level==null)
            {
                cl.Resetnumber();
                AddLevel();
            }
        }
    }
    void DeleteLevel()
    {
        if(pc.GetisLevelClear()==true)
        {
            Destroy(level,1f);
        }
        
    }
   

}
