using System;
using System.Collections;
using Timers;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDeterminationAttack : MonoBehaviour
{
    [SerializeField] private UnityEvent HitPoints;
    [SerializeField] private string targeTag;
    [SerializeField] private string targeTag2;
    [SerializeField] private string targeTag3;
    [SerializeField] public static int damages = 1;
    public static bool hasEnemyhit =false;
    private bool _canAttack = true;

    private void OnTriggerEnter2D(Collider2D col)
    {
        DealDamage(col);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        DealDamage(other);
    }

    private void DealDamage(Collider2D other)
    {
        if (!_canAttack) return;

        bool hasHit = false;

        if (other.CompareTag(targeTag))
        {
            var damageable = other.GetComponent<EenmyDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamageEenmy(damages);
                HitSpawn.SpawnSpark(other.GetComponent<EnemyMovement>());
                hasHit = true;
            }
        }
        else if (other.CompareTag(targeTag2))
        {
            var damageable = other.GetComponent<EenmyDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamageCrow(damages);
                hasHit = true;
            }
        }
        else if (other.CompareTag(targeTag3))
        {
            var damageable = other.GetComponent<BossDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamageBoss(damages);
                hasHit = true;
            }
        }

        if (hasHit)
        {
            TimersManager.SetTimer(this, 0.2f, CanAttack);
            _canAttack = false;
            HitPoints.Invoke();
            hasEnemyhit = true;
        }
        else
        {
            hasEnemyhit = false;
        }
    }

    private void CanAttack()
    {
        _canAttack = true;
    }
   


}
