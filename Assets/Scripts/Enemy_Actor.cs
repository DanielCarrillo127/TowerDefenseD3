using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Actor : MonoBehaviour
{
    public float speed = 2.5f;
    public Transform target;
    public Transform damagePoint;

    public int life;
    GameObject pc;

    void Start()
    {
    
    pc = GameObject.FindGameObjectWithTag("MainCamera");

        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));

    }

    // Update is called once per frame
    void Update()
    {
        if (life > 0)
        {
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));

        }
        else
        {
            Debug.Log("Destruido ");
            Destroy(this.gameObject);
            pc.GetComponent<PlayerController>().addMoney(25);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "WayPoint" || other.tag == "WayPoint1" || other.tag == "WayPoint2")
        {
            int rndPoint = Random.Range(0, other.gameObject.GetComponent<Waypoint>().nextPoint.Length);
            target = other.gameObject.GetComponent<Waypoint>().nextPoint[rndPoint];
            transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        }
        else if (other.tag == "WayPointEnd")
        {
            Destroy(gameObject);
            pc.GetComponent<PlayerController>().reduceLife(5);
        }
        else if (other.tag == "Bullet")
        {
            life -= 5;
        }
    }
}
