using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class AudioHandler : MonoBehaviour, ITrackableEventHandler {

    private TrackableBehaviour audioTrackableBehaviour;
    public AudioSource audio;
    public GameObject bubbleTarget;
    public PlayableDirector timeline;
	// Use this for initialization
	void Start () {
        audioTrackableBehaviour = GetComponent<TrackableBehaviour>();
        timeline = bubbleTarget.GetComponent<PlayableDirector>();
        timeline.Stop();
        audio.Stop();

        if (audioTrackableBehaviour)
        {
            audioTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
		
	}
	
    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if(newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            timeline.Play();
            audio.Play();
            Debug.Log("Audio begin");
        }

        else
        {
            timeline.Stop();
            audio.Stop();
            Debug.Log("Audio stop");
        }
            
    }
}
