using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private int _cointEnemy;
    [SerializeField] private float _posZ;
    [SerializeField] private float[] _posX;
    void Start()
    {
        SpawnCoins();
    }

    private void SpawnCoins()
    {
        for (int i = 0; i < _cointEnemy; i++)
        {
            var coins = Instantiate(_enemy);
            var pos = new Vector3(_posX[Random.Range(0, _posX.Length)], 0f, _posZ + 7 * i);
            coins.transform.position = pos;
        }
    }
}
