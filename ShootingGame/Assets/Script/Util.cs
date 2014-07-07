using UnityEngine;
using System.Collections;
using UnityEditor;

public class Util : MonoBehaviour {

    [MenuItem("Test/Find")]
    public static GameObject GetPlayer() {

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log("Find out Object. Tag:"+player.tag+" position:"+player.transform.position);
        return player;
    }
	
}
