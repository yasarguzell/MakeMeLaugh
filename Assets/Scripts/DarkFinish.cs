using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkFinish : MonoBehaviour
{
    public GameObject gameObject1;
    public GameObject gameObject2;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            gameObject1.SetActive(false);
            gameObject2.SetActive(true);
            SceneManagerLoad.Instance.LoadNextScene();

        }
    }
}
