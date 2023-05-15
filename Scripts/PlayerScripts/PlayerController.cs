using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] ParticleSystem cubeStackFX;
    [HideInInspector] public ParticleSystem warpFX;
    private float playerBorder = 2f;
    private List<Rigidbody> playerRigidbodies = new List<Rigidbody>();
    private Animator playerAnimator;
    private TextMeshPro scoresText;

    private void Start()
    {
        scoresText = GetComponentInChildren<TextMeshPro>();
        playerAnimator = GetComponentInChildren<Animator>();
        warpFX = GetComponentInChildren<ParticleSystem>();
        CreateRigidbodiesList();
        DisableRagdoll();
    }

    private void CheckBorders()
    {
        float playerPosX = transform.position.x;

        playerPosX = Mathf.Clamp(playerPosX,-playerBorder, playerBorder);
        transform.position = new Vector3(playerPosX, transform.position.y, transform.position.z);
    }

    private void FixedUpdate()
    {
        CheckBorders();
    }

    private void CreateRigidbodiesList()
    {
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
        for (int i = 0; i < rigidbodies.Length; i++)
        {
            playerRigidbodies.Add(rigidbodies[i]);
        }
    }

    private void DisableRagdoll()
    {
        playerAnimator.enabled = true;
        for (int i = 0; i < playerRigidbodies.Count; i++)
        {
            playerRigidbodies[i].isKinematic = true;
        }
    }

    public void EnableRagdoll()
    {
        playerAnimator.enabled = false;
        for (int i = 0; i < playerRigidbodies.Count; i++)
        {
            playerRigidbodies[i].isKinematic = false;
        }
        //gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up, ForceMode.Impulse);
        //gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward, ForceMode.Impulse);
    }

    public void StartJumpAnimation()
    {
        playerAnimator.SetTrigger("Jump");
    }

    public void UpdateScoresAnimation()
    {
        scoresText.gameObject.GetComponent<Animator>().SetTrigger("UpdateScore");
    }

    public void PlayCubStackFX()
    {
        cubeStackFX.Play();
    }
}
