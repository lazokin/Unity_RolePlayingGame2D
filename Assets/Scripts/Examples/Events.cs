using UnityEngine;
using System.Collections;

public class Events : MonoBehaviour {

	public delegate void MyEventDelegate();
	public static event MyEventDelegate SpaceEvent;

	void Start() {
		SpaceEvent += SpaceEventCallback;
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Space)) {
			OnSpaceEvent ();
		}
	}

	void OnDestroy() {
		SpaceEvent -= SpaceEventCallback;
	}

	void SpaceEventCallback() {
		Debug.Log ("Space was pressed");
	}

	void OnSpaceEvent() {
		if (SpaceEvent != null) {
			SpaceEvent ();
		}
	}

}
