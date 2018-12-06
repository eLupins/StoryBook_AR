using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class transmediaAR : MonoBehaviour, ITrackableEventHandler {


    private TrackableBehaviour mTrackableBehaviour;


	// Use this for initialization
	void Start () {

        //get the tackable behaviour component and attach it to mTrackableBehaviour variable 
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour) // if working 
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this); //display the object
            Debug.Log("Registered"); //when the image target is found, print this log 
        }
	}

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        //is the image target is tracked and recorded
        if (newStatus == TrackableBehaviour.Status.DETECTED || 
            newStatus == TrackableBehaviour.Status.TRACKED || 
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            //print the debug log so we know were reaching this spot 
            //here is where we place we want to put our pop up stuff at. refer to buttonClick script from MuseumAR for reference in needed
            
            Debug.Log("StoryBook AR has detected a target.");

            TextEffect[] txt = GetComponentsInChildren<TextEffect>();
            foreach (TextEffect te in txt)
            {
                Debug.Log("TextEffect running");
                te.RunEffect();
                
            }
            
            MediaEffect[] media = GetComponentsInChildren<MediaEffect>();
            foreach (MediaEffect me in media)
            {
                Debug.Log("MediaEffect running");
                me.RunShader();

            }
            

        }          
    }

    // Update is called once per frame
    void Update () {
		
        
	}

    public void OnCollisionEnter(Collision col)
    {

    }
    public void OnCollisionExit(Collision col)
    {

    }
}
