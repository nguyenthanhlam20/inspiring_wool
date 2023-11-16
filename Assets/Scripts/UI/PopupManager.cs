using UnityEngine;

public class PopupManager : MonoBehaviour
{

    // Declaration of a public static variable named Instance of type SoundManager
    public static PopupManager Instance;
    [SerializeField] private GameObject _gameoverPopup;
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
        _gameoverPopup.SetActive(false);
    }

    public void ShowGameOverPopup()
    {
        _blurBackground.SetActive(true);
        _gameoverPopup.SetActive(true);
        LeanTween.moveLocal(_gameoverPopup, centerPosition, 1f).setEase(LeanTweenType.easeOutExpo);
    }

}
