using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Quaternion _startRotation;
    private Quaternion? _targetRotation;
    private Coroutine _shakeCoroutine;
    private float _degVelocity;
    private bool _isShaking;

    //==========================================================================
    // Ударное вращение камеры, угол поворота камеры
    private float shakeCamRotateAngle = 1f;
    // Ударное вращение камеры, скорость поворота камеры
    private float shakeCamRotateSpeed = 200.0f;


    // Вибрация камеры, продолжительность
    private float shakeCamDuration = 0.25f;
    // Вибрация камеры, угол поворота
    private float shakeCamMaxAngle = 0.05f;
    // Вибрация камеры, скорость вибрации
    private int shakeCamDegVelocity = 100;
    //==========================================================================

    public void ShakeRotateCamera(Vector2 direction, float angleDeg, float degVelocity)
    {
        if (_isShaking)
        {
            return;
        }
        ShakeRotateCameraInterval(direction, angleDeg, degVelocity);

    }


    public void ShakeCamera(float duration, float maxAngle, float degVelocity)
    {
        if (_shakeCoroutine != null)
        {
            StopCoroutine(_shakeCoroutine);
        }
        _isShaking = false;
        _shakeCoroutine = StartCoroutine(VibrateCameraCor(duration, maxAngle, degVelocity));
    }


    void Start()
    {
        _startRotation = transform.localRotation;
    }


    private void Update()
    {

        Quaternion target = _targetRotation == null ? _startRotation : _targetRotation.Value;
        if (target == transform.localRotation)
        {
            return;
        }

        float t = (Time.deltaTime * _degVelocity) / Quaternion.Angle(transform.localRotation, target);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, target, t);
        if (transform.localRotation == _targetRotation)
        {
            _targetRotation = null;
        }
    }


    private IEnumerator VibrateCameraCor(float duration, float maxAngle, float degVelocity)
    {
        _isShaking = true;
        float elapsed = 0f;
        float timePassed = Time.realtimeSinceStartup;
        while (elapsed < duration)
        {
            float currentTime = Time.realtimeSinceStartup;
            elapsed += currentTime - timePassed;
            timePassed = currentTime;

            ShakeRotateCameraInterval(Random.insideUnitCircle, Random.Range(0, maxAngle), degVelocity);
            // Скорость вращения камеры
            yield return new WaitForSeconds(0.05f);
        }
        _isShaking = false;
    }


    private void ShakeRotateCameraInterval(Vector2 direction, float angleDeg, float degVelocity)
    {
        _degVelocity = degVelocity;
        direction = direction.normalized;
        direction *= Mathf.Tan(angleDeg * Mathf.Deg2Rad);
        Vector3 resDirection = ((Vector3)direction + transform.forward).normalized;
        _targetRotation = Quaternion.FromToRotation(transform.forward, resDirection);
    }

    public void StartPushRotationCamera()
    {
        //Запустить ударное вращение камеры
        Vector2 direction = Random.insideUnitCircle;
        ShakeRotateCamera(direction, shakeCamRotateAngle, shakeCamRotateSpeed);
    }

    public void StartVibrationCamera()
    {
        //Запустить вибрацию камеры
        ShakeCamera(shakeCamDuration, shakeCamMaxAngle, shakeCamDegVelocity);
    }

}
