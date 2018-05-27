using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol.PoolSystem {
	public class PoolManager : MonoBehaviour {
		[SerializeField] PoolObjectToAdd[] poolObjectsToAdd;
		Dictionary<string, Pool> pools = new Dictionary<string, Pool>();

		public static PoolManager Instance { get; private set; }
		private void Awake () {
			foreach (PoolObjectToAdd poolObjectToAdd in poolObjectsToAdd) {

				Queue<PoolObject> objects = new Queue<PoolObject>();
				for (int i = 0; i < poolObjectToAdd.startCount; i++) {
					PoolObject poolObject = Instantiate(poolObjectToAdd.poolObject, transform);
					objects.Enqueue(poolObject);
				}

				Pool pool = new Pool(objects, poolObjectToAdd.growBy);
				pools.Add(poolObjectToAdd.poolObject.objectName, pool);
			}
		}

	}

	[System.Serializable]
	class PoolObjectToAdd {
		public PoolObject poolObject;
		public float startCount;
		public float growBy;

		public PoolObjectToAdd (PoolObject poolObject, float startCount, float growBy) {
			this.poolObject = poolObject;
			this.startCount = startCount;
			this.growBy = growBy;
		}
	}

	class Pool {
		public Queue<PoolObject> objects;
		public float growBy;

		public Pool (Queue<PoolObject> objects, float growBy) {
			this.objects = objects;
			this.growBy = growBy;
		}
	}
}
