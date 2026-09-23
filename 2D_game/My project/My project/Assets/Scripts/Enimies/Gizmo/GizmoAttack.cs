using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoAttack : MonoBehaviour
{

    private AudioSource soundAttack;    
	void Awake(){
        soundAttack  = GetComponent<AudioSource>();
    }
private void OnTriggerEnter2D(Collider2D collision){

    if(collision.CompareTag("Player")){
        soundAttack.Play();
        collision.GetComponent<PlayerController>().life--;
    }

}

}
