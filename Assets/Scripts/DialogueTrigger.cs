using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] TextAsset inkJSON;

    private bool playerInRange = false;

    private void Awake(){
        visualCue.SetActive(false);
    }

    private void Update(){
        if (playerInRange && !DialogueManager.Instance.isDialogueActive){
            visualCue.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
                DialogueManager.Instance.StartDialogue(inkJSON);
            }
        } else {
            visualCue.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player"){
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.tag == "Player"){
            playerInRange = false;
        }
    }
}
