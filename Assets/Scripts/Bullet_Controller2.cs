using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller2 : MonoBehaviour
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
        if (other.collider.tag=="Impact Area"){
             Destroy(this.gameObject);
        }else{
            Invoke("DestroyElement", 1);
        }
        
    }
    void DestroyElement(){
             Destroy(this.gameObject);

    }
        
    
}