using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scenes
{ 
    Menu,
    LevelMenu,
    Level1,
    Level2,
    Level3,
    Level4,
    Level5,
    Level6,
    Level7,
    Level8,
    Level9,
    Level10
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
