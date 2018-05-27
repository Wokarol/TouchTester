using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Wokarol.PoolSystem;

namespace Wokarol.Reactor {
	public class EndAnimReactor :MonoBehaviour {
		[SerializeField] PoolObject poolObject;
		[Space]
		[SerializeField] Animator animator;

		private void OnEnable () {
			poolObject.OnDestroy += OnDestroyObject;
		}

		public void OnDestroyObject () {
			animator.SetTrigger("End");
		}
	} 
}
