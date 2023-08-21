using System;
using System.Collections;
using UnityEngine;

namespace Game.Scripts
{
    public class GameController : MonoBehaviour
    {
        public Character player;
        public Character enemy;

        
        private IEnumerator Start()
        {
            while (true)
            {
                if (player.Health > 0 && enemy.Health > 0)
                {
                    yield return player.Attack(enemy);
                }
                
                yield return new WaitForSeconds(1f);
                
                if (player.Health > 0 && enemy.Health > 0)
                {
                    yield return enemy.Attack(player);
                }
                
                yield return new WaitForSeconds(1f);
                
                if (player.Health == 0 || enemy.Health == 0)
                {
                    Debug.Log($"{GetType().Name}.Start: player.Health = {player.Health}, enemy.Health = {enemy.Health}");
                    
                    yield break;
                }
            }
        }
    }
}