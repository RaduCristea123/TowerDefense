using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 250;
    public Text textMoney;
    public Text textWave;
    private string moneyStr;
    public static int wave;
    public string waveStr;

    public int startLives = 10;
    public static int lives;

    void Start()
    {
        Money = startMoney;
        lives = startLives;
        wave = 1;
        
    }
    void Update()
    {
        moneyStr = "$" + Money.ToString();
        textMoney.text = moneyStr;
        wave = WaveSpawner.waveNo - 1;
        if (wave > 0)
        {
            waveStr = "Wave\n" + wave.ToString();
            textWave.text = waveStr;
        }
    }


}
