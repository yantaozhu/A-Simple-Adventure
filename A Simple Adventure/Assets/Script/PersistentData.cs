using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    [SerializeField] AudioSource background;
    float backgroundVolume;
    int levelComplete, currentLevel;
    float level1Score, level2Score, level3Score, level4Score;
    int clueNumber;

    public static PersistentData Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        levelComplete = 0;
        level1Score = 9999f;
        level2Score = 9999f;
        level3Score = 9999f;
        level4Score = 9999f;
        backgroundVolume = 0.1f;
        background = GetComponent<AudioSource>();
        background.volume = backgroundVolume;
    }

    public void SetLevelComplete(int l)
    {
        if (l > levelComplete){
            levelComplete = l;
        }
    }

    public int GetLevelComplete()
    {
        return levelComplete;
    }

    public void SetCurrentLevel(int l)
    {
        currentLevel = l;
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    public void SetScore(int l, float score)
    {
        switch (l)
        {
            case 1:
                if (score < level1Score)
                {
                    level1Score = score;
                }
                break;
            case 2:
                if (score < level2Score)
                {
                    level2Score = score;
                }
                break;
            case 3:
                if (score < level3Score)
                {
                    level3Score = score;
                }
                break;
            case 4:
                if (score < level4Score)
                {
                    level4Score = score;
                }
                break;
            default:
                break;
        }
    }

    public float GetScore(int l)
    {
        switch (l)
        {
            case 1:
                return level1Score;
            case 2:
                return level2Score;
            case 3:
                return level3Score;
            case 4:
                return level4Score;
            default:
                return 0f;
        }
    }

    public void GenerateRandomClue()
    {
        clueNumber = Random.Range(1, 5);
    }

    public int GetClueNumber()
    {
        return clueNumber;
    }

    public void SetVolume(float vol)
    {
        backgroundVolume = vol;
        background.volume = backgroundVolume;
    }

    public float GetVolume()
    {
        return backgroundVolume;
    }
}
