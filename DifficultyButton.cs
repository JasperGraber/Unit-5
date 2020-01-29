using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class DifficultyButton : MonoBehaviour
{
    // Dit maakt 2 variabelen aan voor de button en gamemanager.
    private Button button;
    private GameManager gameManager;

    // Hiermee kan je de difficulty zetten van de game in Unity.
    public int difficulty;
        
    // Start is called before the first frame update
    void Start()
    {
        // Dit zorgt ervoor dat de button en gamemanager worden gezocht.
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        
        // Dit zorgt ervoor dat als je op de button klikt je de gekozen difficulty krijgt.
        button.onClick.AddListener(SetDifficulty);
    }

    // Dit zorgt ervoor dat de difficulty wordt afgelezen.
    void SetDifficulty()
    {
        Debug.Log(gameObject.name + " was clicked");
        gameManager.StartGame(difficulty);
    }
}
