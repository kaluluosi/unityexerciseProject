using UnityEngine;
using System.Collections;

public class Bound : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other) {

        Debug.Log(string.Format("{0} Hit Bound",other.gameObject.name));
        if (other.CompareTag("Player") == false) {
            Destroy(other.gameObject);
        }
    }


}
