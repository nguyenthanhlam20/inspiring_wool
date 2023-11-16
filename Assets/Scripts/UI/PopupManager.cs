using UnityEngine;

public class PopupManager : MonoBehaviour
{

    // Declaration of a public static variable named Instance of type SoundManager
    public static PopupManager Instance;
    [SerializeField] private GameObject _gameOverPopup;
    [SerializeField] private GameObject _blurBackground;

    [SerializeField] private Vector2 centerPosition;

    private void Awake()
    {
        // Checking if the Instance variable is null
        if (Instance == null)
        {
            // Assigning the current instance to the Instance variable
            Instance = this;
        }
        else
        {
            // Destroys the duplicate instance of the SoundManager if it already exists
            Destroy(gameObject);
        }
        _blurBackground.SetActive(false);
        _gameOverPopup.SetActive(false);
    }

    public void ShowGameOverPopup()
    {
        AudioManager.Instance.PlayMusic(false);
        AudioManager.Instance.PlayEffectByIndex(AudioIndex.GameOver);
        BasketPool.Instance.gameObject.SetActive(false);
        _blurBackground.SetActive(true);
        _gameOverPopup.SetActive(true);

        _gameOverPopup.GetComponent<GameOverPopup>().ShowScore();
        LeanTween.moveLocal(_gameOverPopup, centerPosition, 1f)
            .setEase(LeanTweenType.easeOutExpo)
            .setOnComplete(() =>
            {
                Time.timeScale = 0f;
            });
    }

}
