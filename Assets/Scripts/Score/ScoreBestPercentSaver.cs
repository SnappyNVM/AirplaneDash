using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreBestPercentSaver : MonoBehaviour
{
    public static ScoreBestPercentSaver Instance { get; private set; }

    private void Start()
    {
        if (Instance == null)
        {
            Instance = GetComponent<ScoreBestPercentSaver>();
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
        if (currentRecord < ScorePercentCounter.Instance.CurrentScorePercent)
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, ScorePercentCounter.Instance.CurrentScorePercent);
    }
}
