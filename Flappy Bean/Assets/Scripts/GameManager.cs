using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject newHighScoreLabel;
    public static bool gameOver;
    
    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
        newHighScoreLabel.SetActive(false);
        gameOver = true;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Input.anyKey && !bean.playerDead) {
            gameOver = false;
            bean.startBeanMovement = true;
            GroundSpawner.allowColumnProduction = true;
        }
        */
        if(gameOver && bean.playerDead) {
            GroundTile.moveSpeed = 0;
            if(ScoreManager.newHighScore) {
                ScoreManager.newHighScore = false;
                newHighScoreLabel.SetActive(true);
            }
            gameOverPanel.SetActive(true);
        }
    }
}
