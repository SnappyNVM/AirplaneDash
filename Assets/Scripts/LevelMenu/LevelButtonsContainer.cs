using UnityEngine;
using UnityEngine.UI;

public class LevelButtonsContainer : MonoBehaviour
{
    [SerializeField] private Button[] _levelButtons;
    [SerializeField] private int _unpassedLevelsOpenCount;
    public Button[] LevelButtons => _levelButtons;
    public static LevelButtonsContainer Instance { get; private set; }

    private void Start()
    {
        if (Instance == null)
        {
            Instance = GetComponent<LevelButtonsContainer>();
            _levelButtons = GetComponentsInChildren<Button>();
            UpdateLevelsAvailability();
        }
        else
        {
            Debug.Log("LevelButtonsContainer script has more then one realizations, all except one deleted.");
            Destroy(this);
        }
    }

    private void UpdateLevelsAvailability()
    {
        int passedLevelCount = 0;

        foreach (var button in _levelButtons)
        {
            button.interactable = false;
            if (button.GetComponent<LevelSelectButton>().IsLevelPassed)
                passedLevelCount++;
        }
        
        if (passedLevelCount + _unpassedLevelsOpenCount > _levelButtons.Length)
            _unpassedLevelsOpenCount = _levelButtons.Length - passedLevelCount;

        for (int i = 0; i < passedLevelCount + _unpassedLevelsOpenCount; i++)
            _levelButtons[i].interactable = true;
    }
}
