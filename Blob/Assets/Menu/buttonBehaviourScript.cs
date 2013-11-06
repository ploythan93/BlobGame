using UnityEngine;
using System.Collections;

public class buttonBehaviourScript : MonoBehaviour {
	
	public bool selected = false;
	public bool pop = false;
	public int levelLoad;
	private InteractiveCloth thisButton;
	private double maxPressure=2.5f;
	private double historyPressure=0.0;
	private float timer=0.0f;

	// Use this for initialization
	void Start () {
		thisButton=this.GetComponent<InteractiveCloth>();
		historyPressure = thisButton.pressure;
	}
	
	// Update is called once per frame
	void Update () {
		if(selected)
		{
			if(thisButton.pressure<maxPressure)thisButton.pressure+=0.1f;
			
		}
		else
		{
			if(thisButton.pressure>historyPressure)thisButton.pressure-=0.1f;
		}
		
		
		if(pop)
		{
			thisButton.tearFactor=1.5f;
			timer+=Time.deltaTime;
			Debug.Log (timer);
			if(timer>1)Application.LoadLevel(levelLoad);
			
		}
		
		selected=false;
	}
}
