using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


    public class EnemyManager : MonoBehaviour
    {
        public Transform prefab;
        public Dictionary<int, EnemyFish> enemies;

        public int enemyCount = 10;
        public float spawnRateInSeconds = 5;

        private float timeSinceSpawn = 0;

        public List<EnemyFish> enemyPool;

        public void Start()
        {
            enemies = new Dictionary<int, EnemyFish>();
            enemyPool = new List<EnemyFish>();

            for (int count = 0; count < enemyCount; count++)
            {
                Transform newFish = (Transform)Instantiate(prefab);
                newFish.gameObject.SetActiveRecursively(false);

                EnemyFish fishBehavior = (EnemyFish)newFish.GetComponent("EnemyFish");
                if (fishBehavior != null)
                {
                    fishBehavior.manager = this;
                }

                enemyPool.Add(fishBehavior);
            }
        }

        public void Update()
        {
            timeSinceSpawn += Time.deltaTime;

            if (timeSinceSpawn >= spawnRateInSeconds)
            {
                if (enemyPool.Count > 0)
                {
                    EnemyFish newEnemy = enemyPool[0];
                    enemyPool.RemoveAt(0);
                    SpawnEnemy(newEnemy);
                    timeSinceSpawn = 0f;
                }
            }
        }

        public void Reset()
        {
            foreach (EnemyFish fish in enemies.Values)
            {
                fish.gameObject.SetActiveRecursively(false);
                fish.ResetState();
                enemyPool.Add(fish);
            }

            enemies.Clear();
        }


        internal void InformDeath(EnemyFish deadEnemy)
        {
            if (enemies.ContainsKey(deadEnemy.gameObject.GetInstanceID()))
            {
                Debug.Log("+++ Killing enemy " + deadEnemy.gameObject.GetInstanceID());
                enemyPool.Add(deadEnemy);
                enemies.Remove(deadEnemy.gameObject.GetInstanceID());
                deadEnemy.ResetState();
                deadEnemy.gameObject.SetActiveRecursively(false);
            }
        }


        internal void SpawnEnemy(EnemyFish enemy)
        {
            int rndx = UnityEngine.Random.Range(0, 10);

            float x = 0f;
            float y = 0f;

            if (rndx >= 5)
            {
                x = Player.distanceTraveledX + 100f;
            }
            else
            {
                x = Player.distanceTraveledX - 100f;
            }

            y = UnityEngine.Random.Range(Player.distanceTraveledY - 100f, Player.distanceTraveledY + 100f);


            Vector3 position = new Vector3(x, y, 0f);

            enemy.gameObject.transform.localPosition = position;
            enemy.gameObject.SetActiveRecursively(true);
            this.enemies.Add(enemy.gameObject.GetInstanceID(), enemy);
        }
    }
