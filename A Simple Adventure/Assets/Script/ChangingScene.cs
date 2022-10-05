using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangingScene : MonoBehaviour
{
    public void ChangeSceneTo(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    
    public void CheckLevelOpen(int scene)
    {
        int levelComplete = PersistentData.Instance.GetLevelComplete();
        if (scene <= (levelComplete + 1))
        {
            PersistentData.Instance.SetCurrentLevel(scene);
            SceneManager.LoadScene("Level" + scene);
        }
    }
}
