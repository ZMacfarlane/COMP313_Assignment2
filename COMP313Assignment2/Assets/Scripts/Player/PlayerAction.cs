using UnityEngine;
using System.Collections;

public class PlayerAction : MonoBehaviour {

    public static int selectedItem = 0;

    int item;
    float camRayLength = 7f;

    void Awake()
    {
        item = LayerMask.GetMask("Pickupable");
    }

    void Update()
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
        if (Input.GetKeyDown(KeyCode.Alpha1)) selectedItem = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2)) selectedItem = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3)) selectedItem = 2;
        if (Input.GetKeyDown(KeyCode.Alpha4)) selectedItem = 3;
        if (Input.GetKeyDown(KeyCode.Alpha5)) selectedItem = 4;
        if (Input.GetKeyDown(KeyCode.Alpha6)) selectedItem = 5;
        if (Input.GetKeyDown(KeyCode.Alpha7)) selectedItem = 6;
        if (Input.GetKeyDown(KeyCode.Alpha8)) selectedItem = 7;
        if (Input.GetKeyDown(KeyCode.Alpha9)) selectedItem = 8;

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
    }

    //attempt to pick up item, and place it in first available slot
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
