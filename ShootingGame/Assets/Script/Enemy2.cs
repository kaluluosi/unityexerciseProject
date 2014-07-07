using UnityEngine;
using System.Collections;

public class Enemy2 : Enemy {

    public GameObject rocketPro;
    private GameObject player;
    public float initReloadTime = 2;
    private float reloadTime;
    public int initRocketNum = 10;
    public int rocketNum;
    public float fireInterval = 1f;
    void Awake() {
        player = Util.GetPlayer();
        reloadTime = initReloadTime;
        rocketNum = initRocketNum;
    }

    protected override void AI() {
        transform.Translate(-transform.forward * speed * Time.deltaTime);

        reloadTime -= Time.deltaTime;
        if (reloadTime <= 0) {
//             reloadTime = initReloadTime;

            if (player != null && rocketNum != 0) {
//                 Vector3 relativePos = transform.position - player.transform.position;
//                 Instantiate(rocketPro, transform.position, Quaternion.LookRotation(relativePos));
//                 rocketNum--;
                if (IsInvoking("Fire") == false) {
                    InvokeRepeating("Fire", fireInterval, fireInterval);
                }
            }
            else {
                reloadTime = initReloadTime;
                rocketNum = initRocketNum;
                CancelInvoke("Fire");
            }
        }
    }

    private void Fire() {
        if (rocketNum != 0) {
            Vector3 relativePos = transform.position - player.transform.position;
            Instantiate(rocketPro, transform.position, Quaternion.LookRotation(relativePos));
            rocketNum--;
        }
    }
}

