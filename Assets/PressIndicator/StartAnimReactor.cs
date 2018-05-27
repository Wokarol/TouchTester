using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Wokarol.PoolSystem;

namespace Wokarol.Reactor {
	public class StartAnimReactor :MonoBehaviour {
		[SerializeField] PoolObject poolObject;
		[Space]
		[SerializeField] Animator animator;
		[SerializeField] SpriteRenderer sprite;

		private void Start () {
			sprite.gameObject.SetActive(false);

			poolObject.OnActivate += OnActivateObject;
		}

		public void OnActivateObject () {
			sprite.gameObject.SetActive(true);
			animator.SetTrigger("Start");
		}
	} 
}
