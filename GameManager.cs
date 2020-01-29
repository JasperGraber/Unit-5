using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Dit maakt een list voor alle targets.
    public List<GameObject> targets;

    // Dit zorgt ervoor dat we de tekst kunnen selecteren.
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    // Dit maakt een bool aan voor als de game actief of inactief is.
    public bool isGameActive;
    
    public Button restartButton;

    public GameObject titleScreen;
    
    // Dit zet de spawn rate naar 1.
    private float spawnRate = 1.0f;
    
    private int score;

    // Start is called before the first frame update
    void Start()
    {
       
    }
    
    IEnumerator SpawnTarget()
    {
        // Dit zorgt ervoor dat de objects spawnen als de game actief is.
        while(isGameActive)
        {
            yield return  new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    // Dit zorgt ervoor dat de score wordt opgetelt.
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        // Dit zorgt ervoor dat je de game over tekst en restart button ziet.
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        
        // Dit zorgt ervoor dat de game niet meer actief is.
        isGameActive = false;
    }

    // Dit zorgt ervoor dat de scene opnieuw wordt geladen als je op restart klinkt.
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        // Dit zorgt ervoor dat de game actief is.
        isGameActive = true;

        // Dit zet de spawnrate naar de difficulty die de speler heeft gekozen.
        spawnRate /= difficulty;
        
        // Dit start de het spawn script en blijft het uitvoeren.
        StartCoroutine(SpawnTarget());
        
        // Zet de standaard score naar 0.
        score = 0;
        UpdateScore(0);
        
        // Dit zorgt ervoor dat de title screen weggaat.
        titleScreen.gameObject.SetActive(false);
    }
}
