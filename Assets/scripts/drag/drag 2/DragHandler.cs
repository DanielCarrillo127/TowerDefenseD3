using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject prefab;
    GameObject prefabInstance;
    public GameObject dinero;
    int resta;
    bool torretaExist = false;
    // Use this for initialization
    void Start()
    {
        prefabInstance = Instantiate(prefab);
        RemoveScriptsFromPrefab();
        AdjustPrefabAlpha();
        prefabInstance.SetActive(false);
    }
 
    void RemoveScriptsFromPrefab()
    {
        Component[] components = prefabInstance.GetComponentsInChildren<TowerController>();
        foreach (Component component in components)
        {
            Destroy(component);
        }
    }

    void AdjustPrefabAlpha()
    {
        MeshRenderer[] meshRenderers = prefabInstance.GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < meshRenderers.Length; i++)
        {
            Material mat = meshRenderers[i].material;
            meshRenderers[i].material.color = new Color(mat.color.r, mat.color.g, mat.color.b, 0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        /*  if (dinero.GetComponent<PlayerController>().money >= 5)
         {
             Debug.Log("Beginning drag");
              
         }
         else
         {

         } */
        Debug.Log("Beginning drag");


    }

    public void OnDrag(PointerEventData eventData)
    {
        /* if (dinero.GetComponent<PlayerController>().money >= 5)
        {

        }
        else
        {

        } */
        Debug.Log("Dragging");
        RaycastHit[] hits;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hits = Physics.RaycastAll(ray, 50f);
        if (hits != null && hits.Length > 0 && dinero.GetComponent<PlayerController>().money >= 25)
        {
            int terrainCollderQuadIndex = GetTerrainColliderQuadIndex(hits);
            if (terrainCollderQuadIndex != -1)
            {
                prefabInstance.transform.position = hits[terrainCollderQuadIndex].point;
                prefabInstance.SetActive(true);

            }
            else
            {
                prefabInstance.SetActive(false);
            }
        }
        else
        {
            prefabInstance.SetActive(false);
        }
    }


    int GetTerrainColliderQuadIndex(RaycastHit[] hits)
    {
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.gameObject.name.Equals("TerrainColliderQuad") ||
            hits[i].collider.gameObject.tag.Equals("TerrainColliderQuad"))
            {
                Debug.Log("TerrainCOllider click");
                return i;
            }
            if (hits[i].collider.gameObject.tag.Equals("Torreta"))
            {
                torretaExist = true;
                Debug.Log("TerrainCOllider torreta");
                return -1;
            }
        }

        return -1;
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        /* if (dinero.GetComponent<PlayerController>().money >= 5)
        {
            
        }
        else
        {
            
        } */
        Debug.Log("Ending drag");
        if (prefabInstance.activeSelf && !torretaExist)
        {
            if(prefab.name ==  "Cannon(Clone)" ||prefab.name ==  "Cannon"  ){
                Debug.Log("Nombre Cannon" );
                resta = dinero.GetComponent<PlayerController>().canPut(50);
                Debug.Log("RESTA:" +  resta);
                dinero.GetComponent<PlayerController>().substractMoney(50);
            }
            else if(prefab.name ==  "Turret(Clone)" ||prefab.name ==  "Turret"  ){
                Debug.Log("Nombre Turret" );
                resta = dinero.GetComponent<PlayerController>().canPut(150);
                dinero.GetComponent<PlayerController>().substractMoney(150);
                Debug.Log("RESTA:" +  resta);
            }else if(prefab.name ==  "Ballista(Clone)" ||prefab.name ==  "Ballista"  ){
                Debug.Log("Nombre Ballista" );
                resta = dinero.GetComponent<PlayerController>().canPut(75);
                dinero.GetComponent<PlayerController>().substractMoney(75);
                Debug.Log("RESTA:" +  resta);
            }
            if(resta == 1){
            // MeshFilter mf = activeSlot.GetComponent<MeshFilter> ();
            Instantiate(prefab, prefabInstance.transform.position, Quaternion.identity);
            prefabInstance.SetActive(true);
            /* switch(prefab.name){
                case GameObject.name("Cannon"):
                    Debug.Log("Nombre Cannon" );
            } */
           
            torretaExist = false;
            }else{

            }
           
        }
        else
        {
            //dinero.GetComponent<PlayerController>().addMoney(5);

            prefabInstance.SetActive(false);
            torretaExist = false;
        }
        prefabInstance.SetActive(false);
        Debug.Log("torretaExist = " + torretaExist);
        torretaExist = false;
    }

    // Then set it to inactive ready for the next drag!

}
