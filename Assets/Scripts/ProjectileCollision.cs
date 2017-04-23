using UnityEngine;

public class ProjectileCollision : MonoBehaviour {

    private PlayerController pc;

    private void Start() {
        pc = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Enemy") {
            other.GetComponent<EnemyCollision>().health--;
            if(other.GetComponent<EnemyCollision>().health <= 0) {
                pc.score += 100;
                if(pc.score > PlayerPrefs.GetInt("HighScore")) {
                    PlayerPrefs.SetInt("HighScore", pc.score);
                }

                Destroy(other.transform.parent.gameObject);
                GameObject.Find("Explosion").GetComponent<AudioSource>().Play();
            } else {
                GameObject.Find("Hit").GetComponent<AudioSource>().Play();
            }
            Destroy(gameObject);
        }
    }

}
