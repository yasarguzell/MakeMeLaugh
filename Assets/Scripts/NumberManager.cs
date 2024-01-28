using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberManager : MonoBehaviour
{
    public static NumberManager Instance;

    
    [SerializeField] private int number = 0;
    public TextMeshPro numberText; 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncreaseNumber()
    {
        number++;
        UpdateNumberText();
    }

    public void DeleteNumber()
    {
        number = 0;
        UpdateNumberText();
    }

    void UpdateNumberText()
    {
        // numberText.text = "Number: " + number.ToString();
        if (number >= 15)
        {
            SceneManagerLoad.Instance.LoadNextScene();
        }
        
    }
}
