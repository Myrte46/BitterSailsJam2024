using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBack : MonoBehaviour
{
    public void GoBackToPreviousScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SpeakingScene");
    }
}
