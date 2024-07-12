using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSpawn : MonoBehaviour
{
    public GameObject sparkPrefab; // 要生成的spark預製體
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
        // 查找敵人身上名為"HitPosition"的子物件
        Transform hitPosition = enemySpark.transform.Find("HitPosition");
        if (hitPosition != null)
        {
            // 在hitPosition位置生成spark預製體
            Instantiate(_instance.sparkPrefab, hitPosition.position, Quaternion.identity);
        }
    }
 
 
}
