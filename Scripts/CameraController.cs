using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] PlayerController playerObject;
    private float shakeDuration = 0.3f;
    private float shakeAmount = 0.4f;
    private float decreaseFactor = 1f;
    [HideInInspector] public bool isShaking;

    private float currentShakeDuration = 0f;

    private void FollowPlayer()
    {
        transform.position = new Vector3(playerObject.transform.position.x + 3, playerObject.transform.position.y + 7 - playerObject.transform.position.y, playerObject.transform.position.z - 8);
    }

    private void LateUpdate()
    {
        FollowPlayer();
        Shaking();
    }

    public void ShakeCamera()
    {
        currentShakeDuration = shakeDuration;
    }

    private void Shaking()
    {
        if (currentShakeDuration > 0)
        {
            isShaking = true;
            transform.localPosition = transform.localPosition + Random.insideUnitSphere * shakeAmount;

            currentShakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            isShaking = false;
            currentShakeDuration = 0f;
        }
    }
}
