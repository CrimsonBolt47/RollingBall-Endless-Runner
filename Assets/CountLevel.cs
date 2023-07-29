using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountLevel : MonoBehaviour
{
    [SerializeField] int isnumber = 0;

    public void Resetnumber()
    {
        isnumber = 0;
    }
    public int GetisNUmber()
    {
        return isnumber;
    }

    public void Addnumber()
    {
        isnumber++;
    }

   
}
