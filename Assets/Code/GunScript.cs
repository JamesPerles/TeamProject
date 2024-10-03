using UnityEngine;

public class GunScript : MonoBehaviour
{
    private ReticleScript RS;
    private GameObject Reticle;
    public GameObject PivotPoint;
    public GameObject BulletPrefab;
    public GameObject ShotLocation;
    public float ShotCooldown = .25f;
    public float BulletSpeed = 2f;

    private float timer;

    // Audio for the gunshot
    public AudioSource audioSource; // AudioSource
    public AudioClip shotSound; // sound effect

    // Start is called before the first frame update
    void Start()
    {
        Reticle = FindObjectOfType<ReticleScript>().gameObject;
        audioSource = GetComponent<AudioSource>(); // Ensure you have an AudioSource attached to the same GameObject as this script
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0) timer -= Time.deltaTime;
        
        if (Input.GetMouseButton(0) && timer <= 0)
        {
            // Spawn the bullet
            GameObject bullet = Instantiate(BulletPrefab, ShotLocation.transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = (Reticle.transform.position - ShotLocation.transform.position).normalized * BulletSpeed;
            timer = ShotCooldown;

            // Play the gunshot sound
            if (audioSource != null && shotSound != null)
            {
                audioSource.PlayOneShot(shotSound); // Play sound effect
            }
        }
    }
}