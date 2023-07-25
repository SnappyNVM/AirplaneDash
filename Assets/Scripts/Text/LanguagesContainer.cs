using System;
using System.Collections.Generic;
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

public class LanguagesContainer : MonoBehaviour
{
    private static Languages gameLanguage = Languages.Russian;

    public static LanguagesContainer Instance { get; private set; }
    public static Languages GameLanguage => gameLanguage;
    public Dictionary<Languages, Dictionary<string, string>> WordsDictionary { get; set; }
    public UnityEvent LanguageChanged;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = GetComponent<LanguagesContainer>();
            FillWordsDictionary();
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
        WordsDictionary = new Dictionary<Languages, Dictionary<string, string>>()
        {
            [Languages.Russian] = new Dictionary<string, string>()
            {
                ["yourScore"] = "Твой счёт: ",
                ["best"] = "Рекорд: ",
                ["gameOver"] = "Ты разбился",
                ["sounds"] = "Звуки",
                ["levelPassed"] = "Уровень пройден!",
                ["levelSelect"] = "Выбор уровня:",
                ["music"] = "Музыка:",
                ["language"] = "Язык:",
                ["gamePaused"] = "Игра на паузе..."
            },

            [Languages.English] = new Dictionary<string, string>()
            {
                ["yourScore"] = "Your score: ",
                ["best"] = "Best: ",
                ["gameOver"] = "You crashed",
                ["sounds"] = "Sounds",
                ["levelPassed"] = "Level passed!",
                ["levelSelect"] = "Level select:",
                ["music"] = "Music:",
                ["language"] = "Language:",
                ["gamePaused"] = "Game paused..."
            },

            [Languages.Turkish] = new Dictionary<string, string>()
            {
                ["yourScore"] = "Puanınız ",
                ["best"] = "En iyisi ",
                ["gameOver"] = "Kaybettin",
                ["sounds"] = "Sesler",
                ["levelPassed"] = "Seviye Geçti!",
                ["levelSelect"] = "Seviye seçimi:",
                ["music"] = "Müzik:",
                ["language"] = "Dil:",
                ["gamePaused"] = "Oyun duraklatıldı..."
            }
        };
    }
}


