using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private CinemachineCameraOffset _cinemachine;
    private const float _offsetDefaultValue = 0;
    private const float _offsetLimit = -6;

    private void Update()
    {
        CameraMoveDown();
    }

    public void CameraMoveDown()
    {
        if (Input.GetKey(KeyCode.S))
        {
            StartCoroutine(ResetCameraDownRoutine());
        }
        else
        {
            StartCoroutine(ResetCameraRoutine());
        }
    }
    
    IEnumerator ResetCameraDownRoutine()
    {
        if (_cinemachine.m_Offset.y >= _offsetLimit)
        {
            _cinemachine.m_Offset.y -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator ResetCameraRoutine()
    {
        if (_cinemachine.m_Offset.y <= _offsetDefaultValue)
        {
            _cinemachine.m_Offset.y += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
