using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    [SerializeField] AudioSource background;
    float backgroundVolume;
    int level;
    int level1Score, level2Score, level3Score, level4Score;

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
        level = 1;
        background = GetComponent<AudioSource>();
        backgroundVolume = 0.5f;
    }

    public void SetLevel(int l)
    {
        level = l;
    }

    public int GetLevel()
    {
        return level;
    }

    public void SetScore(int l, int score)
    {
        switch (l)
        {
            case 1:
                level1Score = score;
                break;
            case 2:
                level2Score = score;
                break;
            case 3:
                level3Score = score;
                break;
            case 4:
                level4Score = score;
                break;
            default:
                break;
        }
    }

    public int GetScore(int l)
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
                return 0;
        }
    }

    public void SetVolume(float vol)
    {
        backgroundVolume = vol;
        background.volume = backgroundVolume;
    }
}
