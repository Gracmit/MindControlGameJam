using System.Collections;
using TMPro;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private SpawnManager _spawnManager;
    [SerializeField] private TMP_Text _countdownText;
    private int _waveNumber = 1;

    private void Start()
    {
        StartCoroutine(StartGame());
        _countdownText.enabled = false;
    }

    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(5f);

        _countdownText.enabled = true;
        
        for (int i = 10; i > 0; i--)
        {
            _countdownText.SetText(i.ToString());
            yield return new WaitForSeconds(1f);
        }

        _countdownText.enabled = false;
        StartWave();
    }

    public void StartWave()
    {
        var spawnAmount = _waveNumber;
       
        if(_waveNumber > 5)
        { 
            spawnAmount = 5;
        }
        
        _spawnManager.Spawn(spawnAmount);
        _waveNumber++;
    }
}
