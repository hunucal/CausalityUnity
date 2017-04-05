using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    private EventSystem Es;

    private GameObject storeSelected;

    void start()
    {
        storeSelected = Es.firstSelectedGameObject;
    }

    void update()
    {
        if (Es.currentSelectedGameObject != storeSelected)
        {
            if (Es.currentSelectedGameObject == null)
            {
                Es.SetSelectedGameObject(storeSelected);
            }
            else
            {
                storeSelected = Es.currentSelectedGameObject;
            }
        }
    }

    public void ChangeToScene()
    {
        StartCoroutine(ChangeLevel(0));
    }

    public void ChangeToExit()
    {
        Application.Quit();
    }

    IEnumerator ChangeLevel(int sceneToChangeTo)
    {
        yield return new WaitForSeconds(0.6f);

        float fadeTime = GameObject.Find("Manager").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(1);

    }
}
