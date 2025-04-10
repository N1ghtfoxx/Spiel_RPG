using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenueButtonManager : MonoBehaviour
{
    [SerializeField] private string gameSceneName;
    public void StartGamePressed()
    {
        Debug.Log($"{Pressed("New Game")}");
        SceneManager.LoadScene( gameSceneName );
    }
    public void OptionsPressed()
    {
        Debug.Log($"{Pressed("Options")}");  
    }
    private string Pressed(string button)
    {
        return button + "Button Pressed";
    }
    public void QuitPressed()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}