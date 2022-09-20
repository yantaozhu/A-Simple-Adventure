using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public void SetVolume(float v)
    {
        PersistentData.Instance.SetVolume(v);
    }
}
