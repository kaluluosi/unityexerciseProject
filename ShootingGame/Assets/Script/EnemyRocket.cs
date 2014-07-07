using UnityEngine;
using System.Collections;

public class EnemyRocket : Rocket {

	void OnTriggerEnter(Collider other)
	{
        if (other.CompareTag("Player")) {
            Destroy(gameObject);
        }
	}
	
	
}
