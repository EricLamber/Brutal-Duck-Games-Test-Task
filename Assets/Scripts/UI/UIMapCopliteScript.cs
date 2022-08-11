using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIMapCopliteScript : MonoBehaviour
{
    private TextMeshProUGUI text;
    
    private Vector3 FinishPos;
    private float FullDistace;
    private float CurrentDistace;


    private void Start() 
    {
        text = GetComponent<TextMeshProUGUI>();
        FinishPos = GameObject.Find("Finish").transform.position;
        var StartPos = GameObject.Find("Player").transform.position;

        FullDistace = FinishPos.z - StartPos.z;
    }

    private void Update()
    {
        ChangeText(Calculating());
    }

    private float Calculating()
    {
        var CurrentPosition = GameObject.Find("Player").transform.position.z;
        CurrentDistace = FinishPos.z - CurrentPosition; 
        var result = CurrentDistace / FullDistace * 100;
        return result = 100 - result;
    }

    private void ChangeText(float percent)
    {
        text.text = $"Пройдено: {percent.ToString("0.0")}%";
    }
}
