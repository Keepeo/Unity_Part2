using System;
using UnityEngine;

namespace FPS
{
	public class BotSpawner : MonoBehaviour
	{
        public EnemyBot.BotSpawnParams SpawnParams;
        public EnemyBot BotPrefab;

        private EnemyBot instance;

        private void Update()
        {
            if (instance) return;
            instance = Instantiate(BotPrefab, transform.position, transform.rotation);
            instance.Initialization(SpawnParams);
        }
    }
}