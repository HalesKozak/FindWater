using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoButton : MonoBehaviour
{
    public GameObject[] panels;

    public AudioSource openClosePanelSource;

    public void OpenClosePanels()
    {
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(!panels[i].activeSelf);
        }

        openClosePanelSource.Play();
    }
}
