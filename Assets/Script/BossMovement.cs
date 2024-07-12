using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossMovement : MonoBehaviour
{
    [SerializeField] public Rigidbody2D bossRd;
    [SerializeField] private float speed;
    [SerializeField] private UnityEvent<Vector3> moveDirection;
    [SerializeField] private UnityEvent Slash_attack;
    [SerializeField] private UnityEvent DieAnimation;
    [SerializeField] private float attackRange = 5f;
    [SerializeField] private GameObject healthUI;
    [SerializeField] private GameObject Attackcoi;
    public bool HasAttacked;
    private bool canAttacking;
    public bool isAttacking = false;
    public static bool isDieing = false;


    private void Start()
    {
        isDieing = false;
    }

    void Update()
    {
        GameObject[] bossies = GameObject.FindGameObjectsWithTag("Boss");

        foreach (GameObject boss in bossies)
        {
            Rigidbody2D bossRd = boss.GetComponent<Rigidbody2D>();

        }
    }
    private void FixedUpdate()
    {
        var playerPosition = PlayerManager.position;
        var position = transform.position;
        var direction = playerPosition - position;
        var distance = direction.magnitude;
        bool canAttack = distance <= attackRange && isDieing == false && !HasAttacked && canAttacking ==false;

        if (isDieing == true)
        {
            DieAnimation.Invoke();
            
            return;
        }


        if (canAttack)
        {
            StartCoroutine(AttackCoroutine());
        }
        else
        {
            if (!HasAttacked)
            {
                direction.Normalize();
                var targetPosition = position + direction * speed * Time.fixedDeltaTime;
                bossRd.MovePosition(targetPosition);
                moveDirection.Invoke(direction);
            }
        }
    }
    private IEnumerator AttackCoroutine()
    {
        canAttacking = true;
        HasAttacked = true;
        speed = 0f;
        Slash_attack.Invoke();
        yield return new WaitForSeconds(2f);
        speed = 1f;
        HasAttacked = false;
        yield return new WaitForSeconds(2f);
        canAttacking = false;

    }
    
    public void CheckHItStateDie(int health)
    {
        if (health <= 0)
        {
            isDieing = true;
        }

    }
}
