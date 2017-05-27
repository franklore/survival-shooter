using UnityEngine;
using System.Collections;

[System.Serializable]
public class LevelupData
{
    public float levelupSpeedAddition;
    public int levelupAttackAddition;
    public int levelupHealthAddition;
    public int levelupScoreAddition;
    public float levelupProbabilityAddition;
    public float levelupAngularSpeedAddition;
}

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public GameController gameController;

    public float spawnTime;
    public Transform spawnPoint;
    public float crazyProbability;

    public LevelupData levelupData;

    GameObject that;
    NavMeshAgent nav;
    Animator anim;
    EnemyHealth enemyHealth;
    EnemyAttack enemyAttack;
    Light lt;

    void Start ()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn ()
    {
        if(playerHealth.currentHealth <= 0f)
        {
            return;
        }

        that = Instantiate (enemy, spawnPoint.position, spawnPoint.rotation) as GameObject;
        enemyHealth = that.GetComponent<EnemyHealth>();
        enemyAttack = that.GetComponent<EnemyAttack>();
        nav = that.GetComponent<NavMeshAgent>();

        nav.speed += levelupData.levelupSpeedAddition * (gameController.level - 1);
        nav.angularSpeed += levelupData.levelupAngularSpeedAddition * (gameController.level - 1);
        enemyHealth.currentHealth += levelupData.levelupHealthAddition * (gameController.level - 1);
        enemyHealth.scoreValue += levelupData.levelupScoreAddition * (gameController.level - 1);
        enemyAttack.attackDamage += levelupData.levelupAttackAddition * (gameController.level - 1);

        if (Random.value < crazyProbability + levelupData.levelupProbabilityAddition * (gameController.level - 1) )
        {
            anim = that.GetComponent<Animator>();
            lt = that.GetComponent<Light>();
            
            nav.speed *= 1.8f; 
            nav.angularSpeed *= 1.8f;
            enemyHealth.currentHealth *= 2;
            enemyHealth.scoreValue *= 3;
            lt.enabled = true;
            anim.SetTrigger("IsCrazy");
        }
    }
}
