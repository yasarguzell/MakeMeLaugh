using UnityEngine;
using UnityEngine.UI;

public class ExitGameButton : MonoBehaviour
{
    void Start()
    {
        // Attach the exit method to the button's click event
        Button exitButton = GetComponent<Button>();
        if (exitButton != null)
        {
            exitButton.onClick.AddListener(ExitGame);
        }
    }

    // Method to exit the game
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}