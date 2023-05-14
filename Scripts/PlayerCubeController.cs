using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCubeController : MonoBehaviour
{
    [SerializeField] private List<PlayerCubeBehaviour> playerCubs = new List<PlayerCubeBehaviour>();
    [SerializeField] private PlayerCubeBehaviour playerCub;
    [SerializeField] private GameObject cubeHolder;
    private float stepHeight;
 
    private void Start()
    {
        stepHeight = GetComponentInChildren<PlayerCubeBehaviour>().gameObject.transform.localScale.y;
        playerCubs.Add(GetComponentInChildren<PlayerCubeBehaviour>());
        Debug.Log(stepHeight + " step Height");
    }

    public void AddCube()
    {
        PlayerCubeBehaviour newCube = Instantiate(playerCub, transform.position, Quaternion.identity);
        playerCubs.Add(newCube);
        newCube.transform.parent = cubeHolder.transform;
        newCube.transform.position = new Vector3(transform.position.x, transform.position.y - (stepHeight * playerCubs.Count) + (stepHeight/2), transform.position.z);
        Debug.Log(transform.position.y - stepHeight * playerCubs.Count + "Step Height Update");
        UpdateHeight(stepHeight);
    }

    private void UpdateHeight(float difference)
    {
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + difference, transform.position.z);
    }
    public void RemoveCube(PlayerCubeBehaviour _playerCubeBehaviour)
    {
        playerCubs.Remove(_playerCubeBehaviour);
        UpdateHeight(-1);
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
