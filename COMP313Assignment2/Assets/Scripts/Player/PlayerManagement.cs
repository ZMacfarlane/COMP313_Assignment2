using UnityEngine;
using System.Collections;

public class PlayerManagement : MonoBehaviour {

    public static GameObject[] inventory;

	void Awake()
    {
        inventory = new GameObject[9];

    }

    void Update()
    {
        
    }
    
    void PrintInventory()
    {
        for(int i = 0; i < inventory.Length; i++){
            Debug.Log(inventory[i]);
        }
    }
}
