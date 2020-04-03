using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame

    public void TogglePause()
    {
        if (pauseMenu.activeSelf)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }

    }
    void Update()
    {
        
        
    }
}
