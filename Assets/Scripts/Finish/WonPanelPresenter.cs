using UnityEngine;

public class WonPanelPresenter : MonoBehaviour
{
    [SerializeField] private GameObject _wonPanel;
    public static WonPanelPresenter Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = GetComponent<WonPanelPresenter>();
        }
        else
        {
            Debug.Log("WonPanelPresenter script has more then one realizations, all except one deleted.");
            Destroy(this);
        }
    }

    private void Start()
    {
        _wonPanel.SetActive(false);
        Player.Instance.PlayersFinishEnterer.PlayerFinished.AddListener(() => _wonPanel.SetActive(true));
    }

    public void ShowFinishPanel() =>_wonPanel.SetActive(true);
}
