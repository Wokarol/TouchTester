using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol.PoolSystem {
	public class PoolManager : MonoBehaviour {
		[SerializeField] PoolObjectToAdd[] pools;
		Dictionary<string, int> nameToIndex = new Dictionary<string, int>();

		static PoolManager instance;
		private void Awake () {
			if(instance != null) {
				Destroy(gameObject);
				return;
			}
			instance = this;

			for (int i = 0; i < pools.Length; i++) {
				nameToIndex.Add(pools[i].prefab.objectName, i);

				for (int j = 0; j < pools[i].startCount; j++) {
					pools[i].AddObject(Instantiate(pools[i].prefab, transform));
				}
			}
		}

		internal void RegisterDestroyed (string _name, PoolObject poolObject) {
			if (!instance.nameToIndex.ContainsKey(_name)) {
				Debug.LogError("<color=red>There is no pool named " + _name + " in Dictionary</color>");
				return;
			}
			instance.pools[instance.nameToIndex[_name]].AddObject(poolObject);
		}

		public static PoolObject Spawn(string _name, Vector3 pos, Quaternion rot) {
			if (!instance.nameToIndex.ContainsKey(_name)) {
				Debug.LogError("<color=red>There is no pool named " + _name + " in Dictionary</color>");
				return null;
			}
			if(instance.pools[instance.nameToIndex[_name]].ObjectsToUse <= 0) {
				//Debug.LogError("<color=red>There is no more elements in pool named " + _name + "</color>");
				//return null;
				Debug.Log("Added");
				for (int j = 0; j < instance.pools[instance.nameToIndex[_name]].growBy; j++) {
					instance.pools[instance.nameToIndex[_name]].AddObject(Instantiate(instance.pools[instance.nameToIndex[_name]].prefab, instance.transform));
				}
			}
			PoolObject _obj = instance.pools[instance.nameToIndex[_name]].GetObject();
			_obj.transform.SetPositionAndRotation(pos, rot);

			_obj.Activate(instance);

			return _obj;
		}

	}

	[System.Serializable]
	class PoolObjectToAdd {
		[SerializeField] internal PoolObject prefab;
		[Space]
		[SerializeField] internal float startCount;
		[SerializeField] internal float growBy;

		Queue<PoolObject> objects = new Queue<PoolObject>();
		internal int ObjectsToUse { get; private set; } = 0;



		internal void AddObject(PoolObject _obj) {
			objects.Enqueue(_obj);
			ObjectsToUse++;
		}
		internal PoolObject GetObject () {
			ObjectsToUse--;
			return objects.Dequeue();
		}
	}
}
