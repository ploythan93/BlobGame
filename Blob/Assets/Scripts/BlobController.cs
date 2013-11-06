using UnityEngine;
using System.Collections;

public class BlobController : MonoBehaviour {
	
	public GameObject blobCenter;
	public float pressureValue;
	private InteractiveCloth blobCloth;

	private float forceToKeepOnZ=0.0f;
	
	private float forwardAccel;
	void Start()
	{
		blobCloth=this.GetComponent<InteractiveCloth>();
		pressureValue = blobCloth.pressure;
		
		
	}
	// Update is called once per frame
	void Update () 
	{
		blobCenter.transform.position =this.renderer.bounds.center; 
		pressureValue = Input.GetAxis("Vertical")*1.5f+1.0f;
		forwardAccel = Input.GetAxis("Horizontal")*15;
		blobCloth.externalAcceleration=new Vector3(forwardAccel, 0 ,forceToKeepOnZ); 
			
		if(blobCenter.transform.position.z>0.15)forceToKeepOnZ=-5f;
		else if(blobCenter.transform.position.z<-0.15)forceToKeepOnZ=5f;
		else forceToKeepOnZ=0;
	}
	
	void OnGUI()
	{
		 //this.GetComponent<InteractiveCloth>().pressure = 1;
		
		//pressureValue = GUI.HorizontalSlider(new Rect(25, 25,Screen.width-50 , 100), pressureValue, 0.0f, 2.5f);
		//forwardAccel = GUI.HorizontalSlider(new Rect(25, Screen.height-50,Screen.width-50 , 100), forwardAccel, -15.0f, 15.0f);
		blobCloth.pressure = pressureValue;
		
		
		
	}
}
