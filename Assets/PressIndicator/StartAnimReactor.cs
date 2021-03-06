﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Wokarol.PoolSystem;

namespace Wokarol.Reactor {
	public class StartAnimReactor :MonoBehaviour {
		[SerializeField] PoolObject poolObject;
		[Space]
		[SerializeField] Animator animator;
		[SerializeField] SpriteRenderer sprite;

		private void OnEnable () {
			sprite.enabled = false;
			poolObject.OnActivate += OnActivateObject;
		}

		public void OnActivateObject () {
			sprite.enabled = true;
			animator.SetTrigger("Start");
		}
	} 
}
