using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public void NextScene()
    {
        SceneManagerLoad.Instance.LoadNextScene();
    }

    public void PreviousScene()
    {
        SceneManagerLoad.Instance.LoadPreviousScene();
    }

    public void ChooseScene(int scene)
    {
        SceneManagerLoad.Instance.SceneChangeIndex(scene);
    }
}
