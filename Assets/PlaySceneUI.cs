using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaySceneUI : MonoBehaviour
{
    [SerializeField] private Button homeBtn;
    [SerializeField] private Button replayBtn;
    [SerializeField] private Button showGameOverBtn;
    void Start()
    {
        homeBtn.onClick.AddListener(() => GoToHome());
        replayBtn.onClick.AddListener(() => Replay());
        showGameOverBtn.onClick.AddListener(() => ShowGameOver());
    }

    private void GoToHome()
    {
        SceneTransitionManager.Instance.OpenScene((int)SceneIndex.HomeScene);
    }
    private void ShowGameOver()
    {
        PopupManager.Instance.ShowGameOverPopup();

    }

    private void Replay()
    {
        SceneTransitionManager.Instance.Replay();
    }
}
