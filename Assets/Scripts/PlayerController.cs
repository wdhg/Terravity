using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Transform player;
    public GameObject projectile;
    public float fireRate;
    [HideInInspector]
    public int score;
    public int health;
    public AudioSource shootSound;

    private float nextShootTime;

    private void Awake() {
        health = 4;
    }

    private void Move() {
        float horizontal = Input.GetAxisRaw("Horizontal") * speed * Time.fixedDeltaTime;
        float vertical = Input.GetAxisRaw("Vertical") * speed * Time.fixedDeltaTime;

        transform.Rotate(vertical, 0f, -horizontal);
    }

    private Vector2 GetMousePos() {
        return (Vector2) Input.mousePosition - new Vector2(
            Camera.main.pixelWidth / 2f,
            Camera.main.pixelHeight / 2f
        );
    }

    private void LookAtMouse() {
        Vector2 mousePos = GetMousePos();

        float rotation = Mathf.Atan(mousePos.y / mousePos.x) * Mathf.Rad2Deg - 90f;
        if(mousePos.x < 0f) {
            rotation += 180f;
        }
        player.localRotation = Quaternion.Euler(0f, -rotation, 0f);
    }

    private void Shoot() {
        shootSound.Play();
        GameObject newProjectile = Instantiate(projectile);
        newProjectile.transform.rotation = transform.rotation;
        newProjectile.GetComponent<ProjectileController>().direction = GetMousePos().normalized;
    }

    private void FixedUpdate() {
        if(player.gameObject.activeSelf) {
            Move();
        }
    }

    private void Update() {
        LookAtMouse();
        if(Time.time >= nextShootTime && Input.GetButton("Fire1")) {
            Shoot();
            nextShootTime = Time.time + fireRate;
        }
        player.gameObject.SetActive(health > 0);
    }
}
