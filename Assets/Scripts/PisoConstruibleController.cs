using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PisoConstruibleController : MonoBehaviour
{
    public GameObject TurretPrefab;
    private void Start()
    {

    }
    private void Update()
    {
        
        
    }
    
    private void OnMouseUp()
    {
        Debug.Log("Click en "+this.name);
        Vector3 turretPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 turretPosition2D = new Vector2(turretPosition.x,turretPosition.y);
        Instantiate(TurretPrefab,turretPosition2D,Quaternion.identity);
    }
}
