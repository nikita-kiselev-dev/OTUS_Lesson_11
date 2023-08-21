using System;
using System.Collections;
using UnityEngine;

namespace Game.Scripts
{
    public class Character : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;

        [SerializeField] private Transform[] _patrolPoints;
        
        public int Health;

        private bool _isNeedToGo = false;
        private bool _distanceReached = false;

        private Transform _currentPatrolPoint;
        private int _patrolPointIterator = 0;
        

        public IEnumerator Attack(Character attackedCharacter)
        {
            Debug.Log($"{GetType().Name}.Attack: gameObject.name = {gameObject.name} => {attackedCharacter.gameObject.name}");

            _animator.SetTrigger("Shoot");

            yield return new WaitForSeconds(2f);
            
            attackedCharacter.Health -= 1;

            if (attackedCharacter.Health <= 0)
            {
                attackedCharacter.Die();
                if (_patrolPoints.Length > 0)
                {
                    _currentPatrolPoint = _patrolPoints[0];
                    _isNeedToGo = true;
                }

            }
        }

        private void Die()
        {
            _animator.SetTrigger("Death");
            Debug.Log($"{GetType().Name}.Die: name = {name}");
        }
        

        private IEnumerator Patrol()
        {
            yield return new WaitForSeconds(3.0f);
            ChooseNewPatrolPoint();
            _isNeedToGo = true;
        }

        private void ChooseNewPatrolPoint()
        {
            if (_patrolPointIterator + 1 < _patrolPoints.Length)
            {
                _currentPatrolPoint = _patrolPoints[_patrolPointIterator + 1];
                _patrolPointIterator++;
            }
            else
            {
                _patrolPointIterator = 0;
                _currentPatrolPoint = _patrolPoints[0];
            }
        }

        private void Update()
        {
            if (_isNeedToGo && _patrolPoints.Length > 0)
            {
                _distanceReached = Vector3.Distance(transform.position, _currentPatrolPoint.position) < .001f;

                if (!_distanceReached)
                {
                    Movement();
                }
                else
                {
                    _animator.SetBool("Walking", false);
                    _isNeedToGo = false;
                    StartCoroutine(Patrol());
                }
            }
        }

        private void Movement()
        {
            _animator.SetBool("Walking", true);
            
            transform.position = Vector3.MoveTowards(transform.position, _currentPatrolPoint.position,
                Time.deltaTime * 2.0f);

            var targetRotation = Quaternion.LookRotation(_currentPatrolPoint.position - transform.position, Vector3.up);
            var nextRotation = Quaternion.Slerp(this.transform.rotation, targetRotation, 5.0f * Time.deltaTime);
            transform.rotation = nextRotation;
        }
    }
}