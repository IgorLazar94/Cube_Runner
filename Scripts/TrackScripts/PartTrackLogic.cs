using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PartTrackLogic : MonoBehaviour
{
    private float speed = 2f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.parent.gameObject.GetComponent<TrackLogic>().UpdateTrack();
        }
    }

    private IEnumerator PickUpTrack(float _pickUpDistance)
    {
        Vector3 newPos = new Vector3(transform.position.x, transform.position.y + _pickUpDistance, transform.position.z);
        while (Vector3.Distance(transform.position, newPos) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, newPos, speed * Time.deltaTime);
            yield return null;
        }
    }

    public void StartPickUpTrack(float _pickUpDistance)
    {
        StartCoroutine(PickUpTrack(_pickUpDistance));
    }
}
