using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Wokarol.PoolSystem;

public class PoolObjectTester : MonoBehaviour {
	[SerializeField] PoolObject testedObject;

	private void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			testedObject.Activate();
		}
		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			testedObject.Destroy();
		}
	}

}
