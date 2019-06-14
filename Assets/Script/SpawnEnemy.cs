using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {
    
    [SerializeField]
    GameObject Enemy;
    float time;
    public bool isGame = true;

	void Start () {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn() {
        while (isGame) {
            // Do anything
            Instantiate(Enemy, transform.position, transform.rotation, transform);
            yield return new WaitForSeconds(5);
        }
    }
}
