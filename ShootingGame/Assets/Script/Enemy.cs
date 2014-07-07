using UnityEngine;
using System.Collections;

[AddComponentMenu("MyGame/Enemy")]
public class Enemy : MonoBehaviour {

    public float speed = 1;
    public float rotSpeed = 30;
    public float changeTimer = 1.5f;


	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        AI();
	}

    //角色移动和攻击AI
    protected virtual void AI() {
        changeTimer -= Time.deltaTime;
        if (changeTimer <= 0) {
            changeTimer = 3;
            rotSpeed = -rotSpeed;
        }

        this.transform.Rotate(Vector3.up, rotSpeed * Time.deltaTime, Space.World);
        this.transform.Translate(-transform.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other) {

        if (other.CompareTag("PlayerRocket")) {
            Destroy(gameObject);
        }

        if (other.CompareTag("Player")) {
            Destroy(gameObject);
        }
    }
    
    

}
