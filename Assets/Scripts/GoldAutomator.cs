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
    private string dec;
    private bool isCoroutineLaunched;
    private bool buttonActivate;
    public GameObject Mask;
    public TextMeshProUGUI priceText;
    public TextMeshProUGUI countText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        time = 1;
        buttonActivate = false;
        Mask.SetActive(buttonActivate);
        
    }

    public IEnumerator Givebysecond()
    {
        isCoroutineLaunched = true;
        while (true)
        {
            yield return new WaitForSeconds(time);
            goldA.goldAmount = goldA.goldAmount + giver;
            goldT.goldText.text = $"{goldA.goldAmount} G";
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
            goldT.goldText.text = $"{goldA.goldAmount} G";
            time = time * 0.9f;
            price = (int) MathF.Ceiling(price * 1.5f);
            priceText.text = $"{price} G";
            countText.text = $"({giver}G/{dec}s)";
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (buttonActivate == false & goldA.goldAmount >= price)
        {
            buttonActivate = true;
            Mask.SetActive(buttonActivate);
        }
        dec = time.ToString("0.00");
    }
}
