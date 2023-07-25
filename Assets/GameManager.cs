using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //static Variables
    public static float cheeses = 0;
    public static float cheesesPerClick = 1;
    public static float cheesesPerSecond = 1;
    public static float multiplier = 1;


    //Text References
    [SerializeField] private Text cheesesText;


    private void Start()
    {
        Load();
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    private void Update()
    {
        cheeses += cheesesPerSecond * multiplier * Time.deltaTime;
        UpdateTexts();
    }

    private void UpdateTexts()
    {
        cheesesText.text = Mathf.Round(cheeses).ToString() + " Cheeses";
    }

    private void Load()
    {
        GameData savedData = SaveSystem.LoadGameData();
        cheeses = savedData.cheeses;
        cheesesPerClick = savedData.cheesesPerClick;
        cheesesPerSecond = savedData.cheesesPerSecond;
        multiplier = savedData.multiplier;
    }

    private void Save()
    {
        GameData data = new GameData();

        data.cheeses = cheeses;
        data.cheesesPerClick = cheesesPerClick;
        data.multiplier = multiplier;
        data.cheesesPerSecond = cheesesPerSecond;

        SaveSystem.SaveGameData(data);
    }
}
