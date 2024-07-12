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
        // 判斷是否需要播放站立動畫
        else
        {
            if (isWalking)
            {
                isWalking = false;
                animator.Play(idleState);
                //Debug.Log("站立");
            }
        }
        if (direction == Vector2.zero && (PlayerMovement.isAttacking == true || PlayerMovement.isDashing == true))
        {
            //Debug.Log("返回");
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
        // 在每個幀檢查一次行走狀態
        CheckWalkingState();
       
    }

  

    private void CheckWalkingState()
    {
        // 如果 isWalking 為 true,但動畫沒有播放,則重新播放walkState
        if (isWalking && !animator.GetCurrentAnimatorStateInfo(0).IsName(walkState))
        {
            animator.Play(walkState);
        }
    }
   
  
}
