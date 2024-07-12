using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string MoveState;
    //[SerializeField] private string die;
   



    public void Move(Vector3 direction)
    {
       
        if (direction.x > 0)
        {         
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {         
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        animator.Play(MoveState);
    }
    private void FixedUpdate()
    {
       
        var playerPosition = PlayerManager.position;
        var position = transform.position;
        var direction = playerPosition - position;
        var distance = direction.magnitude;

      
    }
   
    //public void DieAnimation()
    //{
    //    animator.Play(die);
    //}
   
}
