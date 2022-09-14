using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traget : MonoBehaviour
{
    private int maxPower = 12;
    private int minpower = 8;
    private int randomTorque = 10;
    private Rigidbody targetRd;
    private int xPosition = 5;
    private float yPosition = -0.50f;
    private GameManager gameManager;
    public ParticleSystem explosive;


    public int pointValue;
    

    // Start is called before the first frame update
    void Start()
    {
        targetRd = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        targetRd.AddForce(RandomForce() , ForceMode.Impulse);

        targetRd.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomPosition();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void OnMouseDown()
     {
       

            if (!gameManager.gameOver)
            {
                Destroy(gameObject);
                if (gameObject.CompareTag("Bad"))
                {
                    gameManager.GameOver();
                }

                else if (!gameObject.CompareTag("Bad"))
                {
                    gameManager.UpdateScore(pointValue);
                }
                Instantiate(explosive, transform.position, explosive.transform.rotation);
            }
        
        

    }


    public void DestroyTraget()
    {
        Debug.Log("HELLO");
        if (gameManager.gameOver == false)
        {
            Destroy(gameObject);
            Debug.Log("HELLO Destroy(gameObject);");

            if (gameObject.CompareTag("Bad"))
            {
                gameManager.GameOver();
            }

            else if (!gameObject.CompareTag("Bad"))
            {
                gameManager.UpdateScore(pointValue);
            }
            Instantiate(explosive, transform.position, explosive.transform.rotation);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        

        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.UpdatesLives(-1);
          
               // gameManager.GameOver();
            
        }

        gameManager.UpdateScore(pointValue);


    }

    
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(maxPower, minpower);
    }

    float RandomTorque()
    {
        return Random.Range(-randomTorque, randomTorque);
    }

    Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(-xPosition, xPosition), -yPosition);
    }


    
}
