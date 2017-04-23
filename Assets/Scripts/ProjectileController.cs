using UnityEngine;

public class ProjectileController : MonoBehaviour {

    public float speed;
    public float lifeSpan;
    public Vector2 direction;

    private float lifeStartTime;

    private void Awake() {
        lifeStartTime = Time.time;
    }

    private void Move() {
        transform.Rotate(
            direction.y * speed * Time.fixedDeltaTime,
            0f,
            -direction.x * speed * Time.fixedDeltaTime
        );
    }

    private void Update() {
        Move();

        if(Time.time - lifeStartTime >= lifeSpan) {
            Destroy(gameObject);
        }
    }
}
