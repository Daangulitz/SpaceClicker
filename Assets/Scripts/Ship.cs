using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private float speedX;
    [SerializeField] private float resetposition;
    [SerializeField] private float minY;  
    [SerializeField] private float maxY;  
    private float shipWidth;
    [SerializeField] private AudioClip shipExplode;
    [SerializeField] private GameObject explosionPrefab;  // Reference to the explosion prefab

    private Gamemanager game;
    [SerializeField] int scoreAmount;

    void Start()
    {
        game = FindObjectOfType<Gamemanager>();
        shipWidth = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        // Move the ship horizontally
        transform.position = transform.position + new Vector3(speedX * Time.deltaTime, 0, 0);

        // Check if the ship is off the screen to the left
        if (transform.position.x + (shipWidth / 2f) < 0)
        {
            // Reset the ship to the right side with a new random Y position
            transform.position = new Vector3(resetposition, transform.position.y, transform.position.z);
        }
    }

    private void OnMouseDown()
    {
        Vector3 oldPosition = transform.position;


        GameObject explosionInstance = Instantiate(explosionPrefab, oldPosition, Quaternion.identity);
        
        PlayExplosionSound(oldPosition);
        
        ParticleSystem explosionParticles = explosionInstance.GetComponent<ParticleSystem>();
        if (explosionParticles != null)
        {
            explosionParticles.Play();
        }
        else
        {
            Debug.LogError("No ParticleSystem component found on the explosionPrefab!");
        }
        
        game.AddScore(scoreAmount);
        
        float randomY = Random.Range(minY, maxY);
        transform.position = new Vector3(resetposition, randomY, transform.position.z);
        
        Destroy(explosionInstance, explosionParticles.main.duration);
    }

    private void PlayExplosionSound(Vector3 position)
    {
        // Create a temporary AudioSource to play the explosion sound
        GameObject tempAudioObject = new GameObject("TempAudio");
        tempAudioObject.transform.position = position;

        AudioSource audioSource = tempAudioObject.AddComponent<AudioSource>();
        audioSource.clip = shipExplode;
        audioSource.playOnAwake = false;
        audioSource.volume = 100.0f;  // Adjust volume as needed
        audioSource.Play();

        // Destroy the audio object after the clip has finished playing
        Destroy(tempAudioObject, shipExplode.length);
    }
}
