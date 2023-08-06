using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnpoints;
    [SerializeField] private GameObject _enemy;

    public void Spawn(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            var index = Random.Range(0, _spawnpoints.Count);
            Instantiate(_enemy, _spawnpoints[index].position, Quaternion.identity);
        }
    }
}
