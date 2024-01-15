using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    public void GoBackToPreviousScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
    }
}
