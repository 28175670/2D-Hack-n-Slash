using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private Rigidbody2D rd;
   
    [SerializeField]private float _speed;
    private Vector2 _inputDirection;
    private int attackStage = 0;
    private bool canDash = true;
    private bool canAttack = true;
    [SerializeField] public static bool isDashing;   
    [SerializeField] public static bool isAttacking;
    [SerializeField] private float dashingpower = 24f;
    [SerializeField] private float dashingtime = 0.2f;
    [SerializeField] private float dashingcooldown = 1f;
    [SerializeField] private float Attack1time = 0.2f;
    [SerializeField] private float Attack2time = 0.2f;
    [SerializeField] private float Attack3time = 0.2f;
    [SerializeField] private float Attackcooldown = 1f;
    [SerializeField] private UnityEvent dash;
    [SerializeField] private UnityEvent Attackone;
    [SerializeField] private UnityEvent Attacktwo;
    [SerializeField] private UnityEvent Attackthree;
    private bool hasHitEnemy = false;


    private static PlayerMovement _instance;

    private bool isFacingRight = true; // 新增一個變數來儲存角色的朝向
    private void Start()
    {
        playerRD.velocity = Vector2.zero;
        KnockbackPlayer.Debuff_Dizziness = false;
    }
    void Awake()
    {
        
        _instance = this;
    }
    public static Rigidbody2D playerRD
    {
        get { return _instance.rd; }
    }
    public void Move(InputAction.CallbackContext context)
    {       
        _inputDirection = context.ReadValue<Vector2>();
        // 判斷角色移動方向並更新 isFacingRight 變數

        if (_inputDirection.x > 0)
        {
            isFacingRight = true;
        }
        else if (_inputDirection.x < 0)
        {
            isFacingRight = false;
        }
    }
    private void Update()
    {
        if (KnockbackPlayer.Debuff_Dizziness == true) 
        {
            return;
        }
        if (isDashing)
        {           
            return;
        }
       


        if (Input.GetKeyDown(KeyCode.K) && canDash && KnockbackPlayer.Debuff_Dizziness ==false)
        {
            StartCoroutine(Roll());
           
        }
        if (Input.GetKeyDown(KeyCode.J) && canAttack) 
        {
            switch (attackStage)
            {
                case 0:
                    StartCoroutine(Attack1());
                    if (hasHitEnemy)
                    {
                        attackStage = 1; // 進入下一個攻擊階段
                    }
                    break;
                case 1:
                    StartCoroutine(Attack2());
                    if (hasHitEnemy)
                    {
                        attackStage = 2; // 進入下一個攻擊階段
                    }
                    break;
                case 2:
                    StartCoroutine(Attack3());
                    if (hasHitEnemy)
                    {
                        attackStage = 0; // 重置攻擊階段
                    }
                    break;
            }


            canAttack = false; // 攻擊後暫時不能再攻擊
            StartCoroutine(ResetAttack()); // 一段時間後可以再次攻擊
        }
        
    }
    private void FixedUpdate()
    {
        if (KnockbackPlayer.Debuff_Dizziness == true) 
        {
            return;
        }
        if (isDashing) 
        {         
            return;     
        }
    
       
        var position = (Vector2)transform.position;
        var targetPosition = position + _inputDirection * _speed * Time.fixedDeltaTime;
        // 使用原生 MovePosition() 方法進行移動
        rd.MovePosition(targetPosition);
    }
    private IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(0.6f); // 1秒後可以再次攻擊
        canAttack = true;
    }
    private IEnumerator Attack1()
    {
        canDash = false;
        canAttack = false;
        isAttacking = true;
        if(PlayerDeterminationAttack.hasEnemyhit == true) 
        {
            hasHitEnemy = true;
        }
        else 
        {
            hasHitEnemy = false;
        }
        Attackone.Invoke();
        PlayerAnimationController.isWalking = false;
        _speed = 0;
        yield return new WaitForSeconds(Attack1time);
        _speed = 5;
        isAttacking = false;
        canDash = true;
        if (_inputDirection != Vector2.zero )
        {
            PlayerAnimationController.isWalking = true;
        }
        else
        {
            PlayerAnimationController.Resetanimation();
        }
        yield return new WaitForSeconds(Attackcooldown);
        canAttack = true;
    }
    private IEnumerator Attack2()
    {
        canDash = false;
        canAttack = false;
        isAttacking = true;
        if (PlayerDeterminationAttack.hasEnemyhit == true)
        {
            hasHitEnemy = true;
        }
        else
        {
            hasHitEnemy = false;
        }
        Attacktwo.Invoke();
        PlayerAnimationController.isWalking = false;
        _speed = 0;
        yield return new WaitForSeconds(Attack2time);
        _speed = 5;
        isAttacking = false;
        canDash = true;
        if (_inputDirection != Vector2.zero )
        {
            PlayerAnimationController.isWalking = true;
        }
        else
        {
            PlayerAnimationController.Resetanimation();
        }
        yield return new WaitForSeconds(Attackcooldown);
        canAttack = true;
    }
    private IEnumerator Attack3() 
    {
        canDash = false;
        canAttack = false;
        isAttacking = true;
        if (PlayerDeterminationAttack.hasEnemyhit == true)
        {
            hasHitEnemy = true;
        }
        else
        {
            hasHitEnemy = false;
        }
        Attackthree.Invoke();
        PlayerAnimationController.isWalking = false;
        _speed = 0;
        yield return new WaitForSeconds(Attack3time);
        _speed = 5;
        isAttacking = false;
        canDash = true;
        if (_inputDirection != Vector2.zero)
        {
            PlayerAnimationController.isWalking = true;
        }
        else
        {
            PlayerAnimationController.Resetanimation();
        }
        yield return new WaitForSeconds(Attackcooldown);
        canAttack = true;
    }
    private IEnumerator Roll()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rd.gravityScale;
        rd.gravityScale = 0f;


        if (isFacingRight)
        {
            rd.velocity = new Vector2(dashingpower, 0f);
        }
        else
        {
            rd.velocity = new Vector2(-dashingpower, 0f);
        }

        dash.Invoke();
        PlayerAnimationController.isWalking = false;
        yield return new WaitForSeconds(dashingtime);
        rd.gravityScale = originalGravity;
        isDashing = false;
        if(_inputDirection != Vector2.zero)
        {
            PlayerAnimationController.isWalking = true;
        }
        else 
        {
            PlayerAnimationController.Resetanimation();
        }
            
        yield return new WaitForSeconds(dashingcooldown);
        canDash = true;
    }


}
