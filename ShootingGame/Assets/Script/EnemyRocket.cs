using UnityEngine;
using System.Collections;

public class EnemyRocket : Rocket {

	void OnTriggerEnter(Collider other)
	{
        if (other.CompareTag("Player")) {
            Instantiate(explosionFX, transform.position, transform.rotation);
            Destroy(gameObject);
        }
	}
	
	
}
