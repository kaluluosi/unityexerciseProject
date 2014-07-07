using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public Player player;
    public float moveSpeed = 5f;
    private NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        agent.SetDestination(player.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
        MoveTo();
	}

    private void MoveTo() {
        float speed = moveSpeed * Time.deltaTime;
        agent.Move(transform.TransformDirection(new Vector3(0,0,speed)));
    }
}
