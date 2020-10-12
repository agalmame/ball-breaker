using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    // Start is called before the first frame update

    [Range(0f, 10f)] [SerializeField] float gameSpeed = 1f;

    [SerializeField] TextMeshProUGUI scoreText;

    private int breakBlockPoints = 80;

    [SerializeField] int currentScore = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        scoreText.text= currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
    public void AddScore()
    {
        currentScore += breakBlockPoints;
        scoreText.text = currentScore.ToString();
    }
}
