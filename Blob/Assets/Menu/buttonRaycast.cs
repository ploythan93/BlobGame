using UnityEngine;
using System.Collections;

public class buttonRaycast : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		
		if(Physics.Raycast(ray, out hit))
		{
			if(hit.collider.name=="Button")
			{
				buttonBehaviourScript temp = hit.collider.gameObject.GetComponent<buttonBehaviourScript>();
				temp.selected=true;
				
				if(Input.GetMouseButtonDown(0))temp.pop=true;
			}
		}
	}
}
