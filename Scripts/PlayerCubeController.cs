using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCubeController : MonoBehaviour
{
    [SerializeField] private List<PlayerCubeBehaviour> playerCubs = new List<PlayerCubeBehaviour>();
    [SerializeField] private PlayerCubeBehaviour playerCub;
    [SerializeField] private GameObject cubeHolder;
    private float stepHeight;

    //public static Action onRemovedCube;

    //private void OnEnable()
    //{
    //    onRemovedCube += RemoveCube;
    //}

    //private void OnDisable()
    //{
    //    onRemovedCube += RemoveCube;
    //}
    private void Start()
    {
        stepHeight = GetComponentInChildren<PlayerCubeBehaviour>().gameObject.transform.localScale.y;
        playerCubs.Add(GetComponentInChildren<PlayerCubeBehaviour>());
    }

    public void AddCube()
    {
        PlayerCubeBehaviour newCube = Instantiate(playerCub, transform.position, Quaternion.identity);
        playerCubs.Add(newCube);
        newCube.transform.parent = cubeHolder.transform;
        newCube.transform.position = new Vector3(transform.position.x, transform.position.y - (stepHeight * (playerCubs.Count - 1)) + (stepHeight/2), transform.position.z);
        UpdateHeight(stepHeight);
    }

    private void UpdateHeight(float difference)
    {
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + difference, transform.position.z);
    }
    public void RemoveCube()
    {
        PlayerCubeBehaviour lastCube = playerCubs[playerCubs.Count - 1];
        playerCubs.Remove(lastCube);
        Invoke("RemoveHeight", 0.25f);
    }

    private void RemoveHeight()
    {
        UpdateHeight(-stepHeight);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<SelectableCube>())
        {
            Destroy(other.gameObject);
            AddCube();
        }
    }
}
