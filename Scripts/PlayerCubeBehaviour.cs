using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCubeBehaviour : MonoBehaviour
{
    private bool isPickUp = false;

    public bool GetIsPickUp()
    {
        return isPickUp;
    }

    public void SetIsPickUp(bool value)
    {
        isPickUp = value;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<ObstacleCubeBehaviour>())
        {
            gameObject.transform.parent = null;
            Destroy(gameObject, 1.0f);
        }
    }

   
}
