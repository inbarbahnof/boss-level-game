using System.Collections;
using System.Collections.Generic;
using Characters.Player;
using UnityEngine;

namespace Characters.Enemies
{
    public class BasicEnemy : MonoBehaviour
    {
        [SerializeField] protected float speed = 3f;
        [SerializeField] protected float minDistanceToPlayer = 5f;
        
        protected PlayerController player;
        protected bool isEnabled = true;
        
        public virtual void Init(PlayerController playerGiven)
        {
            player = playerGiven;
        }
        
        private void Update()
        {
            if (!isEnabled) return;
            TryMove();
            TryShoot();
        }
        
        public void GameOver()
        {
            isEnabled = false;
        }

        public virtual void Restart()
        {
            isEnabled = true;
        }

        public virtual void TryShoot()
        {
            
        }

        public virtual void TryMove()
        {
            
        }

        public virtual void OnDeath()
        {
            
        }
        
        public virtual void OnHit()
        {
            
        }
        
        public virtual bool IsPlayerInRange()
        {
            return Vector3.Distance(transform.position, player.transform.position) < minDistanceToPlayer;
        }
    }    
}

