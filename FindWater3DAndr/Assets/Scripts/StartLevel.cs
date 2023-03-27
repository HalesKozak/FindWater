using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel : MonoBehaviour
{
    [SerializeField] private SpawnPrefab _spawnPrefab;
    [SerializeField] private StatsPlayer _statsPlayer;
    [SerializeField] private Timer _timer;

    [SerializeField] private ItemSObject countsGame;

    private void Start()
    {
        _statsPlayer.maxHeathPoint = countsGame.startCountHealthPoint;
        _timer.waterStartCount = countsGame.startCountWaterPoint;
        _statsPlayer.cactusDamagePoint = countsGame.start—actusDamagePoint;

        _statsPlayer.SliderHealthPointCount();
        _timer.StartTimer();

        for (int i = 0; i < countsGame.startCountBottles; i++)
        {
            _spawnPrefab.SpawnObj(0);
            _spawnPrefab.SpawnObj(1);
            _spawnPrefab.SpawnObj(2);
        }

        for (int i = 0; i < countsGame.startCountBonus; i++)
        {
            _spawnPrefab.SpawnObj(3);
            _spawnPrefab.SpawnObj(4);
            _spawnPrefab.SpawnObj(5);
        }
    }
}
