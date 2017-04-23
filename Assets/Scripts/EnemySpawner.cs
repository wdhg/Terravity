using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy1;
    public float spawnRate;
    public int maxEnemies;

    private float nextSpawnTime;

    public void DestroyEnemies() {
        int childCount = transform.childCount;
        for(int i = childCount - 1; i >= 0; i--) {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    private void SpawnEnemy() {
        GameObject newEnemy = Instantiate(enemy1, transform);
        newEnemy.transform.rotation = Quaternion.Euler(
            Random.Range(0, 360),
            0f,
            Random.Range(0, 360)
        );
    }

    private void Update() {
        if(FindObjectOfType<UI>().gameStarted && transform.childCount < maxEnemies && Time.time > nextSpawnTime) {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnRate;
        }
    }
}