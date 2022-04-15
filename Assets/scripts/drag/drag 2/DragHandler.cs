using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject prefab;
    GameObject prefabInstance;
    public GameObject dinero;

    // Use this for initialization
    void Start()
    {
        prefabInstance = Instantiate(prefab);
        RemoveScriptsFromPrefab();
        AdjustPrefabAlpha();
        prefabInstance.SetActive(false);
    }
    void OnTriggerEnter(Collision collision)
    {
        Debug.Log("collision collision");
        /* if (collision.gameObject.tag == "Torreta")
        {
            Destroy(collision.gameObject);
            prefabInstance.SetActive(false);
            dinero.GetComponent<PlayerController>().addMoney(5);
        } */
        /* Destroy(collision.gameObject);
        prefabInstance.SetActive(false);
        dinero.GetComponent<PlayerController>().addMoney(5); */

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
        if (hits != null && hits.Length > 0 && dinero.GetComponent<PlayerController>().money >= 5)
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
                return i;
            }
            /* if(hits[i].collider.gameObject.tag.Equals("TerrainColliderQuad")){
                return -1;
            } */
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
        if (prefabInstance.activeSelf)
        {
            // MeshFilter mf = activeSlot.GetComponent<MeshFilter> ();
            Instantiate(prefab, prefabInstance.transform.position, Quaternion.identity);
            prefabInstance.SetActive(true);
            dinero.GetComponent<PlayerController>().substractMoney(5);
        }
        else
        {
            //dinero.GetComponent<PlayerController>().addMoney(5);

            prefabInstance.SetActive(false);
        }
        prefabInstance.SetActive(false);
    }

    // Then set it to inactive ready for the next drag!

}


