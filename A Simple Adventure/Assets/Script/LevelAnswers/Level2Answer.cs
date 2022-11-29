using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level2Answer : MonoBehaviour
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
                correctAnswer = "3206";
                break;
            case 2:
                correctAnswer = "3793";
                break;
            case 3:
                correctAnswer = "8600";
                break;
            case 4:
                correctAnswer = "7035";
                break;
            case 5:
                correctAnswer = "4557";
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
