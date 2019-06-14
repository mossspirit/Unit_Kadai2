using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {
        if (other.name == "Stick")
            reStart("OVRTest");
    }

    public void reStart(string SceneName) {
        SceneManager.LoadScene(SceneName);
    }
}
