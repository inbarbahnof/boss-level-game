using System;
using System.Collections;
using System.Collections.Generic;
using Characters;
using Characters.General;
using UnityEngine;

namespace Characters.Enemies
{
    public class PoisonProjectile : Projectile
    {
        private void Update()
        {
            MoveToPlayer();
        }

        private void MoveToPlayer()
        {
            var playerPos = projectileTarget.transform.position;
            var direction = (playerPos - transform.position).normalized;
            transform.Translate(direction * (speed * Time.deltaTime));
        }

        protected override void HandleHit()
        {
            projectileTarget.TakeDamage(damage);
            
            StopCoroutine(Die());
            Destroy(gameObject);
        }
    }
}