using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private string idleState;
    [SerializeField] private string walkState;   
    [SerializeField] private string attackState1;
    [SerializeField] private string attackState2;
    [SerializeField] private string attackState3;
    [SerializeField] private string RollState;
    private Vector2 _inputDirection;
    private static PlayerAnimationController _instance;


    public static bool isWalking = false;

    private void Awake()
    {       
        _instance = this;
    }
    public void Move(InputAction.CallbackContext context)
    {
        
        var direction = context.ReadValue<Vector2>();
        _inputDirection = context.ReadValue<Vector2>();
        
        
        if (direction != Vector2.zero)
        {
            if (!isWalking)
            {
                isWalking = true;
                animator.Play(walkState);
               
            }
        }
        // �P�_�O�_�ݭn���񯸥߰ʵe
        else
        {
            if (isWalking)
            {
                isWalking = false;
                animator.Play(idleState);
                //Debug.Log("����");
            }
        }
        if (direction == Vector2.zero && (PlayerMovement.isAttacking == true || PlayerMovement.isDashing == true))
        {
            //Debug.Log("��^");
            return;
        }

        
        if (direction.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if(direction.x <0)
        {
            spriteRenderer.flipX = true;
        }
        
    }


    public void Play_Attackone()
    {
        animator.Play(attackState1);
    }
    public void Play_Attacktwo()
    {
        animator.Play(attackState2);
    }
    public void Play_Attackthree()
    {
        animator.Play(attackState3);
    }
    public void Dash()
    {
               
        animator.Play(RollState);      
    }
    
    public static void Resetanimation()
    {
        _instance.animator.Play(_instance.idleState);
    }
    private void Update()
    {      
        // �b�C�ӴV�ˬd�@���樫���A
        CheckWalkingState();
       
    }

  

    private void CheckWalkingState()
    {
        // �p�G isWalking �� true,���ʵe�S������,�h���s����walkState
        if (isWalking && !animator.GetCurrentAnimatorStateInfo(0).IsName(walkState))
        {
            animator.Play(walkState);
        }
    }
   
  
}
