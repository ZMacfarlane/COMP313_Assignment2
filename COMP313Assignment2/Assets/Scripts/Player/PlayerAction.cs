using UnityEngine;
using System.Collections;

public class PlayerAction : MonoBehaviour {

    //public GameObject selectedBuilding;
    public static int selectedItem = 0;

    //Temp: Move to Manager later
    //public int playerGold = 1000;
    //public int buildingCost = 200;

    int item;
    float camRayLength = 7f;
    
    //Camera camera;

    void Awake()
    {
        // camera = GetComponent<Camera>();
        //playerManager = GetComponent<PlayerManagement>();
        item = LayerMask.GetMask("Pickupable");
    }

    void FixedUpdate()
    {
        selectedItem -=  (int)Input.mouseScrollDelta.y;
        if (selectedItem < 0)
        {
            selectedItem = 8;
        }
        if (selectedItem > 8)
        {
            selectedItem = 0;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {


            /*
            if(buildingCost <= playerGold)
            {
                //Build equiped building
                Instantiate(selectedBuilding, transform.position + (transform.forward * 2), transform.rotation);
            }
            */
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Pickup();//try to pickup object
        }

        if (Input.GetMouseButtonDown(1))
        {
            //pickup item
            Pickup();
        }

        //if (Input.GetMouseButtonDown(0))
        if (Input.GetKeyDown(KeyCode.E))
        {
            //pickup item
            PlaceItem();
        }

        /*
        if (Input.GetKeyDown(KeyCode.F))
        {
            //open build menu
        }
        */
    }

    void Pickup()
    {
        //if raycast hit object tagged pickupable, place item in inventory
        RaycastHit hit = new RaycastHit();
        Ray camRay = Camera.main.ScreenPointToRay(new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2));
        if (Physics.Raycast(camRay, out hit, camRayLength, item))
        {
            int i = InventoryAvailable();
            if (i >= 0)
            {
                GameObject select = hit.transform.gameObject;
                PlayerManagement.inventory[i] = Instantiate<GameObject>(select);
                //Destroy(hit.transform.gameObject);
                Destroy(select);
            }
            
        }
    }
    
    public int InventoryAvailable()
    {
        for (int i = 0; i < PlayerManagement.inventory.Length; i++)
        {
            if (PlayerManagement.inventory[i] == null)
            {
                return i;
            }
        }
        return -1;

    }

    void PlaceItem()
    {
        if (PlayerManagement.inventory[selectedItem] != null)
        {
            Instantiate(PlayerManagement.inventory[selectedItem], transform.position + (transform.forward * 2), transform.rotation);
            PlayerManagement.inventory[selectedItem] = null;
        }
    }
    
}
