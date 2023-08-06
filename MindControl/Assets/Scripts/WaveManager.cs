using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private SpawnManager _spawnManager;
    [SerializeField] private ControlsManager _controlsManager;
    [SerializeField] private TMP_Text _countdownText;
    private int _waveNumber = 1;
    private int _amountOfEnemies = 1;
    public static WaveManager Instance => _instance;

    private static WaveManager _instance;       

    private void Awake()
    {
        if (_instance != null && _instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            _instance = this; 
        }
    }

    private void Start()
    {
        StartCoroutine(StartRound());
        _countdownText.enabled = false;
    }

    private void Update()
    {
        if (_amountOfEnemies <= 0)
        {
            var enemies = _waveNumber;
            if(_waveNumber > 5)
            { 
                enemies = 5;
            }
            _amountOfEnemies = enemies;
            _controlsManager.ChangeControls();
            StartCoroutine(StartRound());
        }
    }

    private IEnumerator StartRound()
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

    public void EnemyDied()
    {
        _amountOfEnemies--;
    }
}
