using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class PlayerLevelupData {
    public float levelupSpeedAddition;
    public float levelupShootRateAddition;
    public int levelupDamageAddition;
}

public class GameController : MonoBehaviour {

    public ScoreManager scoreManager;
    public GameObject player;

    public GameObject healParticle;

    public int level = 1;
    public Animator canvasAnim;
    public Text levelText;
    public Text SkillHint;
    public Slider slider;
    public int LevelupScore;
    public int LevelupScoreDiff;

    int ScoreToLvUp;

    public PlayerLevelupData playerLevelupData;

    PlayerHealth playerHealth;
    PlayerMovement playerMovement;
    PlayerShooting playerShooting;
    Light lt;

    int speedPoint = 0;
    int shootRatePoint = 0;
    int shootDamagePoint = 0;
    int healthPoint = 0;

    void Start ()
    {
        levelText.text = "Level " + level;
        canvasAnim.SetTrigger("ShowLevel");
        ScoreToLvUp = LevelupScore;
        playerHealth = player.GetComponent<PlayerHealth>();
        playerMovement = player.GetComponent<PlayerMovement>();
        playerShooting = player.GetComponentInChildren<PlayerShooting>();
        lt = player.GetComponentInChildren<Light>();
    }
    
	void Update ()
    {
        SkillHint.text = "[Q]  Speed                Lv." + speedPoint
            + "\n[E]  Recover            Lv." + healthPoint
            + "\n[F]  Shoot Rate   lv." + shootRatePoint
            + "\n[V]  Damage           Lv." + shootDamagePoint;

        if (level - speedPoint - shootRatePoint - shootDamagePoint - healthPoint > 0)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                speedPoint++;
                playerMovement.speed += playerLevelupData.levelupSpeedAddition;
                
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                healthPoint++;
                slider.value = 50;
                playerHealth.currentHealth = 50;
                GameObject go = Instantiate(healParticle, player.transform.position, player.transform.rotation) as GameObject;
                go.transform.parent = player.transform;
                
            }
            else if (Input.GetKeyDown(KeyCode.F))
            {
                shootRatePoint++;
                playerShooting.bulletPerSecond += playerLevelupData.levelupShootRateAddition;
                lt.intensity += 0.1f;
            }
            else if (Input.GetKeyDown(KeyCode.V))
            {
                shootDamagePoint++;
                playerShooting.damagePerShot += playerLevelupData.levelupDamageAddition;
                lt.color -= Color.green * 0.1f;
            }
        }

        if (ScoreManager.score >= ScoreToLvUp)
        {
            ScoreToLvUp += LevelupScore + level++ * LevelupScoreDiff;
            levelText.text = "Level " + level;
            canvasAnim.SetTrigger("ShowLevel");
        }
	}
}
