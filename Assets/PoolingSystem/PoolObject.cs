using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol.PoolSystem {
	public class PoolObject : MonoBehaviour {
		public string objectName;

		public System.Action OnActivate;
		public System.Action OnDestroy;



		public void Activate () {
			OnActivate?.Invoke();
		}

		public void Destroy () {
			OnDestroy?.Invoke();
		}
	} 
}
