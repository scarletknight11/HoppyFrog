using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void RestartLevel()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel() 
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level2");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            Time.timeScale = 0;
        }

        if (Input.GetKey(KeyCode.U))
        {
            Time.timeScale = 1;
        }
    }
}
