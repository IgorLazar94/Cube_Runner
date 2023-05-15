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
    [SerializeField] private PhoneVibration phoneVibration;
    private float stepHeight;

    //public static Action onRemovedCube;

    //private void OnEnable()
    //{
    //    onRemovedCube += RemoveCube;
    //}

    //private void OnDisable()
    //{
    //    onRemovedCube += RemoveCube;
    //}
    private void Start()
    {
        stepHeight = GetComponentInChildren<PlayerCubeBehaviour>().gameObject.transform.localScale.y;
        playerCubs.Add(GetComponentInChildren<PlayerCubeBehaviour>());
    }

    public void AddCube()
    {
        gameObject.GetComponent<PlayerController>().PlayCubStackFX();
        gameObject.GetComponent<PlayerController>().UpdateScoresAnimation();
        gameObject.GetComponent<PlayerController>().StartJumpAnimation();
        PlayerCubeBehaviour newCube = Instantiate(playerCub, transform.position, Quaternion.identity);
        playerCubs.Add(newCube);
        newCube.transform.parent = cubeHolder.transform;
        newCube.transform.position = new Vector3(transform.position.x, transform.position.y - (stepHeight * (playerCubs.Count - 1)) + (stepHeight/2), transform.position.z);
        UpdateHeight(stepHeight);
    }

    private void UpdateHeight(float difference)
    {
        //gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + difference, transform.position.z);

        Vector3 newPos = new Vector3(transform.position.x, transform.position.y + difference, transform.position.z);
        var t = Time.deltaTime * 70f;
        gameObject.transform.position = Vector3.Lerp(transform.position, newPos, t);
    }
    public void RemoveCube(/*PlayerCubeBehaviour playerCube*/)
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            Handheld.Vibrate();
        }

        cameraShake.ShakeCamera();
        gameObject.GetComponent<PlayerController>().StartJumpAnimation();
        PlayerCubeBehaviour lastCube = playerCubs[playerCubs.Count - 1];
        //playerCubs.Remove(playerCube);
        playerCubs.Remove(lastCube);
        Invoke("RemoveHeight", 0.25f);

        if (playerCubs.Count <= 0)
        {
            StartCoroutine(ActivateLoseProcess());
        }
    }

    private IEnumerator ActivateLoseProcess()
    {
        gameObject.GetComponent<PlayerController>().warpFX.Stop();
        gameObject.GetComponent<PlayerController>().EnableRagdoll();
        gameObject.GetComponent<InputController>().SetIsTapToMove(false);
        gameObject.GetComponent<InputController>().SetIsLoseState(true);
        yield return new WaitForSeconds(1.0f);
        gameManager.ActivateLosePanel(true);
    }

    

    private void RemoveHeight()
    {
        UpdateHeight(-stepHeight);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<SelectableCube>())
        {
            Destroy(other.gameObject);
            AddCube();
        }
    }
}
