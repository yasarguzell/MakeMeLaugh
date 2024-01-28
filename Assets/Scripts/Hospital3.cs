using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hospital3 : MonoBehaviour
{
    public GameObject character;
    public GameObject character2;
    public Dialogue2 dialogue;
    public bool isStarted = false;

    void Start()
    {
        StartCoroutine(ExampleCoroutine());
    }


    IEnumerator ExampleCoroutine()
    {
        dialogue.StartDialogue();
        yield return new WaitForSeconds(5f);

        dialogue.NextLine();
        character.SetActive(false);
        character2.SetActive(true);
        isStarted = true;
        yield return new WaitForSeconds(1.5f);


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
    }
}
