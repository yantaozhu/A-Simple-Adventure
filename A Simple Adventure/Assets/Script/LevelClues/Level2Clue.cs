using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2Clue : MonoBehaviour
{
    GameObject[] cluePanel;
    [SerializeField] Text clue;
    int clueNumber;

    // Start is called before the first frame update
    void Start()
    {
        PersistentData.Instance.GenerateRandomClue();
        clueNumber = PersistentData.Instance.GetClueNumber();
        SetClue();
        cluePanel = GameObject.FindGameObjectsWithTag("Clue");
        foreach (GameObject g in cluePanel)
            {
                g.SetActive(false);
            }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            foreach (GameObject g in cluePanel)
            {
                g.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        foreach (GameObject g in cluePanel)
            {
                g.SetActive(false);
            }
    }

    void SetClue()
    {
        switch (clueNumber)
        {
            case 1:
                clue.text = "6164 + 1287 - 4245";
                break;
            case 2:
                clue.text = "9764 - 4575 - 1396";
                break;
            case 3:
                clue.text = "2783 + 3854 + 1963";
                break;
            case 4:
                clue.text = "2345 - 2184 + 6874";
                break;
            case 5:
                clue.text = "1234 + 7890 - 4567";
                break;
            default:
                break;
        }
    }
}
