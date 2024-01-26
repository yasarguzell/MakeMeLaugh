using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManagerLoad.Instance.LoadNextScene();
    }
}
