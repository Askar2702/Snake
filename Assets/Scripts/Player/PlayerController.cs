using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance { get; private set; }
    public event Action<bool> Run;
    public event Action<bool> SetSide;


    #region Tail
    [SerializeField] private float _offsetZ;
    [SerializeField] private Tail _tail;
    public List<Transform> Tails = new List<Transform>();
    #endregion

    private void Awake()
    {
        if (!instance) instance = this;
    }
    void Start()
    {
        UiManager.instance.Play += SetStatePlayer;
        InputManager.instance.SetPoint += GetInput;
        UiManager.instance.ScoreChange += AddTail;
        Tails.Add(transform);
    }

    

    public void StopRun()
    {
        SetStatePlayer(false);
    }
    private void SetStatePlayer(bool isRun)
    {
        Run?.Invoke(isRun);
    }

    private void GetInput(float point)
    {
        if (point < 0) SetSide?.Invoke(true);
        else SetSide?.Invoke(false);
    }

    public Vector3 GetPosPlayer()
    {
        return transform.position;
    }

    private void AddTail()
    {
        Vector3 newTail = Tails[Tails.Count - 1].position;
        newTail.z -= _offsetZ;
        var tail = Instantiate(_tail, newTail, Quaternion.identity);
        Tails.Add(tail.transform);
    }
}
