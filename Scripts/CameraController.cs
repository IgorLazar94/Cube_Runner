using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] PlayerController playerObject;

    private void FollowPlayer()
    {
        transform.position = new Vector3(playerObject.transform.position.x, playerObject.transform.position.y + 7, playerObject.transform.position.z - 6);
    }

    private void LateUpdate()
    {
        FollowPlayer();
    }
}
