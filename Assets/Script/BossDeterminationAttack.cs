using System;
using System.Collections;
using Timers;
using UnityEngine;
using UnityEngine.Events;
public class BossDeterminationAttack : MonoBehaviour
{
    [SerializeField] private string targeTag;


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

        if (other.CompareTag(targeTag))
        {
            var damageable = other.GetComponent<Damageable>();
            damageable.TakeDamage(8);
            TimersManager.SetTimer(this, 1f, CanAttack);
            _canAttack = false;
            KnockbackPlayer.BossKnockbackplayer(); 
            shark.TriggerShake();
        }
    }

    private void CanAttack()
    {
        _canAttack = true;
    }

}
