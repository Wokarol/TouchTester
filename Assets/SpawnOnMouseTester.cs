using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol.Testing {
	public class SpawnOnMouseTester : MonoBehaviour {
		[SerializeField] PoolSystem.PoolObjectIdentificator identificator;
		[SerializeField] bool useMouse;

		PoolSystem.PoolObject poolObject;

		void Update () {
			// Mouse
			if (useMouse) {
				Camera main = Camera.main;
				Vector3 mousePos = main.ScreenToWorldPoint(Input.mousePosition) - (Vector3.forward * main.transform.position.z);
				if (Input.GetMouseButtonDown(0)) {

					poolObject = PoolSystem.PoolManager.Spawn(identificator, mousePos, Quaternion.identity);

					Debug.DrawLine(Vector3.zero, mousePos);
				}
				if (Input.GetMouseButtonUp(0)) {
					poolObject.Destroy();
					poolObject = null;
				}
				if (poolObject != null) {
					poolObject.transform.position = mousePos;
				}
			} else {
				// Touch
				if (Input.touchCount > 0) {
					Touch touch = Input.GetTouch(0);
					Camera main = Camera.main;
					Vector3 touchPos = main.ScreenToWorldPoint(touch.position) - (Vector3.forward * main.transform.position.z);
					if (touch.phase == TouchPhase.Began) {
						poolObject = PoolSystem.PoolManager.Spawn(identificator, touchPos, Quaternion.identity);
						Debug.DrawLine(Vector3.zero, touchPos);
					} else {
						poolObject.transform.position = touchPos;
					}
				} else if (poolObject != null) {
					poolObject.Destroy();
					poolObject = null;
				}
			}
		}
	}
}