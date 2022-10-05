using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PointSystem : MonoBehaviour
{
    int currentScore;
    int currentLevel;
    [SerializeField] Text scoreTxt;

    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        currentLevel = PersistentData.Instance.GetCurrentLevel();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayScore();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Fruit"))
        {
            currentScore += 100;
            Destroy(collider.gameObject);
        }

        if (collider.gameObject.CompareTag("End"))
        {
            PersistentData.Instance.SetScore(currentLevel,currentScore);
            PersistentData.Instance.SetLevelComplete(currentLevel);
            SceneManager.LoadScene("LevelList");
        }
    }

    void DisplayScore()
    {
        scoreTxt.text = "Score: " + currentScore;
    }
}
