using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

    public GameObject enemyPro;
    public float timer = 5f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        timer -= Time.deltaTime;
        if (timer <= 0) {
            timer = Random.Range(5,15);

            Instantiate(enemyPro, transform.position, transform.rotation);
        }

	}

}
