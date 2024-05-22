using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerEnemyInt : MonoBehaviour
{
    [SerializeField] AudioSource deathAudio;
    private void OnCollisionEnter(Collision collision){
        // Check if the collision is with an object tagged as "Enemy Body"
        if(collision.gameObject.CompareTag("Enemy Body")){
            GetComponent<PlayerHealth>().TakeDamage(1);
            deathAudio.Play(); //Play Audio when player Dies
        }
    }
}


