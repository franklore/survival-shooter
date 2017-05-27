using UnityEngine;
using System.Collections;

public class GameStartController : MonoBehaviour {

    public GameObject enemyManager;

    public Animator anim;

	void Awake () {
        enemyManager.SetActive(false);
	}

    void OnTriggerExit(Collider other)
    {
        enemyManager.SetActive(true);
        anim.SetTrigger("ShootStart");
        gameObject.SetActive(false);
    }
}
