using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level3Clue : MonoBehaviour
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
                clue.text = "15 ^ 2 * 8 + 16 * 3 / 4";
                break;
            case 2:
                clue.text = "(6649 + 3123) / (243 - 131) * 28";
                break;
            case 3:
                clue.text = "937 + 57 * (2152 / 269) ^ 2";
                break;
            case 4:
                clue.text = "57 ^ 2 * 4 ^ 3 / 2 ^ 6";
                break;
            case 5:
                clue.text = "2843 - (287 * 591 / 123 - 1678)";
                break;
            default:
                break;
        }
    }
}
