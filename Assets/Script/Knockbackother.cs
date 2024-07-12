using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockbackother : MonoBehaviour
{
    [SerializeField] private float knockbackForce = 100f;
    [SerializeField] private float _knockbackDuration = 0.5f;

    public static bool EnemyDebuff_Dizziness;
    // Start is called before the first frame update

    void Start()
    {
        

        
    }

    public void KnockbackEnemy()
    {
        if (!EnemyDebuff_Dizziness)
        {
            // 找到所有標記為 "Enemy" 的遊戲物件
            GameObject[] enemyGameObjects = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject enemyGameObject in enemyGameObjects)
            {
                // 獲取 EnemyMovement 組件
                EnemyMovement enemyMovement = enemyGameObject.GetComponent<EnemyMovement>();

                if (enemyMovement != null)
                {
                    // 啟動協程來處理擊退效果
                    StartCoroutine(KnockbackCoroutine(enemyMovement));
                    
                }
                else
                {
                    Debug.LogError("無法在敵人遊戲物件上找到 EnemyMovement 組件");
                }
            }
        }
    }

    private IEnumerator KnockbackCoroutine(EnemyMovement enemyMovement)
    {
        EnemyDebuff_Dizziness = true;

        Rigidbody2D enemyRd = enemyMovement.enemyRd;
        enemyRd.velocity = Vector2.zero;

        // 計算擊退方向
        Vector3 knockbackDirection = (enemyMovement.transform.position - PlayerManager.position).normalized;
        knockbackDirection.y = 0; // 設置Y軸方向為0,只影響X軸
        //Debug.Log($"Knockback direction: {knockbackDirection} for enemy at position: {enemyMovement.transform.position}");
        // 施加擊退力
        enemyRd.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);

        float elapsedTime = 0f;
        Vector2 initialVelocity = enemyRd.velocity;

        while (elapsedTime < _knockbackDuration)
        {
            float t = elapsedTime / _knockbackDuration;
            Vector2 currentVelocity = Vector2.Lerp(initialVelocity, Vector2.zero, t);
            enemyRd.velocity = currentVelocity;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        enemyRd.velocity = Vector2.zero;
        EnemyDebuff_Dizziness = false;
    }
}
