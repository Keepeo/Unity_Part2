using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;
using System.Collections;
using System.Collections.Generic;

namespace FPS
{
	public class EnemyBot : MonoBehaviour, IDamageable
	{
		private float searchDistance = 40f;
		private float attackDistance = 20f;
		private float maxRandomRadius = 20f;
		private bool useRandomWP = true;
		private NavMeshAgent agent;
		private Vector3 randomPos;
		private Waypoint[] waypoints;	

		public void Initialization(BotSpawnParams spawnParams)
		{
			useRandomWP = waypoints.Length <= 1;
			maxRandomRadius = Mathf.Max(2, spawnParams.MaxRandomRadius);
			waypoints = spawnParams.Waypoint;
			searchDistance = spawnParams.SearchDistance;
			attackDistance = spawnParams.AttackDistance; 

			agent = GetComponent<NavMeshAgent>();
		}

		private void Update()
		{
			//Can attack?
			if (CurrentHealth <=0) return;

			if (UseRandomWP)
			{
				agent.SetDestination(randomPos);
				if (!agent.hasPath || agent.remainingDistance > MaxRandomRadius * 2) randomPos = GenerateWayPoint();
			}
		}
		
			private Vector3 GenerateWayPoint()
			{
				var result = MaxRandomRadius * Random.insideUnitSphere;
				NavMeshHit hit;

				if (NavMesh.SamplePosition(transform.position + result, out hit, MaxRandomRadius * 1.5f, NavMesh.AllAreas)) return hit.position;
				else return transform.position;
			}
		//#region IDamageable
		[SerializeField]
		private float currentHealth = 100f;
		public float CurrentHealth
		{
			get { return currentHealth; }
			set { currentHealth = value; }
		}

		public void ApplyDamage(float damage, Vector3 damageDirection)
		{
			if (CurrentHealth <=0) return;
			CurrentHealth -= damage;
			if (CurrentHealth <=0) Death();
		}

		private void Death()
		{
			foreach (var c in GetComponentsInChildren<Transform>())
			{
				c.SetParent(null);	
				Destroy(c.gameObject, Random.Range(2f,4f));
				
				var col = c.GetComponent<Collider>();
				if (col) col.enabled = true;

				var rb = c.gameObject.AddComponent<Rigidbody>();				
				rb.mass = 5;
				rb.AddForce(Vector3.up * Random.Range(10f, 30f), ForceMode.Impulse);
			}
		}

		[Serializable]
		public class BotSpawnParams
        {
            public Waypoint[] waypoints;
            public float SearchDistance;
		    public float AttackDistance;
			public float MaxRandomRadius;          
        }		
	}
}