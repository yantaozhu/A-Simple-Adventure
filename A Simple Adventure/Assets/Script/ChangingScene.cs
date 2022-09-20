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
        int level = PersistentData.Instance.GetLevel();
        if (scene <= level)
        {
            SceneManager.LoadScene("Level" + scene);
        }
    }
}
