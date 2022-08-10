using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIPowerScript : MonoBehaviour
{
    private TextMeshProUGUI text;

    private PlayerControl playercontrol;

    private Vector3 maxPower = new Vector3(0.1f, 0.1f, 0);

    private void Start() 
    { 
        text = GetComponent<TextMeshProUGUI>();
        playercontrol = GameObject.Find("Player").GetComponent<PlayerControl>();
    }

    private void Update()
    {
        ChangeText(Calculating());
    }

    private float Calculating()
    {
        var Power = playercontrol.GetCurrentPower();
        if (Power.x < 0) Power.x *= -1;
        if (Power.y < 0) Power.y *= -1;

        var Xpower = Power.x/maxPower.x * 100;
        var Ypower = Power.y/maxPower.y * 100;

        var result = 0f;

        if (Xpower > Ypower) result = Xpower;
        if(Ypower > Xpower) result = Ypower;
        if(result < 0) result = 0;
        if(result > 100) result = 100;

        return result;
    }

    private void ChangeText(float percent)
    {
        text.text = $"Сила натяжения: {percent.ToString("0.0")}%";
    }
}
