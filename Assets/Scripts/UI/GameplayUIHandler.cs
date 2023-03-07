using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameplayUIHandler : MonoBehaviour
{
    public static GameplayUIHandler instance;

    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI enemyScoreText;

    public GameObject countdownPanel;
    public TextMeshProUGUI countdownText;

    private float countdown;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdatePlayerScore(0);
        UpdateEnemyScore(0);
    }

    void Update()
    {
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;

            UpdateCountdownText();
        }
    }

    public void UpdatePlayerScore(int score)
    {
        playerScoreText.text = score.ToString();
    }

    public void UpdateEnemyScore(int score)
    {
        enemyScoreText.text = score.ToString();
    }

    public void UpdateCountdownText()
    {
        countdownText.text = Mathf.Ceil(countdown).ToString();
    }

    public IEnumerator ToggleCountdownPanel()
    {
        countdown = GameplayManager.Instance.countdown;
        countdownPanel.SetActive(true);
        yield return new WaitForSeconds(countdown);
        countdownPanel.SetActive(false);
    }
}
