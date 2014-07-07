using UnityEngine;
using System.Collections;

public class Util : MonoBehaviour {

    public static GameObject GetPlayer() {

        try {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
//             Debug.Log("Find out Object. Tag:" + player.tag + " position:" + player.transform.position);
            return player;
        }
        catch (System.Exception ex) {
            Debug.LogError(ex.Message);
        }
        return null;
    }
	
}
