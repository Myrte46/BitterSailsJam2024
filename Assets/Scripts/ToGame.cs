using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToGame : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("SpeakingScene");
        }
    }
}
