using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonManager : MonoBehaviour
{
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject getReadyPanel;
    [SerializeField] GameObject gameOverPanel;
    public bool playGameNow;

    void Start()
    {
        playGameNow = false;
        startPanel.SetActive(true);
        getReadyPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    void Update() {
        if(playGameNow) {
            if(Input.GetMouseButtonDown(0)) {
                playGameNow = false;
                getReadyPanel.SetActive(false);
                GameManager.gameOver = false;
                bean.startBeanMovement = true;
                GroundSpawner.allowColumnProduction = true;
            }
        }
    }

    public void OnStartPlayBtnPressed() {
        startPanel.SetActive(false);
        getReadyPanel.SetActive(true);
        playGameNow = true;
    }

    public void OnPlayGameClick() {
        getReadyPanel.SetActive(false);
    }

    public void OnOKBtnPressed() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
