using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] PlayerController playerObject;

    private void FollowPlayer()
    {
        transform.position = new Vector3(playerObject.transform.position.x + 3, playerObject.transform.position.y + 7 - playerObject.transform.position.y, playerObject.transform.position.z - 8);
    }

    private void LateUpdate()
    {
        FollowPlayer();
    }
}
