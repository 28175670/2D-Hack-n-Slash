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
        // ��� Cinemachine Virtual Camera �� Noise �ե�
        noise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }
    private void Awake()
    {
        _instance = this;
    }


    private void Update()
    {
        //// �b���B�K�[�z��Ĳ�o�����ˬd
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    TriggerShake();
        //}
    }

    public static void TriggerShake()
    {
        // �]�m Noise �ե󪺰ѼƥH���� 6D shake �ĪG
        _instance.noise.m_AmplitudeGain = _instance.shakeIntensity;
        _instance.noise.m_FrequencyGain = _instance.shakeIntensity;

        // �Ұ� shake �ĪG�ó]�m����ɶ�
        _instance.virtualCamera.transform.localPosition = Vector3.zero;
        _instance.virtualCamera.transform.localRotation = Quaternion.identity;
        _instance.virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = _instance.shakeIntensity;
        _instance.virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = _instance.shakeIntensity;
        _instance.Invoke("StopShake", _instance.shakeDuration);
    }

    private void StopShake()
    {
        // ���� shake �ĪG
        virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0f;
        virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 0f;
    }
}
