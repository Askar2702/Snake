using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    #region Change Level
    [SerializeField] private Color[] _colors;
    [SerializeField] private MeshRenderer _roadMat;
    #endregion

    [SerializeField] private float _finishPosZ;
    #region UI
    [SerializeField] private Button _restartGame;
    [SerializeField] private Button _exitGame;
    #endregion

    private void Awake()
    {
        if (!instance) instance = this;
        _restartGame.onClick.AddListener(() => RestartGame());
        _exitGame.onClick.AddListener(() => ExitGame());
    }

    private void Start()
    {
        StartCoroutine(CheckPlayerPos());
        _roadMat.material.color = _colors[Random.Range(0, _colors.Length)];
    }
   

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    private IEnumerator CheckPlayerPos()
    {
        yield return new WaitUntil(() => PlayerController.instance.GetPosPlayer().z >= _finishPosZ);
        UiManager.instance.ShowPanelFinish();
    }

    public void LoseGame()
    {
        UiManager.instance.ShowPanelFinish();
    }

   
}
