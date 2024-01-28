using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hospital : MonoBehaviour
{
    public GameObject character;
    public Dialogue dialogue;
    public bool isStarted = false;

    void Start()
    {
        StartCoroutine(ExampleCoroutine());
    }


    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(2.5f);
        character.SetActive(true);
        isStarted = true;
        yield return new WaitForSeconds(1.5f);
        dialogue.StartDialogue();


        /*
        
        //buraya secenekler gelecek
        //secenek sectikten sonra tekrar diyalog gelecek
        yield return new WaitForSeconds(3);

        //buraya secenekler gelecek
        //secenek sectikten sonra tekrar diyalog gelecek*/
        while (!dialogue.dialogueFinished)
        {
            yield return new WaitForSeconds(0.5f);
        }
        SceneManagerLoad.Instance.LoadNextScene();
        StopAllCoroutines();
    }

}
