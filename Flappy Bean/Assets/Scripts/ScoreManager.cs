using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static float playerScore;
    public static bool newHighScore;
    [SerializeField] GameObject scoreText;
    [SerializeField] GameObject finalScoreText;
    [SerializeField] GameObject highScoreText;
    [SerializeField] GameObject displayCoin;
    [SerializeField] GameObject creditsText;
    [SerializeField] Sprite displayCoinSilver;
    [SerializeField] Sprite displayCoinGold;
    
    // Start is called before the first frame update
    void Start()
    {
        displayCoin.GetComponent<Image>().sprite = displayCoinSilver;
        playerScore = 0;
        newHighScore = false;
        scoreText.SetActive(false);
        creditsText.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.gameOver) {
            scoreText.SetActive(true);
            creditsText.SetActive(false);
        }
        scoreText.GetComponent<Text>().text = playerScore.ToString();
        if(playerScore > PlayerPrefs.GetFloat("HighScore",0f)) {
            newHighScore = true;
            displayCoin.GetComponent<Image>().sprite = displayCoinGold;
            PlayerPrefs.SetFloat("HighScore",playerScore);
        }
        if(GameManager.gameOver) {
            finalScoreText.GetComponent<Text>().text = playerScore.ToString();
            highScoreText.GetComponent<Text>().text = PlayerPrefs.GetFloat("HighScore",0f).ToString();
            scoreText.SetActive(false);
        }
    }
}
