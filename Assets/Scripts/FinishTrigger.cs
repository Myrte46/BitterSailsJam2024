// FinishTrigger.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private TextAsset inkJSON;
    private bool playerInRange = false;

    private void Update()
    {
        if (playerInRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("EndScene", LoadSceneMode.Single);
            }

            // StartFinishDialogue should only be called once when isFinishDialogueActive is false
            if (!DialogueManager.Instance.isFinishDialogueActive)
            {
                DialogueManager.Instance.StartFinishDialogue(inkJSON);
            }
        }
        else
        {
            if (DialogueManager.Instance.isFinishDialogueActive)
            {
                StartCoroutine(DialogueManager.Instance.EndFinishDialogue());
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
