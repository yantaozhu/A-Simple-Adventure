using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PointSystem : MonoBehaviour
{
    float currentScore;
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
        currentScore += Time.deltaTime;
        DisplayScore();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Fruit"))
        {
            currentScore -= 1f;
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
        string time;
        float min, sec;
        min = Mathf.FloorToInt(currentScore / 60);
        sec = Mathf.FloorToInt(currentScore % 60);
        time = string.Format("{0:00}:{1:00}", min, sec);
        scoreTxt.text = time;
    }
}
