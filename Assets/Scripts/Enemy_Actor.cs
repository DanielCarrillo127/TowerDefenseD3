using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Actor : MonoBehaviour
{
    float speed = 2.5f;
    public Transform target;
    public Transform damagePoint;

    public GameObject playerController;

    public int life;

    void Start()
    {
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
            playerController.GetComponent<PlayerController>().addMoney(5);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "WayPoint")
        {
            int rndPoint = Random.Range(0, other.gameObject.GetComponent<Waypoint>().nextPoint.Length);
            target = other.gameObject.GetComponent<Waypoint>().nextPoint[rndPoint];
            transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        }
        else if (other.tag == "WayPointEnd")
        {
            Destroy(gameObject);
            playerController.GetComponent<PlayerController>().reduceLife(50);
        }
        else if (other.tag == "Bullet")
        {
            life -= 5;
        }
    }
}
