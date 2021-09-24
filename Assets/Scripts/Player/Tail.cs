using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{
    [SerializeField] private float _speed;
    private bool _isRun = true;
    private Transform _tailTarget;
    private PlayerMove _snakeHead;
    void Start()
    {
        UiManager.instance.Play += SetRun;
        _snakeHead = FindObjectOfType<PlayerMove>();
        _speed = _snakeHead.Speed;
        _tailTarget = PlayerController.instance.Tails[PlayerController.instance.Tails.Count - 2];
    }

   
    void FixedUpdate()
    {
        if (!_isRun) return;
        transform.LookAt(_tailTarget);
        transform.position = Vector3.Lerp(transform.position, _tailTarget.position, Time.deltaTime * _speed / 70);
    }

    private void SetRun(bool isrun)
    {
        _isRun = isrun;
    }
}
