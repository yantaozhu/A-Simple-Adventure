using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level4Clue : MonoBehaviour
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
                clue.text = "27x / 3587 + 419 = 61x - 9! - 826 \n Find x.";
                break;
            case 2:
                clue.text = "26x - 8! - 9742 = (x - 4539) ^ 2 \n Find x.";
                break;
            case 3:
                clue.text = "391 * 284 - 67x = 6014 / 31 + 8x \n Find x.";
                break;
            case 4:
                clue.text = "x - 4509 + 2573 = (8814 - x) ^ 3 \n Find x.";
                break;
            case 5:
                clue.text = "83x / 2319 + 1057 = a / 6 - 157 \n Find x.";
                break;
            default:
                break;
        }
    }
}
