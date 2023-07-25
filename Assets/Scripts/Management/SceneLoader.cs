using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scenes
{ 
    Menu,
    LevelMenu,
    DefaultLevel,
    Level1
}

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Scenes _sceneToLoad;
    public Scenes SceneToLoad => _sceneToLoad;

    public void LoadTheScene()
    {
        SceneManager.LoadScene(_sceneToLoad.ToString(), LoadSceneMode.Single);
        Time.timeScale = 1.0f;
    }

    public void LoadItself()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        Time.timeScale = 1.0f;
    }
}
