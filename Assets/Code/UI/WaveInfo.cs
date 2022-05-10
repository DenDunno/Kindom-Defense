using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveInfo : MonoBehaviour
{
    [SerializeField] private WaveList _waveList;
    [SerializeField] private Slider _waveTime;
    [SerializeField] private TMP_Text _waveCount;
    [SerializeField] private TMP_Text _currentWave;
    [SerializeField] private TMP_Text _nextWave;
    
    private void Start()
    {
        SetWaveInfo(0);
        StartCoroutine(StartCountDown());
    }

    private IEnumerator StartCountDown()
    {
        for (int i = 0; i < _waveList.Count; ++i)
        {
            SetWaveInfo(i);
            float timeForWave = GetWaveTime(i);

            for (float time = 0; time < timeForWave; time += Time.deltaTime)
            {
                _waveTime.value = time / timeForWave;
                yield return null;
            }
        }
    }

    private void SetWaveInfo(int waveIndex)
    {
        _waveCount.text = $"Wave {waveIndex + 1} / {_waveList.Count}";
        _currentWave.text = (waveIndex + 1).ToString();
        _nextWave.text = waveIndex == _waveList.Count - 1 ? string.Empty : (waveIndex + 2).ToString();
    }

    private float GetWaveTime(int waveIndex)
    {
        Wave wave = _waveList[waveIndex];
        float totalTime = 0;

        foreach (EnemiesGroup enemiesGroup in wave.EnemiesGroups)
        {
            totalTime += enemiesGroup.Delay;
            totalTime += enemiesGroup.SpawnRate * enemiesGroup.Enemies.Count;
        }

        return totalTime;
    }
}