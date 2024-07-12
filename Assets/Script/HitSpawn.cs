using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSpawn : MonoBehaviour
{
    public GameObject sparkPrefab; // �n�ͦ���spark�w�s��
    private static HitSpawn _instance;

    private void Awake()
    {
        _instance = this;
    }
    private void Start()
    {
        
        
    }

    public static void SpawnSpark(EnemyMovement enemySpark)
    {
        Debug.Log($"Spawning spark for enemy: {enemySpark.name}");
        // �d��ĤH���W�W��"HitPosition"���l����
        Transform hitPosition = enemySpark.transform.Find("HitPosition");
        if (hitPosition != null)
        {
            // �bhitPosition��m�ͦ�spark�w�s��
            Instantiate(_instance.sparkPrefab, hitPosition.position, Quaternion.identity);
        }
    }
 
 
}
