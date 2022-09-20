using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsScore : MonoBehaviour
{
    [SerializeField] Text[] score;
    int level;
    int levelScore;

    // Start is called before the first frame update
    void Start()
    {
        level = PersistentData.Instance.GetLevel();
        for (int i = 1; i < level; i++)
        {
            levelScore = PersistentData.Instance.GetScore(i);
            score[i].text = levelScore.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
