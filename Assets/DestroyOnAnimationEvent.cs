using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol {
	public class DestroyOnAnimationEvent : MonoBehaviour {
		[SerializeField] PoolSystem.PoolObject poolObject;
		public void Destroy () {
			poolObject.Destroy();
		}

	}
}