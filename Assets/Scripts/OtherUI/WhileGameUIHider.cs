using UnityEngine;

public class WhileGameUIHider : MonoBehaviour
{
    [SerializeField] private GameObject _onGameUI;

    private void Start()
    { 
        Player.Instance.PlayersKiller.PlayerDead.AddListener(HideUI);
        Player.Instance.PlayersFinishEnterer.PlayerFinished.AddListener(HideUI);
    }

    public void HideUI() => _onGameUI.SetActive(false);
    public void ShowUI() => _onGameUI.SetActive(true);
}
