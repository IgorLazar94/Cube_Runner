using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCubeBehaviour : MonoBehaviour
{
    private bool isInteractive = true;

    public void SetIsInteractive(bool value)
    {
        isInteractive = value;
    }

    public bool GetIsInteractive()
    {
        return isInteractive;
    }



}
