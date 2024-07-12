using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;  // ���a����Transform
    public float smoothTime = 0.5f; // �۾����H�����Ʈɶ�
    public float offsetX = 0f; // X �b�����q
    public float offsetY = 0f; // Y �b�����q

    private Vector3 velocity = Vector3.zero; // �۾���e���t��

    void FixedUpdate()
    {
        // �p��۾����Ӳ��ʨ쪺�ؼЦ�m
        Vector3 targetPosition = new Vector3(player.position.x + offsetX, player.position.y + offsetY, transform.position.z);

        // �ϥ�SmoothDamp���Ʀa���ʬ۾�
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

    }
}
