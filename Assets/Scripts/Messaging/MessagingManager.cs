using UnityEngine;
using System;
using System.Collections.Generic;

public class MessagingManager : MonoBehaviour {

	public static MessagingManager Instance { get; private set; }
	public List<Action> subscribers = new List<Action>();

	void Awake() {
		Debug.Log ("Messaging Manager Started");
		if (Instance != null && Instance != this) {
			Destroy (gameObject);
		}
		Instance = this;
		DontDestroyOnLoad (gameObject);
	}

	public void Subscribe(Action subscriber) {
		Debug.Log ("Subscriber registered");
		subscribers.Add (subscriber);
	}

	public void Unsubscribe(Action subscriber) {
		Debug.Log ("Subscriber unregistered");
		subscribers.Remove (subscriber);
	}

	public void ClearAllSubscribers() {
		subscribers.Clear ();
	}

	public void Broadcast() {
		Debug.Log ("Broadcast requested, No of subscribers = " + subscribers.Count);
		foreach (var subscriber in subscribers) {
			subscriber ();
		}
	}
}
