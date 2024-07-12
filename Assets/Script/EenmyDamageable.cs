using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class EenmyDamageable : MonoBehaviour
{
    [SerializeField] private Health health;

    [SerializeField] private UnityEvent damaged;

    private float lastDamageTime = 0f;
    public float regenDelay = 2f;



    public void TakeDamageEenmy(int damage)
    {
        health.DecreaseHealth(damage);
        enemytimeactive.isAttackenemying = true;
        damaged.Invoke();
        lastDamageTime =Time.time;
        StartCoroutine(RegenEnemy());
    }
    public void TakeDamageCrow(int damage)
    {
        health.DecreaseHealth(damage);
    
    }

    private IEnumerator RegenEnemy()
    {
        yield return new WaitForSeconds(regenDelay);
        if (Time.time - lastDamageTime >= regenDelay)
        {
            enemytimeactive.isAttackenemying = false;
        }
    }
}
