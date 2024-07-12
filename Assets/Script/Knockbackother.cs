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
            // ���Ҧ��аO�� "Enemy" ���C������
            GameObject[] enemyGameObjects = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject enemyGameObject in enemyGameObjects)
            {
                // ��� EnemyMovement �ե�
                EnemyMovement enemyMovement = enemyGameObject.GetComponent<EnemyMovement>();

                if (enemyMovement != null)
                {
                    // �Ұʨ�{�ӳB�z���h�ĪG
                    StartCoroutine(KnockbackCoroutine(enemyMovement));
                    
                }
                else
                {
                    Debug.LogError("�L�k�b�ĤH�C������W��� EnemyMovement �ե�");
                }
            }
        }
    }

    private IEnumerator KnockbackCoroutine(EnemyMovement enemyMovement)
    {
        EnemyDebuff_Dizziness = true;

        Rigidbody2D enemyRd = enemyMovement.enemyRd;
        enemyRd.velocity = Vector2.zero;

        // �p�����h��V
        Vector3 knockbackDirection = (enemyMovement.transform.position - PlayerManager.position).normalized;
        knockbackDirection.y = 0; // �]�mY�b��V��0,�u�v�TX�b
        //Debug.Log($"Knockback direction: {knockbackDirection} for enemy at position: {enemyMovement.transform.position}");
        // �I�[���h�O
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
