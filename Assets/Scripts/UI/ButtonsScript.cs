using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour
{
    static GameObject ca;
    
    void Awake()
    {
        if (ca = GameObject.Find("InGameMenu"))
            ca.SetActive(false);
    }

    public static void PlayButton() { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); }
    public static void QuitButton() { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); }
    public static void RstartButton() { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); }

    public static void PuseContinueButton() 
    { 
        ca.SetActive(!ca.activeSelf);
        GameObject.Find("TimeTxt").GetComponent<UiTimeScript>().Pausetime();
    }
}
