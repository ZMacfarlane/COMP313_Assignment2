using UnityEngine;
using System.Collections;

public class SillouPlace : MonoBehaviour {

	public GameObject block;

	private int count;
	GameObject sillou;

	void Start () {
		count = 1;
	}
	
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

        //if(Input.GetMouseButtonDown(1))
        if (Input.GetKeyDown(KeyCode.Q))
		{
			
			Vector3 lookLoc;
			if (Physics.Raycast(ray, out hit, 200))
			{
				lookLoc = new Vector3 (hit.point.x, hit.point.y + block.transform.localScale.y / 2, hit.point.z);
				sillou = (GameObject)Instantiate(block, lookLoc, new Quaternion());
			}
		}
        //if(Input.GetMouseButtonUp(1))
        if (Input.GetKeyUp(KeyCode.Q))
        {
			Destroy (sillou);
		}
			
	}
}
