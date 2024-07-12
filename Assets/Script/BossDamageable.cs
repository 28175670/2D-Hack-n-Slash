using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class BossDamageable : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private SpriteRenderer spriteRenderer;
    //[SerializeField] private UnityEvent damaged;
    private Color _defaultColor;
    private float lastDamageTime = 0f;
    public float regenDelay = 2f;



   
    public void TakeDamageBoss(int damage)
    {
        health.DecreaseHealth(damage);
        enemytimeactive.isAttackenemying = true;
        spriteRenderer.DOColor(new Color(1, 1, 1, 0.5f), 0.08f).SetEase(Ease.Linear).SetLoops(4, LoopType.Yoyo).ChangeStartValue(new Color(1, 1, 1, 1.0f));
    
        lastDamageTime = Time.time;
        StartCoroutine(RegenEnemy());
    }

    private void Awake()
    {
        _defaultColor = spriteRenderer.color;
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
