using System;
using System.Collections;
using UnityEngine;

namespace Coroutines
{
    public class CoroutinesAdvancedExample : MonoBehaviour
    {
        private IEnumerator availableCoroutines;

        private Coroutine coroutine;

        private void Start()
        {
            // TestCustomCoroutine();

            // TestCoroutines();

            // TestCoroutineByName();

            TestStopCoroutine();
        }


        private void TestCustomCoroutine()
        {
            StartCoroutine(new CustomEnumerator());
        }

        private void TestCoroutines()
        {
            availableCoroutines = AvailableCoroutines();

            coroutine = StartCoroutine(availableCoroutines);
        }

        private IEnumerator AvailableCoroutines()
        {
            yield return null;

            yield return new WaitForSeconds(1f);

            yield return new WaitForSecondsRealtime(1f);

            yield return new WaitForFixedUpdate();
            yield return new WaitForEndOfFrame();

            yield return new WaitUntil(() => true);

            // ...

            yield return new WaitWhile(() => false);

            // ...

            yield break;
        }


        private void TestCoroutineByName()
        {
            StartCoroutine(nameof(MyStringCoroutine));
        }

        private IEnumerator MyStringCoroutine()
        {
            yield return null;
        }

        private void TestStopCoroutine()
        {
            // StopCoroutine(nameof(MyStringCoroutine));

            // StopCoroutine(availableCoroutines);

            StopCoroutine(coroutine);

            // When GameObject is destroyed
        }
    }

    internal class CustomEnumerator : IEnumerator
    {
        private int _i = 1;

        public object Current => _i;

        public bool MoveNext()
        {
            Debug.Log($"{GetType().Name}.MoveNext: _i = {_i} {Time.time}");

            _i += 1;

            return _i < 5;
        }

        public void Reset()
        {
        }
    }
}