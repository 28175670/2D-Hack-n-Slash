using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] public Rigidbody2D enemyRd;
    [SerializeField] private float speed;
    [SerializeField] private UnityEvent<Vector3> moveDirection;
    [SerializeField] private UnityEvent Slash_attack;
    [SerializeField] private UnityEvent DieAnimation;
    [SerializeField] private float attackRange = 5f;
    [SerializeField] private float hitstateingTime = 1f;
    public bool HasAttacked;
    public Transform Enemy;
    //private static EnemyMovement _instance;

    public bool isAttacking = false;
    public bool isHitAnimation = false;
    public static bool isDieing = false;


    private void Start()
    {
        
    }

    //void Awake()
    //{
    //    _instance = this;
    //}
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            Rigidbody2D enemyRd = enemy.GetComponent<Rigidbody2D>();
           
        }
    }
    private void FixedUpdate()
    {
        
        var playerPosition = PlayerManager.position;
        var position = transform.position;
        var direction = playerPosition - position;
        var distance = direction.magnitude;
        bool canAttack = distance <= attackRange && isHitAnimation == false && isDieing == false;

        if (isDieing == true)
        {
            DieAnimation.Invoke();
            isDieing = false;
            return;
        }
      
        if (isHitAnimation == true) 
        {
            return;
        }
       
       
        if (canAttack)
        {
            StartCoroutine(AttackCoroutine());
           
        }
        else
        {
          
            direction.Normalize();
            var targetPosition = position + direction * speed * Time.fixedDeltaTime;
            enemyRd.MovePosition(targetPosition);
            moveDirection.Invoke(direction);
        }
    }
    private IEnumerator AttackCoroutine()
    {
        HasAttacked = true;
        //Debug.Log("HasAttacked=yes");
        speed = 0.05f;
        Slash_attack.Invoke();
        speed = 1.5f;
        yield return new WaitForSeconds(0.5f);
        HasAttacked = false;
        //Debug.Log("HasAttackedµ²§ô");

    }
    public void HitState()
    {
        if(isDieing == true)
        {
            DieAnimation.Invoke();
            return ;
        }
        StartCoroutine(HitCoroutine());
    }
    private IEnumerator HitCoroutine()
    {
        isHitAnimation = true;
        speed = 0;
        
        yield return new WaitForSeconds(hitstateingTime);
        speed = 1.5f;
        isHitAnimation = false;

    }
    public void CheckHItStateDie(int health)
    {
        if(health <= 0)
        {
            isDieing = true;
        }
    
    }



}
