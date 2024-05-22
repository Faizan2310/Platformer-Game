using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollection : MonoBehaviour
{
   [SerializeField] AudioSource coinAudio;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            //Play Audio
            coinAudio.Play();
            ScoreManager.instance.AddScore(10);
        }
    }
}
