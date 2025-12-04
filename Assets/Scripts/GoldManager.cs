using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GoldManager : MonoBehaviour
{
    public int goldAmount;
    public int power;
    public int powerAmount;
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI powerAText;
    public TextMeshProUGUI powerText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        power = 1;
        powerAmount = 10;
    }

    public void ChangeGold()
    {
        goldAmount += power;
        goldText.text = goldAmount.ToString("00");
    }

    public void ChangePower()
    {
        if (goldAmount > powerAmount)
        {
            goldAmount -= powerAmount;
            powerAmount = (int) MathF.Ceiling(powerAmount * 1.5f);
            goldText.text = goldAmount.ToString("00");
            powerAText.text = $"Upgrade for {powerAmount} G";
            powerText.text = power.ToString("00");
            power += 1;
        }
    }
    // Update is called once per frame
    void Update()
    {
        goldText.text = goldAmount.ToString("00");
    }
}
