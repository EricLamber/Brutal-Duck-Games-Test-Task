using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiTimeScript : MonoBehaviour
{
    TextMeshProUGUI text;

    private float time;

    private bool timePause = true;

    private void Start() { text = GetComponent<TextMeshProUGUI>(); }  

    private void Update()
    {
        if (timePause)
            time += Time.deltaTime;

        UITimeChange();
    }

    private void UITimeChange() { text.text = $"Время: {time.ToString("0.0000")}"; }

    public void Pausetime() { timePause = !timePause; }
     
    public float GetTime() { return time; }

}
