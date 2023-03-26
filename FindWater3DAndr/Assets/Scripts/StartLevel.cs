using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel : MonoBehaviour
{
    [SerializeField] private SpawnPrefab _spawnPrefab;
    [SerializeField] private StatsPlayer _statsPlayer;
    [SerializeField] private Timer _timer;

    [SerializeField] private ItemSObject countsGame;


    public int startCountBottles;
    public int startCountBonus;

    public float startCountHealthPoint;
    public float startCountWaterPoint;

    private void Start()
    {
        startCountHealthPoint = countsGame.startCountHealthPoint;
        startCountWaterPoint = countsGame.startCountWaterPoint;
        startCountBottles = countsGame.startCountBottles;
        startCountBonus = countsGame.startCountBonus;

        _statsPlayer.heathPoint = startCountHealthPoint;
        _timer.waterStartCount = startCountWaterPoint;

        _statsPlayer.SliderHealthPointCount();
        _timer.StartTimer();

        for (int i = 0; i < startCountBottles; i++)
        {
            _spawnPrefab.SpawnObj(0);
            _spawnPrefab.SpawnObj(1);
            _spawnPrefab.SpawnObj(2);
        }

        for (int i = 0; i < startCountBonus; i++)
        {
            _spawnPrefab.SpawnObj(3);
            _spawnPrefab.SpawnObj(4);
            _spawnPrefab.SpawnObj(5);
        }
    }
}
