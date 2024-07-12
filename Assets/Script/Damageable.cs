using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private UnityEvent damaged;  

    private Color _defaultColor;

    public void TakeDamage(int damage)
    {
        health.DecreaseHealth(damage);
        spriteRenderer.DOColor(new Color(1, 1, 1, 0.5f), 0.08f).SetEase(Ease.Linear).SetLoops(4, LoopType.Yoyo).ChangeStartValue(new Color(1, 1, 1, 1.0f));
        damaged.Invoke();
    }

    private void Awake()
    {
        _defaultColor = spriteRenderer.color;
    }
}
