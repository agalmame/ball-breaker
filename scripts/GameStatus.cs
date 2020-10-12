using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    // Start is called before the first frame update

    [Range(0f, 10f)] [SerializeField] float gameSpeed;

    [SerializeField] TextMeshProUGUI scoreText;

    private int breakBlockPoints = 80;

    [SerializeField] int currentScore;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
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
        currentScore = 0;
        scoreText.text= currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddScore()
    {
        currentScore += breakBlockPoints;
        scoreText.text = currentScore.ToString();
    }
}
