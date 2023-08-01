using UnityEngine;
using UnityEngine.UI;

public class LocalizedImage : MonoBehaviour
{
    [SerializeField] private SpriteKeys _key;

    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
        UpdateAnImage();
        LanguagesContainer.Instance.LanguageChanged.AddListener(UpdateAnImage);
    }

    private void UpdateAnImage() =>
        _image.sprite = LanguagesContainer.Instance.SpritesDictionary[LanguagesContainer.GameLanguage][_key];
}
