using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField]
    float lifeTimeMax = 5;
    float lifeTime = 0;
	
	// Update is called once per frame
	void Update () {
        lifeTime += Time.deltaTime;
        if (lifeTime > lifeTimeMax)
            Destroy(gameObject);
	}

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Enemy") {
            Destroy(gameObject);
        }
    }
}
