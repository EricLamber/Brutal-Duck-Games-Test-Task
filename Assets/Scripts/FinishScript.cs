using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour
{
    void OnTriggerEnter()
    {
        GameObject.Find("BestTimeManager").GetComponent<BestTimeStorage>().Gettime();
        ButtonsScript.QuitButton();
    }
}
