using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsProgressGame : MonoBehaviour
{
    [SerializeField] private Text[] statsProgressGameText;

    private float lifeTimeCount;

    public int bottlesPickUpCount;
    public int bonusPickUpCount;


    private void Start()
    {
        lifeTimeCount = 0;
    }

    private void Update()
    {
        lifeTimeCount += Time.deltaTime;
    }

    public void ShowStatsProgressGame()
    {
        statsProgressGameText[0].text = "�� ������� �� ����� ��� :" + string.Format("{0:F1}", lifeTimeCount / 60) + " ��";
        statsProgressGameText[1].text = "ϳ����� ������ � ����� :" + bottlesPickUpCount;
        statsProgressGameText[2].text = "ϳ����� ������ :" +  bonusPickUpCount;
    }
}
