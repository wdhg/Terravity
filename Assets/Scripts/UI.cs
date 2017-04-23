using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    public Text scoreText;
    public Text healthText;
    public Text highScoreText;
    public GameObject gameOver;
    public GameObject title;
    [HideInInspector]
    public bool gameStarted;

    private PlayerController pc;

    private void Start() {
        title.SetActive(true);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit(); 
        }

        if(!gameStarted && Input.anyKeyDown) {
            gameStarted = true;
            title.SetActive(false);
        } else {
            if(!pc) {
                pc = FindObjectOfType<PlayerController>();
            }
            scoreText.text = "Score: " + pc.score.ToString();
            healthText.text = "Health: " + pc.health.ToString();
            highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
            gameOver.SetActive(pc.health == 0);
            highScoreText.enabled = pc.health == 0 || !gameStarted;

            if(gameOver.activeSelf && Input.anyKeyDown) {
                pc.health = 4;
                pc.score = 0;
                FindObjectOfType<EnemySpawner>().DestroyEnemies();
                FindObjectOfType<PlanetGenerator>().Generate();
            }
        }
    }
}
