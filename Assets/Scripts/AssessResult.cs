using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AssessResult : MonoBehaviour
{
    Dictionary<string, string> solution = new Dictionary<string, string>();
    private List<TextMeshProUGUI> characters = new List<TextMeshProUGUI>();
    private List<TextMeshProUGUI> answers = new List<TextMeshProUGUI>();

    [SerializeField] private GameObject prefabCharacter;
    [SerializeField] private GameObject resultGrid;

    public void AddResult()
    {
        solution.Add("Pieson", "Jordan");
        solution.Add("James", "Darren");
        solution.Add("Cristina", "Joshua");
        solution.Add("Robin", "Sarah");
        solution.Add("Cinnamon", "Jessy");
        solution.Add("Sarah", "James");
        solution.Add("Joshua", "Cinnamon");
        solution.Add("Jessy", "Pieson");
        solution.Add("Jordan", "Robin");
        solution.Add("Darren", "Cristina");
    }

    public void AddCharacters()
    {
        foreach (string key in solution.Keys)
        {
            GameObject newCharacter = Instantiate(prefabCharacter, resultGrid.transform);
            newCharacter.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = key;
            characters.Add(newCharacter.transform.Find("Name").GetComponent<TextMeshProUGUI>());
            answers.Add(newCharacter.transform.Find("Choice").transform.Find("Result").GetComponent<TextMeshProUGUI>());
        }
    }

    void Awake()
    {
        AddResult();
        AddCharacters();
    }

    public void AssessResults()
    {
        for (int character = 0; character < characters.Count; character++)
        {
            if (answers[character].text == solution[characters[character].text])
            {
                answers[character].color = Color.green;
            }
            else
            {
                answers[character].color = Color.red;
            }
        }
    }
}
