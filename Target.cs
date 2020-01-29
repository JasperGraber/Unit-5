using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;
    
    // Hiermee worden alle variabelen gemaakt en een waarde gegeven.
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -2;

    // Dit zorgt ervoor dat we de prefabs een particle kunnen geven.
    public ParticleSystem explosionParticle;
    
    // Dit zorgt ervoor dat we de prefabs een point value kunnen geven.
    public int pointValue;

    // Start is called before the first frame update
    void Start()
    {
        // Dit maakt de referenties naar de components.
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        
        targetRb.AddForce(Randomforce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();
    }

    // Dit zorgt ervoor dat als de speler op een object klikt het word verwijderd, een explosie particle komt en de punten worden opgetelt.
    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);  
        }
    }

    // Dit zorgt ervoor dat als het object de trigger raakt het word verwijderd.
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }

    // Dit is het script voor de random snelheid.
    Vector3 Randomforce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    // Dit is het script voor de random torque.
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    // Dit is het script voor de random spawn positie.
    Vector3 RandomSpawnPos()
    {
       return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}
