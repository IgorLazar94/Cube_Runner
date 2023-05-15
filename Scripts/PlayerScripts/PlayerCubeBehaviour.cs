using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCubeBehaviour : MonoBehaviour
{
    private bool isInParent = true;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<ObstacleCubeBehaviour>() &&
            collision.gameObject.GetComponent<ObstacleCubeBehaviour>().GetIsInteractive() && isInParent)
        {
            isInParent = false;
            collision.gameObject.GetComponent<ObstacleCubeBehaviour>().SetIsInteractive(false);
            transform.parent.root.GetComponent<PlayerCubeController>().RemoveCube(/*this*/);
            gameObject.transform.parent = null;
            Destroy(gameObject, 1.0f);
        }
    }

   
}
