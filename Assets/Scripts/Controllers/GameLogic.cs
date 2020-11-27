using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityStandardAssets.Utility;

public class GameLogic : MonoBehaviour {


	 float dt;
	 public List<IUpdateable> _updateableObjects = new List<IUpdateable>();

	public void RegisterUpdateObject(IUpdateable obj)
	{
		if (!_updateableObjects.Contains (obj)) {
			_updateableObjects.Add (obj);
		}
	}

	public void DeRegisterUpdateObject(IUpdateable obj)
	{
		if (_updateableObjects.Contains (obj)) {
			_updateableObjects.Remove (obj);
		}
	}
		
	// Update is called once per frame
	void Update () {

		dt = Time.deltaTime;

		for (int i = 0; i < _updateableObjects.Count; ++i) {
			_updateableObjects [i].OnUpdate (dt);
			}
			
	}
}
