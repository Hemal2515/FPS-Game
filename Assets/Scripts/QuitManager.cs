using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitManager : MonoBehaviour
{
    public void QuitButton()
    {
        Application.Quit();
    }
    public void StartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void ReStartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
