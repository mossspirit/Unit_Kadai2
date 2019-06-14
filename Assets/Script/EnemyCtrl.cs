using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCtrl : MonoBehaviour {

    GameObject Player;
    NavMeshAgent navMeshAgent;
    Animator animator;
    [SerializeField]
    float DestroyTime;
    float time;

	// Use this for initialization
	void Start () {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        Player = GameObject.Find("OVRPlayerController");
	}
	
	// Update is called once per frame
	void Update () {
        if (navMeshAgent.pathStatus != NavMeshPathStatus.PathInvalid) {
            // NavMeshAgentに目的地をセット
            navMeshAgent.SetDestination(Player.transform.position);
        }
        if (Input.GetKeyDown(KeyCode.Return)) {
            animator.SetBool("Attack", true);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Bullet") {
            navMeshAgent.isStopped = true;
            animator.SetBool("Death", true);
            Destroy(gameObject,3f);
        }
        if(other.tag == "Player") {
            navMeshAgent.isStopped = true;
            animator.SetBool("Attack", true);
            Destroy(GameObject.Find("SpawnPoint"), 5f);
        }
    }
}
