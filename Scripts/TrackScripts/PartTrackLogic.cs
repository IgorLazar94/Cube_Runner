using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartTrackLogic : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.parent.gameObject.GetComponent<TrackLogic>().UpdateTrack();
        }
    }
}
