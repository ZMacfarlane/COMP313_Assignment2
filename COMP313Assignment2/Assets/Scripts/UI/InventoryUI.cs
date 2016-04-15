using UnityEngine;
using System.Collections;

public class InventoryUI : MonoBehaviour {

    public Vector3 initialLocation;

    int inventorySlot;
    int slotSpacing = 45;
    

    // Use this for initialization
    void Awake () {
        inventorySlot = 0;
	}
	
	// Update is called once per frame
	void Update () {
        //inventorySlot = PlayerAction.selectedItem;
        HighlightSelection();
	}

    void HighlightSelection()
    {
        Vector3 highlightLocation = new Vector3( initialLocation.x + /*inventorySlot*/ 5*slotSpacing, initialLocation.y, initialLocation.z);
        transform.TransformPoint(highlightLocation);
    }

}
