using System;
using DogukanKarabiyik.RunnerGame.Managers;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public Action onMoneyTaken;
    public Action onMoneySpend;

    private const string COIN_KEY = "coin";

    private int totalCoins;

    public int TotalCoins => totalCoins;

    private void Awake()
    {
        totalCoins = LoadCoin();
    }

    public void TakeCoin( int amount)
    {
        totalCoins += amount;
        onMoneyTaken?.Invoke();
    }

    public bool SpendCoin(int amount)
    {
        if (amount <= totalCoins)
        {
            totalCoins -= amount;
            onMoneySpend?.Invoke();
            SaveCoin();
            return true;
        }
        else
            return false;
    }

    private int LoadCoin()
    {
        return PlayerPrefs.GetInt(COIN_KEY);
    }

    private void SaveCoin()
    {
        PlayerPrefs.SetInt(COIN_KEY, totalCoins);
    }

    private void OnEnable()
    {
        StaticGameManager.OnLevelSuccess += SaveCoin;
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        SaveCoin();
    }

    private void OnApplicationQuit()
    {
        SaveCoin();
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        SaveCoin();
    }

    private void OnDisable()
    {
        StaticGameManager.OnLevelSuccess -= SaveCoin;
    }
}
