using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hospital : MonoBehaviour
{
    public GameObject character;
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;

    void Start()
    {
        textComponent.text = string.Empty;
        StartCoroutine(ExampleCoroutine());
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopCoroutine(TypeLine());
                textComponent.text = lines[index];
            }
        }
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(2.5f);
        character.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        StartDialogue();
        //buraya diyalog baslatan kod gelecek
        yield return new WaitForSeconds(3);
        //buraya secenekler gelecek
        //secenek sectikten sonra tekrar diyalog gelecek
        yield return new WaitForSeconds(3);
        //buraya secenekler gelecek
        //secenek sectikten sonra tekrar diyalog gelecek
        yield return new WaitForSeconds(3);
        //yeni sahne calisacak
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
