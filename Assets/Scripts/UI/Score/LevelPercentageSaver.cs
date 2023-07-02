using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPercentageSaver : MonoBehaviour
{
    public static LevelPercentageSaver Instance { get; private set; }

    private void Start()
    {
        if (Instance == null)
        {
            Instance = GetComponent<LevelPercentageSaver>();
        }
        else
        {
            Debug.Log("LevelPercentageSaver script has 2 realization, one of them deleted.");
            Destroy(this);
        }
    }

    public int GetCurrentLevelRecord() => PlayerPrefs.GetInt(SceneManager.GetActiveScene().name);

    public void SaveScore()
    {
        int currentRecord = GetCurrentLevelRecord();
        if (currentRecord < PercentScoreCounter.Instance.CurrentScorePercent)
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, PercentScoreCounter.Instance.CurrentScorePercent);
    }
}
