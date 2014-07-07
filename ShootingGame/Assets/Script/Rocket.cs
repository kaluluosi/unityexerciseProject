using UnityEngine;
using System.Collections;
using UnityEditor;

public class Rocket : MonoBehaviour {

    public float speed = 10;
    public float liveTime = 1;
    public int damage = 1;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        liveTime -= Time.deltaTime;

        if (liveTime <= 0) {
            Destroy(this.gameObject);
        }

        transform.Translate(-Vector3.forward*speed*Time.deltaTime);
	}


    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Enemy")) {
            Destroy(gameObject);
        }
    }


}
