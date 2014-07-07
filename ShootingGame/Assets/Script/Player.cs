using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour {

    private Animator anim;
    public float speed = 1;
    public int hp = 5;
    protected bool pause = false;
    public GameObject explosionFX;

	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        
        float movev = 0;
        float moveh = 0;

        if (Input.GetKey(KeyCode.UpArrow)){
            movev -= speed * Time.deltaTime;
        }
        
        if (Input.GetKey(KeyCode.DownArrow)){
            movev += speed * Time.deltaTime;
        }
        
        if (Input.GetKey(KeyCode.LeftArrow)){
            moveh += speed*Time.deltaTime;
            anim.SetBool("left", true);
        }
        
        if(Input.GetKey(KeyCode.RightArrow)){
            moveh -= speed*Time.deltaTime;
            anim.SetBool("right", true);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow)) {
            anim.SetBool("left", false);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow)) {
            anim.SetBool("right", false);
        }
        if (!pause) {        
            transform.Translate(new Vector3(-moveh,0,-movev),Space.World);
        }
	}

    void PauseObject() {
        pause = true;
        Invoke("ResetPause",0.1f);
    }

    private void ResetPause(){
        pause = false;
    }

    void OnTriggerEnter(Collider other) {

        //与敌人相撞减少HP
        if (other.CompareTag("PlayerRocket") == false) {
            hp--;
            Debug.Log(hp + "  hp -1");
            PauseObject();
        }

        if (hp <= 0) {
            GameObject expl = Instantiate(explosionFX, transform.position, transform.rotation) as GameObject;
            Destroy(gameObject);
        }

    }


}
