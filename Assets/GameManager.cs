using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //static Variables
    public static float cheeses;
    public static float cheesesPerClick;
    public static float cheesesPerSecond;
    public static float multiplier = 1;


    //Text References
    [SerializeField] private Text cheesesText;


    private void Start()
    {
        cheesesPerSecond = 1;
    }

    private void Update()
    {
        cheeses += cheesesPerSecond * multiplier * Time.deltaTime;
        UpdateTexts();
    }

    private void UpdateTexts()
    {
        cheesesText.text = (Mathf.Round(cheeses * 100)/100).ToString() + " Cheeses";
    }
}
