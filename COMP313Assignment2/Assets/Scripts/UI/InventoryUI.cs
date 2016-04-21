using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventoryUI : MonoBehaviour {

    public float initX;

    int inventorySlot;
    int slotSpacing = 45;
    Image highlightImage;

    void Awake () {
        inventorySlot = 0;
        highlightImage = GetComponent<Image>();
    }
	
	void Update () {
        inventorySlot = PlayerAction.selectedItem;
        HighlightSelection();
	}

    void HighlightSelection()
    {
        highlightImage.rectTransform.position = new Vector3(initX + (inventorySlot+1) * slotSpacing, transform.position.y, transform.position.z);
    }

}
