using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;  // 玩家物件的Transform
    public float smoothTime = 0.5f; // 相機跟隨的平滑時間
    public float offsetX = 0f; // X 軸偏移量
    public float offsetY = 0f; // Y 軸偏移量

    private Vector3 velocity = Vector3.zero; // 相機當前的速度

    void FixedUpdate()
    {
        // 計算相機應該移動到的目標位置
        Vector3 targetPosition = new Vector3(player.position.x + offsetX, player.position.y + offsetY, transform.position.z);

        // 使用SmoothDamp平滑地移動相機
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

    }
}
