using UnityEngine;

public class GunScript : MonoBehaviour
{
    private ReticleScript RS;
    private  GameObject Reticle;
    public GameObject PivotPoint;
    public GameObject BulletPrefab;
    public GameObject ShotLocation;
    public float ShotCooldown = .25f;
    public float BulletSpeed = 2f;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        Reticle = FindObjectOfType<ReticleScript>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0) timer -= Time.deltaTime;
        if (Input.GetMouseButton(0) && timer <= 0)
        {
            GameObject bullet = Instantiate(BulletPrefab, ShotLocation.transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = (Reticle.transform.position - ShotLocation.transform.position).normalized * BulletSpeed;
            timer = ShotCooldown;

            //This shoots the projectile
        }
        //Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Vector3 rot = new Vector3(0f, 0f, Mathf.Atan2(mouse.y, mouse.x) * Mathf.Rad2Deg);
        //Quaternion rot2 = Quaternion.AngleAxis(rot.z, Vector3.forward);
        //PivotPoint.transform.rotation = rot2;
    }
}
