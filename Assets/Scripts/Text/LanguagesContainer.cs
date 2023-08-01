using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public enum Languages
{
    Russian = 0,
    English = 1,
    Turkish = 2
}

public enum TextKeys
{
    yourScore,
    best,
    gameOver,
    sounds,
    levelPassed,
    levelSelect,
    music,
    language,
    gamePaused
}

public enum SpriteKeys
{ 
    logo
}

public class LanguagesContainer : MonoBehaviour
{
    [SerializeField] private Sprite _russianLogo;
    [SerializeField] private Sprite _englishLogo;
    [SerializeField] private Sprite _turkishLogo;

    private static Languages gameLanguage = Languages.Russian;

    public static LanguagesContainer Instance { get; private set; }
    public static Languages GameLanguage => gameLanguage;
    public Dictionary<Languages, Dictionary<TextKeys, string>> WordsDictionary { get; private set; }
    public Dictionary<Languages, Dictionary<SpriteKeys, Sprite>> SpritesDictionary { get; private set; }
    public UnityEvent LanguageChanged;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = GetComponent<LanguagesContainer>();
            FillWordsDictionary();
            FillSpritesDictionary();
        }
        else
        {
            Debug.Log("LanguagesContainer script has more then one realizations, all except one deleted.");
            Destroy(this);
        }
    }

    public void ChangeLanguage(Languages language)
    {
        gameLanguage = language;
        LanguageChanged?.Invoke();
    }

    private void FillWordsDictionary()
    {
        WordsDictionary = new Dictionary<Languages, Dictionary<TextKeys, string>>()
        {
            [Languages.Russian] = new Dictionary<TextKeys, string>()
            {
                [TextKeys.yourScore] = "Твой счёт: ",
                [TextKeys.best] = "Рекорд: ",
                [TextKeys.gameOver] = "Ты разбился",
                [TextKeys.sounds] = "Звуки",
                [TextKeys.levelPassed] = "Уровень пройден!",
                [TextKeys.levelSelect] = "Выбор уровня:",
                [TextKeys.music] = "Музыка:",
                [TextKeys.language] = "Язык:",
                [TextKeys.gamePaused] = "Игра на паузе..."
            },

            [Languages.English] = new Dictionary<TextKeys, string>()
            {
                [TextKeys.yourScore] = "Your score: ",
                [TextKeys.best] = "Best: ",
                [TextKeys.gameOver] = "You crashed",
                [TextKeys.sounds] = "Sounds",
                [TextKeys.levelPassed] = "Level passed!",
                [TextKeys.levelSelect] = "Level select:",
                [TextKeys.music] = "Music:",
                [TextKeys.language] = "Language:",
                [TextKeys.gamePaused] = "Game paused..."
            },

            [Languages.Turkish] = new Dictionary<TextKeys, string>()
            {
                [TextKeys.yourScore] = "Puanınız ",
                [TextKeys.best] = "En iyisi ",
                [TextKeys.gameOver] = "Kaybettin",
                [TextKeys.sounds] = "Sesler",
                [TextKeys.levelPassed] = "Seviye Geçti!",
                [TextKeys.levelSelect] = "Seviye seçimi:",
                [TextKeys.music] = "Müzik:",
                [TextKeys.language] = "Dil:",
                [TextKeys.gamePaused] = "Oyun duraklatıldı..."
            }
        };
    }

    private void FillSpritesDictionary()
    {
        SpritesDictionary = new Dictionary<Languages, Dictionary<SpriteKeys, Sprite>>()
        {
            [Languages.Russian] = new Dictionary<SpriteKeys, Sprite>()
            {
                [SpriteKeys.logo] = _russianLogo
            },

            [Languages.English] = new Dictionary<SpriteKeys, Sprite>()
            {
                [SpriteKeys.logo] = _englishLogo
            },

            [Languages.Turkish] = new Dictionary<SpriteKeys, Sprite>()
            {
                [SpriteKeys.logo] = _turkishLogo
            }
        };
    }
}


