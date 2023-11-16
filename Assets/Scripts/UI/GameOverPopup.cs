using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPopup : MonoBehaviour
{

    [SerializeField] private Button _replayBtn;

    private void Awake()
    {
        _replayBtn.onClick.AddListener(() => Replay());
    }

    private void Replay()
    {
        SceneTransitionManager.Instance.Replay();
    }

}
