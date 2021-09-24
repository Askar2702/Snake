using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using DG.Tweening;

public class UiManager : MonoBehaviour
{
    public static UiManager instance { get; private set; }
    public event Action<bool> Play;

    #region Timer
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private float _timer;
    #endregion

    #region Road Length
    [SerializeField] private Slider _roadLength;
    [SerializeField] private float _posStart;
    [SerializeField] private float _posFinish;
    #endregion

    #region Score
    [SerializeField] private TextMeshProUGUI _scoreText;
    public event Action ScoreChange;
    public int Score { get; private set; }
    #endregion

   

    #region Finish

    [SerializeField] private RectTransform _panelFinish;
    #endregion

    [SerializeField] private PlayerController _player;
    private void Awake()
    {
        if (!instance) instance = this;
    }
    private void Start()
    {
        StartCoroutine(StartGame());
    }
    private IEnumerator StartGame()
    {
        while (_timer > 0)
        {
            _timer -= Time.deltaTime;
            _timerText.text = _timer.ToString("f0");
            if (_timer <= 0) 
            {
                Play?.Invoke(true);
                _timerText.enabled = false;
            }
            
            yield return new WaitForSeconds(0.001f);
        }

        _roadLength.minValue = _posStart;
        _roadLength.maxValue = _posFinish;

        while (_roadLength.value != 170)
        {
            _roadLength.value = _player.GetPosPlayer().z;
            yield return new WaitForSeconds(0.001f);
        }
    }

    public void AddCoin(int value)
    {
        Score += value;
        _scoreText.text = Score.ToString();
        ScoreChange?.Invoke();
    }

   

    public void ShowPanelFinish()
    {
        _panelFinish.DOAnchorPos(Vector2.zero, 2f).SetEase(Ease.OutBounce);
        Play?.Invoke(false);
    }

   
   
}
