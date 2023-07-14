using UnityEngine;
using UnityEngine.UI;

public class SwitchLanguageButton : MonoBehaviour
{
    [SerializeField] private Languages _languageToSwitch;

    private void Start() =>
        GetComponent<Button>().onClick.AddListener(() => LanguagesContainer.Instance.ChangeLanguage(_languageToSwitch));
}
