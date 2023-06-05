using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCubeController : MonoBehaviour
{
    [SerializeField] private List<PlayerCubeBehaviour> playerCubs = new List<PlayerCubeBehaviour>();
    [SerializeField] private PlayerCubeBehaviour playerCub;
    [SerializeField] private GameObject cubeHolder;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private CameraController cameraShake;

    private PlayerController playerController;
    private InputController inputController;
    private float stepHeight;

    private void Start()
    {
        inputController = gameObject.GetComponent<InputController>();
        playerController = gameObject.GetComponent<PlayerController>();
        stepHeight = GetComponentInChildren<PlayerCubeBehaviour>().gameObject.transform.localScale.y;
        playerCubs.Add(GetComponentInChildren<PlayerCubeBehaviour>());
    }

    public void AddCube()
    {
        playerController.PlayCubStackFX();
        playerController.UpdateScoresAnimation();
        playerController.StartJumpAnimation();
        PlayerCubeBehaviour newCube = Instantiate(playerCub, transform.position, Quaternion.identity);
        playerCubs.Add(newCube);
        newCube.transform.parent = cubeHolder.transform;
        newCube.transform.position = new Vector3(transform.position.x, transform.position.y - (stepHeight * (playerCubs.Count - 1)) + (stepHeight/2), transform.position.z);
        UpdateHeight(stepHeight);
    }

    private void UpdateHeight(float difference)
    {
        Vector3 newPos = new Vector3(transform.position.x, transform.position.y + difference, transform.position.z);
        var t = Time.deltaTime * 70f;
        gameObject.transform.position = Vector3.Lerp(transform.position, newPos, t);
    }

    public void RemoveCube()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            Handheld.Vibrate();
        }

        cameraShake.ShakeCamera();
        playerController.StartJumpAnimation();
        PlayerCubeBehaviour lastCube = playerCubs[playerCubs.Count - 1];
        playerCubs.Remove(lastCube);
        Invoke("RemoveHeight", 0.25f);

        if (playerCubs.Count <= 0)
        {
            StartCoroutine(ActivateLoseProcess());
        }
    }

    private IEnumerator ActivateLoseProcess()
    {
        playerController.warpFX.Stop();
        playerController.EnableRagdoll();
        inputController.SetIsTapToMove(false);
        inputController.SetIsLoseState(true);
        yield return new WaitForSeconds(1.0f);
        gameManager.ActivateLosePanel(true);
    }

    private void RemoveHeight()
    {
        UpdateHeight(-stepHeight);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SelectableCube"))
        {
            Destroy(other.gameObject);
            AddCube();
        }
    }
}
