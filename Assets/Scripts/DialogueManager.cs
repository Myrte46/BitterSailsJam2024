// DialogueManager.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private Story currentStory;

    public bool isDialogueActive { get; private set; }
    public bool isFinishDialogueActive { get; private set; }

    private static DialogueManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("DialogueManager already exists!");
        }
        instance = this;
    }

    public static DialogueManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogWarning("DialogueManager does not exist!");
            }
            return instance;
        }
    }

    private void Start()
    {
        isDialogueActive = false;
        dialoguePanel.SetActive(false);
    }

    private void Update()
    {
        if (!isDialogueActive) return;

        if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !isFinishDialogueActive)
        {
            RefreshDialogueText();
        }
    }

    public void StartDialogue(TextAsset inkJSON)
    {
        isDialogueActive = true;
        dialoguePanel.SetActive(true);

        currentStory = new Story(inkJSON.text);
        dialogueText.text = currentStory.currentText;
    }

    public void StartFinishDialogue(TextAsset inkJSON)
    {
        isFinishDialogueActive = true;
        dialoguePanel.SetActive(true);

        currentStory = new Story(inkJSON.text);
        dialogueText.text = currentStory.currentText;
        Debug.Log(inkJSON.text);
    }

    public void RefreshDialogueText()
    {
        if (currentStory.canContinue)
        {
            Debug.Log("can continue");
            dialogueText.text = currentStory.Continue();
        }
        else
        {
            StartCoroutine(EndDialogue());
        }
    }

    public IEnumerator EndDialogue()
    {
        yield return new WaitForSeconds(0.2f);
        isDialogueActive = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    public IEnumerator EndFinishDialogue()
    {
        yield return new WaitForSeconds(0.2f);
        isFinishDialogueActive = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }
}
