using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Actor : MonoBehaviour
{
    float speed=5.0f;
    public Transform target;
    void Start()
    {
        transform.LookAt(new Vector3(target.position.x,transform.position.y,target.position.z));
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0,0,speed*Time.deltaTime));
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag=="WayPoint"){
            int rndPoint= Random.Range(0,other.gameObject.GetComponent<Waypoint>().nextPoint.Length);
            target=other.gameObject.GetComponent<Waypoint>().nextPoint[rndPoint];
            transform.LookAt(new Vector3(target.position.x,transform.position.y,target.position.z));
        }
    }
}
