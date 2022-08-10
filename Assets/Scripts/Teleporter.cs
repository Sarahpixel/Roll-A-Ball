using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{


public GameObject myPartner;
public bool canTeleport = true;
    // Start is called before the first frame update
    private  void Start()
    {
        canTeleport = true;  
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canTeleport)
        {
            
           myPartner.GetComponent<Teleporter>().canTeleport = false;
        //Offset the Y position so we dont phasde through the ground
        Vector3 endPos = new Vector3(myPartner.transform.position.x, 1, myPartner.transform.position.z);
        other.transform.position = endPos;

            
        }
    }
        public void onTriggerExit(Collider other)
        {
             if (other.CompareTag("Player") && !canTeleport)
              canTeleport = true;
        }

}
