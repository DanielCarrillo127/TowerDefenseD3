using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject prefab;
    GameObject prefabInstance;


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
        Debug.Log("Beginning drag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        RaycastHit[] hits;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hits = Physics.RaycastAll(ray, 50f);
        if (hits != null && hits.Length > 0)
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
    }

    /* void EnableSlot(GameObject slot) {
		foreach (GameObject availableSlot in availableSlots) {
			if (slot.name.Equals(availableSlot.name)) {
				availableSlot.GetComponent<MeshRenderer> ().enabled = true;
			} else {
				availableSlot.GetComponent<MeshRenderer> ().enabled = false;
			}
		}
	}

	void DisableAllSlots() {
		foreach (GameObject availableSlot in availableSlots) {
			availableSlot.GetComponent<MeshRenderer> ().enabled = false;
		}
	} */

    /* void MaybeShowprefabInstance(RaycastHit[] hits)
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
 */
    int GetTerrainColliderQuadIndex(RaycastHit[] hits)
    {
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.gameObject.name.Equals("TerrainColliderQuad"))
            {
                return i;
            }
        }

        return -1;
    }

    // Returns an index on a slot if the mouse is hovering over it.
    /* int GetSlotIndex(RaycastHit[] hits) {
		for (int i = 0; i < hits.Length; i++) {
			if (hits [i].collider.gameObject.name.StartsWith ("Slot")) {
				return i;
			}
		}
		return -1;
	} */

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Ending drag");
        if (prefabInstance.activeSelf)
        {
            // MeshFilter mf = activeSlot.GetComponent<MeshFilter> ();
            Instantiate(prefab, prefabInstance.transform.position, Quaternion.identity);
        }

        // Then set it to inactive ready for the next drag!
        prefabInstance.SetActive(true);
    }

    /* Vector3 GetQuadCentre(GameObject quad)
    {
        Vector3[] meshVerts = quad.GetComponent<MeshFilter>().mesh.vertices;
        Vector3[] vertRealWorldPositions = new Vector3[meshVerts.Length];

        for (int i = 0; i < meshVerts.Length; i++)
        {
            vertRealWorldPositions[i] = quad.transform.TransformPoint(meshVerts[i]);
        }

        Vector3 midPoint = Vector3.Slerp(vertRealWorldPositions[0], vertRealWorldPositions[1], 0.5f);
        return midPoint;
    } */
}
