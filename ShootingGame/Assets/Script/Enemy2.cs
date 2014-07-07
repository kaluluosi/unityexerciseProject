using UnityEngine;
using System.Collections;

public class Enemy2 : Enemy {

    public GameObject rocketPro;
    private GameObject player;
    public float initReloadTime = 2;
    private float reloadTime;
    void Awake() {
        player = Util.GetPlayer();
        reloadTime = initReloadTime;
    }

    protected override void AI() {
        transform.Translate(-transform.forward * speed * Time.deltaTime);

        reloadTime -= Time.deltaTime;
        if (reloadTime <= 0) {
            reloadTime = initReloadTime;

            if (player != null) {
                Vector3 relativePos = transform.position - player.transform.position;
                Instantiate(rocketPro, transform.position, Quaternion.LookRotation(relativePos));
            }

        }
    }
}

