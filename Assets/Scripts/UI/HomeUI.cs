using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeUI : MonoBehaviour
{

    [SerializeField] private Button playBtn;
    [SerializeField] private Button howToPlayBtn;
    [SerializeField] private Button closeBtn;
    [SerializeField] private GameObject howToPlayPopup;
    [SerializeField] private GameObject backgroundBlur;

    private void Awake()
    {
        howToPlayPopup.SetActive(false);
        backgroundBlur.SetActive(false);
    }

    void Start()
    {
        playBtn.onClick.AddListener(() => GoToPlay());
        howToPlayBtn.onClick.AddListener(() => ShowHowToPlay());
        closeBtn.onClick.AddListener(() => CloseHowToPlay());
    }

    private void GoToPlay()
    {
        SceneTransitionManager.Instance.OpenScene((int)SceneIndex.PlayScene);
    }

    private void ShowHowToPlay()
    {
        backgroundBlur.SetActive(true);
        howToPlayPopup.SetActive(true);
        LeanTween.moveLocal(howToPlayPopup, Vector3.zero, 1f)
          .setEase(LeanTweenType.easeOutExpo);
    }  
    
    private void CloseHowToPlay()
    {
        LeanTween.moveLocal(howToPlayPopup, new Vector3(0f, 700f, 1f), 0.5f)
          .setEase(LeanTweenType.easeInQuad)
          .setOnComplete(() =>
          {
              howToPlayPopup.SetActive(false);
              backgroundBlur.SetActive(false);
          });
    }
}
