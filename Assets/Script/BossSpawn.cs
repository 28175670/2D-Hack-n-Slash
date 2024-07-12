using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    public GameObject Boss;
    public static bool bossSpawned = false; // �аO�ܼ�
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
        if (Scoreupdate.bossScore >= 10 && !bossSpawned) // �ˬd���ƩM�O�_�w�g�ͦ��L
        {
            float randomX = Random.Range(-7f, 10f);
            Vector3 randomPosition = new Vector3(randomX, -0.52f, 0f);
            Instantiate(Boss, randomPosition, Quaternion.identity);
            bossSpawned = true; // �]�m�аO�� true
        }

    }
}
