using UnityEngine;
using UnityEngine.InputSystem;

public class TargetB : MonoBehaviour
{
    private Rigidbody targetRb;
    private GamemanagerB gameManager;
    public ParticleSystem explotionParticle;

    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorqur = 2;
    private float xRanage = 4;
    private float ySpawnPos = -6;
    public int pointValue;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GamemanagerB>();
        targetRb.AddForce(RandomForce(),ForceMode.Impulse);
        targetRb.AddTorque(RadomTorqur(), RadomTorqur(), RadomTorqur(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gamePause == false)
        {
            if (gameManager.isGameActive)
            {
                if (Mouse.current.leftButton.isPressed)
                {
                    Debug.Log("Mouse Was clicked");
                    Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
                    Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 2f);
                    if (Physics.Raycast(ray, out RaycastHit hit))
                    {
                        // If ray hit this enemy, deastroy it
                        if (hit.transform == transform)
                        {
                            Instantiate(explotionParticle, transform.position, explotionParticle.transform.rotation);
                            gameManager.UpdateScore(pointValue);
                            Destroy(gameObject);
                        }
                    }


                }
            }
        }
       
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed,maxSpeed);
    }

    float RadomTorqur()
    {
        return Random.Range(-maxTorqur,maxTorqur);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRanage, xRanage), ySpawnPos);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DestroyZone") && !gameObject.CompareTag("Bad"))
        {
            if (gameManager.live <= 1)
            {
                gameManager.GameOver();
                gameManager.livesText.text = "Lives : " + 0;
            }
            else
            {
                Destroy(gameObject);
                gameManager.UpdateLive(1);
            }
        }
    }







}
