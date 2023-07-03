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
            PlayerFinished.AddListener(() => IsFinished = true);
            PlayerFinished.AddListener(() => Player.Instance.MakeThePlayerFall());
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
        PlayerFinished?.Invoke();
    }
}
