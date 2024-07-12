using System.Collections;
using System.Collections.Generic;
using Timers;
using UnityEngine;

public class enemytimeactive : MonoBehaviour
{
   
    public static bool isAttackenemying;
    

    private void Start()
    {
        
    }
    private void FixedUpdate()
    {
        if (isAttackenemying == false )
        {
            this.gameObject.SetActive(false);
           
        }
        else
        {
            ChangeActiveState();
        }
        
    }

    public void ChangeActiveState()
    {
        this.gameObject.SetActive(true);
       
    }
}
