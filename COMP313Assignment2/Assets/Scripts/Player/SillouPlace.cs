using UnityEngine;
using System.Collections;

public class SillouPlace : MonoBehaviour {

	public GameObject block;

	private int count;
	GameObject sillou;
	// Use this for initialization
	void Start () {
		count = 1;
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if(Input.GetMouseButtonDown(1))
		{
			
			Vector3 fred;// = new Vector3 (hit.point);
			//Instantiate(block, fred, 0);
			if (Physics.Raycast(ray, out hit, 200))
			{
				fred = new Vector3 (hit.point.x, hit.point.y, hit.point.z);
				Debug.Log ("count = " + count);
				count++;
				sillou = (GameObject)Instantiate(block, fred, new Quaternion());
			}
		}
		if(Input.GetMouseButtonUp(1))
		{
			Destroy (sillou);
		}
			
	}
}
