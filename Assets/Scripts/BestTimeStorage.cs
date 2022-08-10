using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BestTimeStorage : MonoBehaviour
{
    private float BestTime;
    private float time;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        ClearingCopies();

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            CengeTime();
        }
    }

    private void CengeTime()
    {
        if (time < BestTime || BestTime == 0) {
            BestTime = time;
            GameObject.Find("BestTimeScore").GetComponent<TextMeshProUGUI>().text = $"Лучшее время: {BestTime.ToString("0.0000")}";
        }
    }

    private void ClearingCopies()
    {
        GameObject copy;
        if (copy = GameObject.Find("BestTimeManager"))
            if (copy != gameObject)
                Destroy(copy);
    }

    public void Gettime() { time = GameObject.Find("TimeTxt").GetComponent<UiTimeScript>().GetTime(); }
}
