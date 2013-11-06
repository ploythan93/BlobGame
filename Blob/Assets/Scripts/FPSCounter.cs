using UnityEngine;
using System.Collections;

public class FPSCounter : MonoBehaviour 
{
	public float updateInterval = 0.5f;
 
	private float accum = 0; // FPS accumulated over the interval
	private float frames = 0; // Frames drawn over the interval
	private float timeleft; // Left time for current interval

	void Start()
	{
		//Application.targetFrameRate = -1;
	    if( !guiText )
	    {
	        print ("FramesPerSecond needs a GUIText component!");
	        enabled = false;
	        return;
	    }
	    timeleft = updateInterval;  
	}
 
	void Update()
	{
	    timeleft -= Time.deltaTime;
	    accum += Time.timeScale/Time.deltaTime;
	    ++frames;
	 
	    // Interval ended - update GUI text and start new interval
	    if( timeleft <= 0.0 )
	    {
	        // display two fractional digits (f2 format)
	        guiText.text = "" + (accum/frames).ToString("f2");
	        timeleft = updateInterval;
	        accum = 0;
	        frames = 0;
	    }
	}
}
