using UnityEngine;
using TMPro;

public class AfterDeathPanelPresenter : MonoBehaviour
{
    [SerializeField] private GameObject _onDeadPanel;
    [SerializeField] private TMP_Text _currentScore;
    [SerializeField] private TMP_Text _bestScore;

    public static AfterDeathPanelPresenter Instance { get; private set; }

    private void Start()
    {
        if (Instance == null)
        {
            Instance = GetComponent<AfterDeathPanelPresenter>();
            _onDeadPanel.SetActive(false);
        }
        else
        {
            Debug.Log("AfterDeathScorePresenter script has 2 realization, one of them deleted.");
            Destroy(this);
        }
    }

    public void UpdateDeathPanelWhenDead()
    {
        _onDeadPanel.SetActive(true);
        _currentScore.text = LanguagesContainer.Instance.WordsDictionary[LanguagesContainer.GameLanguage]["yourScore"]
            + ScorePercentCounter.Instance.CurrentScorePercent + "%";
        _bestScore.text = LanguagesContainer.Instance.WordsDictionary[LanguagesContainer.GameLanguage]["best"]
            + ScoreBestPercentSaver.Instance.GetCurrentLevelRecord().ToString() + "%";
        Destroy(gameObject);
    }
}
