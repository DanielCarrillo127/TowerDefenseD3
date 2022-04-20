using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller3 : MonoBehaviour
{
   public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0,speed*Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other) {
        switch(other.collider.tag){
            case "Impact Area":
                Destroy(this.gameObject);
            break;
        }
        
    }
        
    
}