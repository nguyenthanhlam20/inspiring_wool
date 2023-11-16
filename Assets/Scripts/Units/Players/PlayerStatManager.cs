using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStatManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject[] hearts;
    private int heart = 2;
    private int _score;

    public static PlayerStatManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int Score
    {
        get { return _score; }
    }

    public void InscreaseScore()
    {
        _score += 10;

        if(_score % 40 == 0)
        {
            BasketPool.Instance.SpawnBasketsInLine();
        }
        scoreText.text = _score.ToString();
    }

    public void DescreaseHealth()
    {
        if(heart >= 0)
        {
            hearts[heart--].gameObject.SetActive(false);
        }

        if(heart < 0)
        {
            PopupManager.Instance.ShowGameOverPopup();

        }
    }

    public void RemoveAllHearts()
    {
        FloatingTextContainer.Instance.ShowFloatingText($"-{heart + 1}", Color.red, transform);
        while(heart >= 0)
        {
            hearts[heart--].gameObject.SetActive(false);
        }
        PopupManager.Instance.ShowGameOverPopup();
    }

}
