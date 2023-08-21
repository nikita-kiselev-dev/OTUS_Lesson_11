using System.Collections;
using UnityEngine;

namespace Coroutines
{
    public class CoroutinesBasicExample : MonoBehaviour
    {
        private bool _isPaused;

        private void Start()
        {
            _isPaused = true;

            // StartCoroutine(SimpleCoroutine());
            StartCoroutine(CoroutineWithCondition());
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Debug.Log($"{GetType().Name}.Update: unpaused");

                _isPaused = false;
            }
        }

        private IEnumerator SimpleCoroutine()
        {
            Debug.Log($"{GetType().Name}.SimpleCoroutine: Time.time = {Time.time}");

            yield return new WaitForSeconds(1f);

            Debug.Log($"{GetType().Name}.SimpleCoroutine: Time.time = {Time.time}");
        }

        private IEnumerator CoroutineWithCondition()
        {
            Debug.Log($"{GetType().Name}.CoroutineWithCondition: Time.time = {Time.time}");

            while (_isPaused)
            {
                yield return new WaitForSeconds(5f);
            }

            Debug.Log($"{GetType().Name}.CoroutineWithCondition: Time.time = {Time.time}");
        }
    }
}