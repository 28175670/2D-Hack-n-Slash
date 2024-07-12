using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DG.Tweening;
using UnityEngine;

public class shark : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public float shakeIntensity = 1.0f;
    public float shakeDuration = 0.5f;

    private CinemachineBasicMultiChannelPerlin noise;
    private static shark _instance;

    private void Start()
    {
        // 獲取 Cinemachine Virtual Camera 的 Noise 組件
        noise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }
    private void Awake()
    {
        _instance = this;
    }


    private void Update()
    {
        //// 在此處添加您的觸發條件檢查
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    TriggerShake();
        //}
    }

    public static void TriggerShake()
    {
        // 設置 Noise 組件的參數以產生 6D shake 效果
        _instance.noise.m_AmplitudeGain = _instance.shakeIntensity;
        _instance.noise.m_FrequencyGain = _instance.shakeIntensity;

        // 啟動 shake 效果並設置持續時間
        _instance.virtualCamera.transform.localPosition = Vector3.zero;
        _instance.virtualCamera.transform.localRotation = Quaternion.identity;
        _instance.virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = _instance.shakeIntensity;
        _instance.virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = _instance.shakeIntensity;
        _instance.Invoke("StopShake", _instance.shakeDuration);
    }

    private void StopShake()
    {
        // 停止 shake 效果
        virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0f;
        virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 0f;
    }
}
