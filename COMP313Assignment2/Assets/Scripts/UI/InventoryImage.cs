using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventoryImage : MonoBehaviour {

    public Sprite empty;
    public Sprite domino;
    public int inventorySlot;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (PlayerAction.inventory[inventorySlot] == null)// && PlayerAction.inventory[inventorySlot].CompareTag("Domino"))
        {
            Debug.Log("replace with empty");
            GetComponent<Image>().sprite = empty;
            //GetComponent<Image>().sprite = domino;
        }
        else if (PlayerAction.inventory[inventorySlot].CompareTag("Domino"))
        {
            Debug.Log("replace with domino");
            //GetComponent<Image>().sprite = empty;
            GetComponent<Image>().sprite = domino;
        }
	}
}
