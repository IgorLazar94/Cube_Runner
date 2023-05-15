using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector] public ParticleSystem warpFX;
    private float playerBorder = 2f;
    private List<Rigidbody> playerRigidbodies = new List<Rigidbody>();

    private void Start()
    {
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
        for (int i = 0; i < playerRigidbodies.Count; i++)
        {
            playerRigidbodies[i].isKinematic = true;
        }
    }

    public void EnableRagdoll()
    {
        Debug.Log("enable ragdoll");
        for (int i = 0; i < playerRigidbodies.Count; i++)
        {
            playerRigidbodies[i].isKinematic = false;
        }
    }


}
