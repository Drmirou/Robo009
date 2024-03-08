using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    private CinemachineVirtualCamera CinemachineVirtualCamera;
    private float ShakeIntensity = 1.0f;
    private float ShakeTime = 0.2f;

    private float timer;
    private CinemachineBasicMultiChannelPerlin _cbmcp;




    void Awake()
    {
        CinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera() {
        CinemachineBasicMultiChannelPerlin _cbmcp = CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain = ShakeIntensity;


        timer = ShakeTime;

    }

    void StopShake() {
        CinemachineBasicMultiChannelPerlin _cbmcp = CinemachineVirtualCamera







    // Update is called once per frame
    void Update()
        {

        }
    }
}