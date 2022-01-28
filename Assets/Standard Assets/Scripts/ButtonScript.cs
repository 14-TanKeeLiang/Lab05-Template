using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    private static int currentLevel = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void PlayBtn()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void EasyLevel()
    {
        currentLevel= 1;
        SceneManager.LoadScene("EasyLevel");
    }

    public void MediumLevel()
    {
        currentLevel = 2;
        SceneManager.LoadScene("MediumLevel");
    }

    public void HardLevel()
    {
        currentLevel = 3;
        SceneManager.LoadScene("HardLevel");
    }

    public void RestartBtn()
    {
        if(currentLevel == 1)
        {
            SceneManager.LoadScene("EasyLevel");
        }
        if(currentLevel == 2)
        {
            SceneManager.LoadScene("MediumLevel");
        }
        if(currentLevel == 3)
        {
            SceneManager.LoadScene("HardLevel");
        }
    }

    public void MainMenuBtn()
    {
        currentLevel = 0;
        SceneManager.LoadScene("MainMenu");
    }
}
