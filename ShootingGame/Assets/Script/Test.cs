using UnityEngine;
using System.Collections;
using UnityEditor;

public class Test : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    [MenuItem("Test/Rotate 1 %1")]
    static void Rotate1() {
        GameObject obj = Selection.activeGameObject;
        obj.transform.Rotate(Vector3.forward);
    }


    [MenuItem("Test/Rotate -1 %2")]
    static void Rotate2() {
        GameObject obj = Selection.activeGameObject;
        obj.transform.Rotate(-Vector3.forward);
    }
}
