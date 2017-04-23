using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float speed;

    private Transform player;

    private void Awake() {
        player = GameObject.Find("Player").transform;
    }

    private void Move() {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, player.rotation, speed * Time.fixedDeltaTime);
    }

    private void FixedUpdate() {
        if(player.GetChild(0).gameObject.activeSelf) {
            Move();
        }
    }
}
