using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeeperAttack : MonoBehaviour
{
    private AudioSource sound;

    void Awake(){
        sound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collission){

        if(collission.CompareTag("Player")){
            sound.Play();
            collission.GetComponent<PlayerController>().life--;
        }

    }

}

