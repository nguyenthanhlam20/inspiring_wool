using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaySceneUI : MonoBehaviour
{
    [SerializeField] private Button homeBtn;
    [SerializeField] private Button replayBtn;
    void Start()
    {
        homeBtn.onClick.AddListener(() => GoToHome());
        replayBtn.onClick.AddListener(() => Replay());
    }

    private void GoToHome()
    {
        SceneTransitionManager.Instance.OpenScene((int)SceneIndex.HomeScene);
    }


    private void Replay()
    {
        SceneTransitionManager.Instance.Replay();
    }
}
