using System;
using System.Collections;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class GoldAutomator : MonoBehaviour
{
    public GoldManager goldA;
    public GoldManager goldT;
    public int price;
    public int giver;
    public float time;
    private bool isCoroutineLaunched;
    public TextMeshProUGUI priceText;
    public TextMeshProUGUI countText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        time = 1;
    }

    public IEnumerator Givebysecond()
    {
        isCoroutineLaunched = true;
        while (true)
        {
            yield return new WaitForSeconds(time);
            goldA.goldAmount = goldA.goldAmount + giver;
            goldT.goldText.text = goldA.goldAmount.ToString("00");
        }
    }

    public void ChangeAuto()
    {
        if (goldA.goldAmount >= price)
        {
            if(isCoroutineLaunched == false)
            {
                StartCoroutine( Givebysecond());
            }
            goldA.goldAmount -= price;
            goldT.goldText.text = goldA.goldAmount.ToString("00");
            time = time * 0.9f;
            price = (int) MathF.Ceiling(price * 1.5f);
            priceText.text = $"{price} G";
            countText.text = $"({giver}G/{time}s)";
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
