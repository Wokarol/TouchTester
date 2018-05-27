using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol.Testing {
	public class SpawnOnMouseTester : MonoBehaviour {

		void Update () {
			if (Input.GetMouseButtonDown(0)) {
				Camera main = Camera.main;
				Vector3 clickPos = main.ScreenToWorldPoint(Input.mousePosition) - (Vector3.forward * main.transform.position.z);

				PoolSystem.PoolManager.Spawn("PressIcon", clickPos, Quaternion.identity);

				Debug.DrawLine(Vector3.zero, clickPos);
			}
		}
	}
}