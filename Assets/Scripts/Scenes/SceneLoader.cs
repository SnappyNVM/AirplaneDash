using UnityEngine;
using UnityEngine.SceneManagement;

enum Scenes
{ 
    Menu,
    LevelMenu,
    DefaultLevel,
    Level1
}

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Scenes _sceneToLoad;

    public void LoadTheScene()
    {
        SceneManager.LoadScene(_sceneToLoad.ToString());
        Time.timeScale = 1.0f;
    }

    public void LoadItself()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }
}
