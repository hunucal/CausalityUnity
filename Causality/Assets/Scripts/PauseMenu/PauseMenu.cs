using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseUI;

    static public bool paused = false;

    void Start()
    {
        PauseUI.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            paused = !paused;
        }

        if(paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        if(!paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }
    }

    IEnumerator ChangeLevel(int sceneToChangeTo)
    {
        yield return new WaitForSeconds(0f);
        paused = !paused;
        float fadeTime = GameObject.Find("Manager").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(0);

    }

    //void FixedUpdate()
    //{
    //   if( PauseMenu.paused == false)
    //    {
    //        Do physics
    //    }
    //   else
    //    {
    //        Do not do pysics
    //    }
    //}

    public void Resume()
    {
        paused = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        StartCoroutine(ChangeLevel(0));
    }


    public void Quit()
    {
        Application.Quit();
    }
}