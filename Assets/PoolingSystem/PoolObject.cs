using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol.PoolSystem {
	public class PoolObject : MonoBehaviour {
		public PoolObjectIdentificator objectName;
		private PoolManager manager;

		public System.Action OnActivate;
		public System.Action OnDestroy;


		public void Activate (PoolManager _manager = null) {
			OnActivate?.Invoke();
			manager = _manager;
		}

		public void Destroy () {
			OnDestroy?.Invoke();
			if(manager != null) {
				manager.RegisterDestroyed(objectName, this);
			}
		}
	} 
}
