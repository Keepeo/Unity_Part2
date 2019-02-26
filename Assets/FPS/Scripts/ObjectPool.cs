using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
	public class ObjectPool : MonoBehaviour 
	{
		public static ObjectPool Instance {get; private set;}

		[SerializeField]
		private GameObject[] objects;
		private Dictionary<string, Queue<IPoolable>> objectDict = new Dictionary<string, Queue<IPoolable>>();
		
		void Awake()
		{
			if (Instance) DestroyImmediate(gameObject);
			else Instance = this;
		}

		void Start()
		{
			foreach (var o in objects)
			{
				var poolObj = o.GetComponent<IPoolable>();
				if (poolObj == null) continue; 
				if (objectDict.ContainsKey(poolObj.PoolID)) 
				{
					Debug.LogWarning($"Pool already contains object with ID: {poolObj.PoolID}");
					continue;
				}
			

			var queue = new Queue<IPoolable>();
			for (int i = 0; i < poolObj.ObjectsCount; i++)
			{
				var go=Instantiate(o);
				go.SetActive(false);
				queue.Enqueue(go.GetComponent<IPoolable>());
			}
			objectDict.Add(poolObj.PoolID, queue);
			}
 		}

		 public IPoolable GetObject(string poolID)
		 {
			 if (string.IsNullOrEmpty(poolID)) return null;
			 if (!objectDict.ContainsKey(poolID)) return null;

			 var p = objectDict[poolID].Dequeue();
			 objectDict[poolID].Enqueue(p);

			 return p;
		 }
	}
}

