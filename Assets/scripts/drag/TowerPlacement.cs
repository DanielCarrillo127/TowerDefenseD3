using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    private GameObject CurrentPlacingTower;
    [SerializeField] private Camera PlayerCamera;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentPlacingTower != null)
        {
            Ray camray = PlayerCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(camray, out RaycastHit hitinfo, 1000f))
            {
                CurrentPlacingTower.transform.position = hitinfo.point;
            }
            if (Input.GetMouseButtonDown(0))
            {
                CurrentPlacingTower = null;
            }
        }

    }

    public void SetTowerToPlace(GameObject Tower)
    {
        Debug.Log("clicked");
        CurrentPlacingTower = Instantiate(Tower, Vector3.zero, Quaternion.identity);
    }
}
