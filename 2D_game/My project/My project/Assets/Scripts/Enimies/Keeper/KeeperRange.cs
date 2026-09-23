using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeeperRange : MonoBehaviour
{
    private AudioSource sound;
	void Awake(){
        sound = GetComponent<AudioSource>();
    }
 private void OnTriggerStay2D(Collider2D collision){
	
	if(collision.CompareTag("Player")){
		sound.Play();
		GetComponentInParent<Animator>().Play("attack", -1);
	}
 
 }

}
