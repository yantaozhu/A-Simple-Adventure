using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] Slider volumeBar;
    float volume;

    // Start is called before the first frame update
    void Start()
    {
        volume = PersistentData.Instance.GetVolume();
        volumeBar.value = volume;
    }

    public void SetVolume(float v)
    {
        PersistentData.Instance.SetVolume(v);
    }
}
