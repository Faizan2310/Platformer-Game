using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToPlatform : MonoBehaviour
{
   private void OnCollisionEnter(Collision collison){
    if(collison.gameObject.name == "Player"){
        collison.gameObject.transform.SetParent(transform);
    }
   }
   private void OnCollisionExit(Collision collsion){
    if(collsion.gameObject.name == "Player"){
        collsion.gameObject.transform.SetParent(null);
    }
   }
}
