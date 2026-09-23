using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataform : MonoBehaviour
{

    private TargetJoint2D target;
    private BoxCollider2D boxcoll;
    private AudioSource soundFall;
    public Transform pivot;

    void Start()
    {
        target = GetComponent<TargetJoint2D>();
        boxcoll = GetComponent<BoxCollider2D>();
        transform.position = pivot.position;
        soundFall = GetComponent<AudioSource>();
    }

    void PlataformDown(){
        target.enabled = false;
        boxcoll.isTrigger = true;
    }


    void InstatiatePlataform(){
        target.enabled = true;
        boxcoll.isTrigger = false;
        Instantiate(pivot, pivot.position, Quaternion.identity);
        Destroy(pivot.gameObject);
    }


    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            soundFall.Play();
            Invoke("PlataformDown", 0.8f);
            Invoke("InstatiatePlataform", 3.5f);
        }
    }
}
