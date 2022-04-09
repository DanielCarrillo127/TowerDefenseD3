using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class TowerController : MonoBehaviour, IDragHandler
 {
    public GameObject towerHead;
    public Transform bulletSpawn;
    public GameObject cannon;
    public GameObject rangeAttackVisual;
    public GameObject bulletReference;
    public float fireRate;
private Transform thisTransRef;
    // PROPIEDADES
    
    int life;
    int damage;
    public float rangeAttack;


    void Start()
    {
        rangeAttackVisual.GetComponent<SphereCollider>().radius=rangeAttack;
    
     thisTransRef = transform;}

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnDrag(PointerEventData eventData)
     {
         var world_point_mousePos = Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y,Mathf.Abs( Camera.main.transform.position.z)));
 
         thisTransRef.position = world_point_mousePos;
     }
}
