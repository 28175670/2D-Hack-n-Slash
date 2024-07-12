using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    public GameObject Boss;
    public static bool bossSpawned = false; // 標記變數
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (Scoreupdate.bossScore >= 10 && !bossSpawned) // 檢查分數和是否已經生成過
        {
            float randomX = Random.Range(-7f, 10f);
            Vector3 randomPosition = new Vector3(randomX, -0.52f, 0f);
            Instantiate(Boss, randomPosition, Quaternion.identity);
            bossSpawned = true; // 設置標記為 true
        }

    }
}
