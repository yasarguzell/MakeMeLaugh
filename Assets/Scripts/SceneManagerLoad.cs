using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerLoad : Singleton<SceneManagerLoad>
{

    public Animator transition;

    public float transitionTime = 1f;

    public int sceneIndex;

    public void LoadNextScene()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadPreviousScene()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 1));
    }

    public void SceneChangeIndex(int sceneIndex)
    {
        StartCoroutine(LoadLevel(sceneIndex));
    }
    public void LoadHome()
    {
        StartCoroutine(LoadLevel(1));
    }

    public void OpenScene(string level)
    {
        StartCoroutine(LoadLevelString(level));
    }
    IEnumerator LoadLevel(int levelIndex)
    {



        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelIndex);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        transition.SetTrigger("End");

    }
    public IEnumerator LoadLevelString(string levelName)
    {


        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);



        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        transition.SetTrigger("End");



    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Home))
        {
            StartCoroutine(LoadLevel(1));
        }
    }
}
