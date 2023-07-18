using UnityEngine;

public class AfterDeathLandingTracker : MonoBehaviour
{
    public static AfterDeathLandingTracker Instance { get; private set; }
    public bool HasLanded { get; private set; }

    private void Start()
    {
        if (Instance == null)
        {
            Instance = GetComponent<AfterDeathLandingTracker>();
            HasLanded = false;
            Player.Instance.PlayersKiller.PlayerDead.AddListener(() => InvokeRepeating(nameof(CheckToLandedState), 0, 0.5f));
        }
        else
        {
            Debug.Log("AfterDeathLandingTracker script has more then one realizations, all except one deleted.");
            Destroy(this);
        }
    }

    private void CheckToLandedState()
    {
        if (Player.Instance.PlayersRB.velocity.magnitude == 0)
        {
            HasLanded = true;
            ScoreBestPercentSaver.Instance.SaveScore();
            AfterDeathPanelPresenter.Instance.UpdateDeathPanelWhenDead();
            Destroy(this);
        }
    }
}
