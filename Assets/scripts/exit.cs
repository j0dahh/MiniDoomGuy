using UnityEngine;

public class ExitGame : MonoBehaviour
{
    // This method will be called when the button is clicked
    public void Exit()
    {
        // Exit the application
        Application.Quit();

        // This line is for testing in the Unity Editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
