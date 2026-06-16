using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    public static int score;

    private TextMeshProUGUI scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();

        scoreText.text = score.ToString();
    }
}
