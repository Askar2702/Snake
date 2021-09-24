using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coins : MonoBehaviour
{
    [SerializeField] private Transform[] _child;
    private void Start()
    {
        Rotation();
    }

    private void Rotation()
    {
        for(int i = 0; i < _child.Length; i++)
        {
            _child[i].DOLocalRotate(new Vector3(0f, 180, 0f), 3f).SetLoops(-1);
        }
    }
    
}
