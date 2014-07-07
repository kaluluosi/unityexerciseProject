using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    public GameObject rocketPro;
    public float initReloadTime = 10;
    private float reloadTime;
    public bool reloading = false;

	// Use this for initialization
	void Start () {
        Rocket rockScript = rocketPro.GetComponent("Rocket") as Rocket;
        rockScript.speed = 10;
        rockScript.liveTime = 2;
        rockScript.damage = 2;

        reloadTime = initReloadTime;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Space) && reloading == false) {
            Instantiate(rocketPro, transform.position,transform.rotation);
            audio.Play();
            reloading = true;
        }

        if (reloading) {
            reloadTime -= Time.deltaTime;

            if (reloadTime <= 0) {
                reloading = false;
                reloadTime = initReloadTime;
            }
        }
	}

}
