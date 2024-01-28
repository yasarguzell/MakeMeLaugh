using UnityEngine;

public class Wrong : MonoBehaviour
{
    private void OnMouseDown()
    {
        NumberManager.Instance.DeleteNumber();
        Destroy(gameObject); 
    }
}
