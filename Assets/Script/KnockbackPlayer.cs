using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackPlayer : MonoBehaviour
{
    [SerializeField] private float knockbackForce = 100f;
    [SerializeField] private float _knockbackDuration = 0.5f;

    public static bool Debuff_Dizziness;
    private static KnockbackPlayer _instance;

    private void Awake()
    {
        _instance = this;
    }
    public static void Knockbackplayer()
    {
        if (!Debuff_Dizziness)
        {
            GameObject[] enemyGameObjects = GameObject.FindGameObjectsWithTag("Enemy");

            if (enemyGameObjects == null || enemyGameObjects.Length == 0)
            {
                Debug.LogError("沒有找到標記為 'Enemy' 的遊戲對象");
                return;
            }

            List<Vector3> knockbackDirections = new List<Vector3>();
            List<float> knockbackForces = new List<float>();

            foreach (GameObject enemyGameObject in enemyGameObjects)
            {
                EnemyMovement enemyMovement = enemyGameObject.GetComponent<EnemyMovement>();

                if (enemyMovement != null && enemyMovement.HasAttacked ==true)
                {
                    Vector3 knockbackDirection = (PlayerMovement.playerRD.transform.position - enemyMovement.transform.position).normalized;
                    knockbackDirection.y = 0; knockbackDirection.z = 0;
                    knockbackDirections.Add(knockbackDirection);
                    knockbackForces.Add(_instance.knockbackForce);
                }
                else
                {
                    //Debug.LogError($"無法在敵人遊戲物件 {enemyGameObject.name} 上找到 EnemyMovement 組件或該敵人尚未攻擊");
                }
            }

            if (knockbackDirections.Count > 0 && knockbackForces.Count > 0)
            {
                _instance.StartCoroutine(_instance.KnockbackDurationAll(knockbackDirections, knockbackForces));
            }
        }
    }
    public static void BossKnockbackplayer()
    {
        if (!Debuff_Dizziness)
        {
            GameObject[] BossGameObjects = GameObject.FindGameObjectsWithTag("Boss");

            if (BossGameObjects == null || BossGameObjects.Length == 0)
            {
                Debug.LogError("沒有找到標記為 'Enemy' 的遊戲對象");
                return;
            }

            List<Vector3> knockbackDirections = new List<Vector3>();
            List<float> knockbackForces = new List<float>();

            foreach (GameObject BossGameObject in BossGameObjects)
            {
                BossMovement bossMovement = BossGameObject.GetComponent<BossMovement>();

                if (bossMovement != null && bossMovement.HasAttacked == true)
                {
                    Vector3 knockbackDirection = (PlayerMovement.playerRD.transform.position - bossMovement.transform.position).normalized;
                    knockbackDirection.y = 0; knockbackDirection.z = 0;
                    knockbackDirections.Add(knockbackDirection);
                    knockbackForces.Add(_instance.knockbackForce);
                }
                else
                {
                    //Debug.LogError($"無法在敵人遊戲物件 {enemyGameObject.name} 上找到 EnemyMovement 組件或該敵人尚未攻擊");
                }
            }

            if (knockbackDirections.Count > 0 && knockbackForces.Count > 0)
            {
                _instance.StartCoroutine(_instance.KnockbackDurationAll(knockbackDirections, knockbackForces));
            }
        }
    }

    private IEnumerator KnockbackDurationAll(List<Vector3> knockbackDirections, List<float> knockbackForces)
    {
        Debuff_Dizziness = true;

        Rigidbody2D playerRd = PlayerMovement.playerRD;
        playerRd.velocity = Vector2.zero;

        if (playerRd == null)
        {
            Debug.LogError("Player Rigidbody2D is null");
            yield break;
        }

        for (int i = 0; i < knockbackDirections.Count; i++)
        {
            Vector3 direction = knockbackDirections[i];
            float force = knockbackForces[i];
            //Debug.Log($"Knockback direction: {direction} with force: {force} for player at position: {playerRd.transform.position}");
            playerRd.AddForce(direction * force, ForceMode2D.Impulse);

            float elapsedTime = 0f;
            Vector2 initialVelocity = playerRd.velocity;

            while (elapsedTime < _knockbackDuration)
            {
                float t = elapsedTime / _knockbackDuration;
                Vector2 currentVelocity = Vector2.Lerp(initialVelocity, Vector2.zero, t);
                playerRd.velocity = currentVelocity;
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            playerRd.velocity = Vector2.zero;
        }

        Debuff_Dizziness = false;
    }
}
