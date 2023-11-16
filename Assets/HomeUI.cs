using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeUI : MonoBehaviour
{

    [SerializeField] private Button playBtn;
    [SerializeField] private Button howToPlayBtn;

    void Start()
    {
        playBtn.onClick.AddListener(() => GoToPlay());
        howToPlayBtn.onClick.AddListener(() => ShowHowToPlay());
    }

    private void GoToPlay()
    {
        SceneTransitionManager.Instance.OpenScene((int)SceneIndex.PlayScene);
    }

    private void ShowHowToPlay()
    {

    }
}
