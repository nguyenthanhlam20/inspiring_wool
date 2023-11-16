using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPopup : MonoBehaviour
{

    [SerializeField] private Button _replayBtn;
    [SerializeField] private TextMeshProUGUI _bestScore;
    [SerializeField] private TextMeshProUGUI _score;

    private void Awake()
    {
        _replayBtn.onClick.AddListener(() => Replay());
    }

    private void Replay()
    {
        AudioManager.Instance.PlayMusic(true);
        Time.timeScale = 1f;
        SceneTransitionManager.Instance.Replay();
    }

    public void ShowScore()
    {
        int bestScore = UserDataManager.Instance.UserData.BestScore;
        int score = PlayerStatManager.Instance.Score;

        if(score > bestScore)
        {
            UserDataManager.Instance.UserData.BestScore = score;
            UserDataManager.Instance.SaveUserData();
        }

        _bestScore.text = bestScore.ToString();
        _score.text = score.ToString();
    }

}
