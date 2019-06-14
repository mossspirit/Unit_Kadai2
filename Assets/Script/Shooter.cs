using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    [SerializeField]
    GameObject goBullet;

    [SerializeField]
    float bulletVelocity;

    [SerializeField]
    Transform bulletTrans;
    AudioSource audioSource;
    public AudioClip gun;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    void Update () {
        OVRInput.Update();

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)) {
            Debug.Log("Shot");
            var tempBullet = Instantiate(goBullet);
            tempBullet.transform.position = bulletTrans.position;
            Rigidbody rBody = tempBullet.GetComponent<Rigidbody>();
            rBody.velocity = transform.up * bulletVelocity;
            audioSource.PlayOneShot(gun);
        }
	}
}
