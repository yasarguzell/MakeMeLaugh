using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truth : MonoBehaviour
{
    private void OnMouseDown()
    {
        NumberManager.Instance.IncreaseNumber(); 
        Destroy(gameObject); 
    }
}
