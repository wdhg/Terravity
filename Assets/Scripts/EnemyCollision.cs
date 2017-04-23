using UnityEngine;

public class EnemyCollision : MonoBehaviour {

    public int health = 2;

    private Transform player;
    private PlayerController pc;
    private float damageRate = 0.5f;
    private float nextDamageTime;

    private void Update() {
        if(!player) {
            player = GameObject.Find("Player").transform;
        }
        if(!pc) {
            pc = FindObjectOfType<PlayerController>();
        }
    }

    private void OnCollisionStay(Collision collision) {
        if(collision.gameObject.tag == "Player" && pc.health > 0 && Time.time > nextDamageTime) {
            pc.health--;
            nextDamageTime = Time.time + damageRate;
            GameObject.Find("Explosion").GetComponent<AudioSource>().Play();
        }
    }
}