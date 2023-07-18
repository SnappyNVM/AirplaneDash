using UnityEngine;
using UnityEngine.Events;

public class FinishEnterer : MonoBehaviour
{
    private static FinishEnterer _instance;
    public UnityEvent PlayerFinished;
    public bool IsFinished { get; private set; }

    private void Awake()
    {
        if (_instance == null)
        {
            PlayerFinished.AddListener(() => Player.Instance.PlayersFallingDoer.MakeThePlayerFall());
            // 100 Isn't magic number probably? It's just a max percent :/
            PlayerFinished.AddListener(() => ScoreBestPercentSaver.Instance.SaveScore(100)); 
            _instance = GetComponent<FinishEnterer>();
        }
        else
        {
            Debug.Log("FinishEnterer script has more then one realizations, all except one deleted.");
            Destroy(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        IsFinished = true;
        PlayerFinished?.Invoke();
    }
}
