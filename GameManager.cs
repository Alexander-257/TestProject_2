using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject dangerousAreas;
    [SerializeField] public GameObject startScreen;
    [SerializeField] public GameObject pauseScreen;
    [SerializeField] public GameObject gameOverScreen;
    [SerializeField] public GameObject endScreen;

    [SerializeField] public bool isGameActive;
    [SerializeField] public bool isAreaActive;

    void Start() {

    }

    void Update() {  }

    public void StartGame() {
        startScreen.gameObject.SetActive(false);
        isGameActive = true;
        StartCoroutine(ChangeAreaState());
        Time.timeScale = 1;
    }

    public void PauseGame() {
        if(isGameActive) {
            pauseScreen.gameObject.SetActive(true);
            isGameActive = false;
        }
        else {
            pauseScreen.gameObject.SetActive(false);
            isGameActive = true;
        }
    }

    public void GameOver() {
        isGameActive = false;
        gameOverScreen.gameObject.SetActive(true);
        StopCoroutine(ChangeAreaState());
        Time.timeScale = 0;
    }

    public void EndGame() {
        isGameActive = false;
        endScreen.gameObject.SetActive(true);
        StopCoroutine(ChangeAreaState());
        Time.timeScale = 0;
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator ChangeAreaState() {
        while (isGameActive) {
            yield return new WaitForSeconds(3.0f);

            if(isAreaActive) {
                isAreaActive = false;
                dangerousAreas.gameObject.SetActive(false);
            }
            else {
                isAreaActive = true;
                dangerousAreas.gameObject.SetActive(true);
            }
        }
    }
}
