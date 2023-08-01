using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class LocalizedText : MonoBehaviour
{
    [SerializeField] protected TextKeys _key;

    protected TMP_Text _selfText;

    private void Start()
    {
        LanguagesContainer.Instance.LanguageChanged.AddListener(UpdateText);
        _selfText = GetComponent<TMP_Text>();
        UpdateText();
    }

    protected virtual void UpdateText() =>
        _selfText.text = LanguagesContainer.Instance.WordsDictionary[LanguagesContainer.GameLanguage][_key];
}

