using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol.Testing {
	public class SpawnOnMouseTester : MonoBehaviour {

		PoolSystem.PoolObject poolObject;

		void Update () {
			Camera main = Camera.main;
			Vector3 mousePos = main.ScreenToWorldPoint(Input.mousePosition) - (Vector3.forward * main.transform.position.z);
			if (Input.GetMouseButtonDown(0)) {

				poolObject = PoolSystem.PoolManager.Spawn("PressIcon", mousePos, Quaternion.identity);

				Debug.DrawLine(Vector3.zero, mousePos);
			}
			if (Input.GetMouseButtonUp(0)) {
				poolObject.Destroy();
				poolObject = null;
			}
			if (poolObject != null) {
				poolObject.transform.position = mousePos;
			}
		}
	}
}