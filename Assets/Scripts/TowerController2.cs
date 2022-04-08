using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController2 : MonoBehaviour{
    public GameObject towerHead;
    public Transform bulletSpawn;
    public Transform bulletSpawn2;
    public GameObject rangeAttackVisual;
    public GameObject bulletReference;
    public float fireRate;

    // PROPIEDADES
    
    int life;
    int damage;
    public float rangeAttack;


    void Start()
    {
        rangeAttackVisual.GetComponent<SphereCollider>().radius=rangeAttack;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
