using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    [SerializeField] private Coins _coins;
    [SerializeField] private int _cointCoins;
    [SerializeField] private float _posZ;
    [SerializeField] private float[] _posX;
    void Start()
    {
        SpawnCoins();
    }

    private void SpawnCoins()
    {
        for(int i = 0; i < _cointCoins; i++)
        {
            var coins = Instantiate(_coins);
            var pos = new Vector3(_posX[Random.Range(0, _posX.Length)], 0f, _posZ + 5 * i);
            coins.transform.position = pos;
        }
    }
}
