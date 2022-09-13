using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleRecycle: MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
    {
        var vehicleController = other.gameObject.GetComponent<VehicleController>();
    
        if(vehicleController)
        {
            vehicleController.ReturnToStartPosition();
        }
    } 

}
