using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackLogic : MonoBehaviour
{
    [SerializeField] private GameObject trackPart;
    private List<PartTrackLogic> tracksList = new List<PartTrackLogic>();

    private void Start()
    {
        var tracksLogic = GetComponentsInChildren<PartTrackLogic>();

        for (int i = 0; i < tracksLogic.Length; i++)
        {
            tracksList.Add(tracksLogic[i]);
        }


    }

    public void UpdateTrack()
    {
        RemoveOldTrack();
        InstallNewTrack();

    }

    private void RemoveOldTrack()
    {
        Destroy(tracksList[0].gameObject, 5f);
        tracksList.Remove(tracksList[0]);
    }

    private void InstallNewTrack()
    {
        var lastPartTrack = tracksList[tracksList.Count - 1];
        var newPartOfTrack = Instantiate(trackPart, new Vector3(transform.position.x, 
                                           transform.position.y, 
                                           lastPartTrack.transform.position.z + 30), Quaternion.identity);
        newPartOfTrack.transform.parent = gameObject.transform;
        tracksList.Add(newPartOfTrack.GetComponent<PartTrackLogic>());
    }
}
