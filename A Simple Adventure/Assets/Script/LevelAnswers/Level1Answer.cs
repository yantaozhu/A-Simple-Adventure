using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level1Answer : MonoBehaviour
{
    int clueNumber;
    string correctAnswer;
    GameObject[] door;
    GameObject[] inputCluePanel;
    [SerializeField] InputField answer;

    // Start is called before the first frame update
    void Start()
    {
        inputCluePanel = GameObject.FindGameObjectsWithTag("InputClue");
        foreach (GameObject g in inputCluePanel)
        {
            g.SetActive(false);
        }

        door = GameObject.FindGameObjectsWithTag("Door");
        foreach (GameObject g in door)
        {
            g.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        clueNumber = PersistentData.Instance.GetClueNumber();
        switch (clueNumber)
        {
            case 1:
                correctAnswer = "0123";
                break;
            case 2:
                correctAnswer = "1234";
                break;
            case 3:
                correctAnswer = "4321";
                break;
            case 4:
                correctAnswer = "2468";
                break;
            case 5:
                correctAnswer = "8642";
                break;
            default:
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            foreach (GameObject g in inputCluePanel)
            {
                g.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        foreach (GameObject g in inputCluePanel)
            {
                g.SetActive(false);
            }
    }

    public void CheckAnswer()
    {
        if (answer.text == correctAnswer)
        {
            foreach (GameObject g in door)
            {
                g.SetActive(false);
            }

            foreach (GameObject g in inputCluePanel)
            {
                g.SetActive(false);
            }
        }
        else
        {
            answer.text = "";
        }
    }
}
