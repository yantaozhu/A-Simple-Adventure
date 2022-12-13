using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsScore : MonoBehaviour
{
    [SerializeField] Text[] score;
    [SerializeField] GameObject[] button;
    int level;
    float levelScore;
    string time;
    float min, sec;

    // Start is called before the first frame update
    void Start()
    {
        level = PersistentData.Instance.GetLevelComplete();
        for (int i = 1; i <= level; i++)
        {
            levelScore = PersistentData.Instance.GetScore(i);
            min = Mathf.FloorToInt(levelScore / 60);
            sec = Mathf.FloorToInt(levelScore % 60);
            time = string.Format("{0:00}:{1:00}", min, sec);
            score[(i-1)].text = time;
        }
        for (int j = 1; j < 4; j++){
            if (j > level) {
                button[j].GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
            }
            else {
                button[j].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            }
        }
    }
}
