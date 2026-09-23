using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{      
    private AudioSource soundCollect;

	void Awake(){
         soundCollect = GetComponent<AudioSource>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player"){
            soundCollect.Play();
            collision.GetComponent<PlayerController>().life++;
            Destroy(this.gameObject, 0.2f);            
        }
    }    
}
