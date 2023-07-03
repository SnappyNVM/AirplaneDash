using UnityEngine;

public class FinishOnDeadCloser : MonoBehaviour
{
    private BoxCollider _finishTriggerCollider;
    private MeshRenderer _finishRenderer;

    private void Start()
    {
        _finishTriggerCollider  = GetComponent<BoxCollider>();
        _finishRenderer = GetComponent<MeshRenderer>();
        Player.Instance.PlayersKiller.PlayerDead.AddListener(() => _finishTriggerCollider.isTrigger = false);
        Player.Instance.PlayersKiller.PlayerDead.AddListener(() => _finishRenderer.enabled = true);
    }
}
