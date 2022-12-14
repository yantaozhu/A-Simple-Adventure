using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCredit : MonoBehaviour
{
    GameObject[] creditPanel;

    // Start is called before the first frame update
    void Start()
    {
        creditPanel = GameObject.FindGameObjectsWithTag("Credit");
        foreach (GameObject g in creditPanel)
            {
                g.SetActive(false);
            }
    }

    public void ShowCredit()
    {
        foreach (GameObject g in creditPanel)
            {
                g.SetActive(true);
            }
    }

    public void HideCredit()
    {
        foreach (GameObject g in creditPanel)
            {
                g.SetActive(false);
            }
    }
}
