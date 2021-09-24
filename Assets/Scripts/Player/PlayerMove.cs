using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    public float Speed => _speed;
    private Rigidbody _rb;
    private bool _isRun;


    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        PlayerController.instance.Run += SetRun;
        PlayerController.instance.SetSide += SetSide;

    }


    
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (!_isRun)
        {
            _rb.velocity = Vector3.zero;
            return;
        }

        _rb.velocity = transform.forward * Time.deltaTime * _speed;
    }

    private void SetRun(bool isRun)
    {
        _isRun = isRun;
    }

    private void SetSide(bool isRight)
    {
        if (!_isRun) return;
        var posX = 0;
        var angle = 0f;
        if (!isRight) 
        {
            if (transform.position.x == -3) return;
            angle = -90f;
            posX = -3; 
        }
        else
        {
            if (transform.position.x == 3) return;
            angle = 90f;
            posX = 3;
        }
        _isRun = false;
        var seq = DOTween.Sequence();
        seq.Append(transform.DOMove(new Vector3(transform.position.x + posX, transform.position.y, transform.position.z), 1f));
        seq.Join(transform.DORotate(new Vector3(0f, angle, 0f), 0.1f));
        seq.OnComplete(EndRunSide);

    }

    private void EndRunSide()
    {
        var seq = DOTween.Sequence();
        seq.Append(transform.DORotate(new Vector3(0f, 0f, 0f), 0.1f));
        seq.OnComplete(RunForward);
    }
    private void RunForward()
    {
        _isRun = true;
    }





   
}
