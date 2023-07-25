using UnityEngine;

public class PauseMenuPresenter : MonoBehaviour
{
    [SerializeField] private GameObject _pauseButtonMenu;

    private void Awake() => _pauseButtonMenu.SetActive(false);

    public void EnablePauseMenu()
    {
        Time.timeScale = 0f;
        _pauseButtonMenu.SetActive(true);
    }

    public void DiablePauseMenu()
    {
        Time.timeScale = 1f;
        _pauseButtonMenu.SetActive(false);
    }
}