using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject losePanel;

    private void Awake()
    {
        //MakeSingleton();
        ActivateStartPanel(true);
        Time.timeScale = 1;

    }

    public void ActivateStartPanel(bool value)
    {
        startPanel.SetActive(value);
    }

    public void ActivateLosePanel(bool value)
    {
        losePanel.SetActive(value);
        Time.timeScale = 0;
    }

    private void MakeSingleton()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void RepeatLevelButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
