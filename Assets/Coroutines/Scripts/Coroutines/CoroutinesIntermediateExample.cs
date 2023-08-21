using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Coroutines
{
    public class CoroutinesIntermediateExample : MonoBehaviour
    {
        private void Start()
        {
            // TestForLoop();
            // TestForEachLoop();

            // TestForEachWithEnumerator();

            TestForEachWithEndlessList();
        }

        private void TestForLoop()
        {
            var count = 5;
            for (int i = 0; i < count; i++)
            {
                Debug.Log($"{GetType().Name}.TestForLoop: i = {i}");
            }
        }

        private void TestForEachLoop()
        {
            var integers = new[] { 10, -3, 9393, 777 };
            foreach (var integer in integers)
            {
                Debug.Log($"{GetType().Name}.TestForEachLoop: integer = {integer}");
            }

            List<int> list = new List<int>();
            list.Add(42);
            list.Add(45);
            list.Add(47);
            foreach (var listValue in list)
            {
                Debug.Log($"{GetType().Name}.TestForEachLoop: listValue = {listValue}");
            }

            var dictionary = new Dictionary<string, MonoBehaviour>();
            dictionary.Add("first", this);
            dictionary.Add("second", null);

            foreach (var dictValue in dictionary)
            {
                Debug.Log($"CoroutinesIntermediateExample.TestForEachLoop: dictValue = {dictValue.Key} {dictValue.Value}");
            }
        }

        private void TestForEachWithEnumerator()
        {
            foreach (var element in GetNumbersEnumerator())
            {
                Debug.Log($"{GetType().Name}.TestForEachWithEnumerator: element = {element}");
            }
        }

        private IEnumerable GetNumbersEnumerator()
        {
            // Делаем что-то 
            yield return 3;

            // Продолжаем делать
            yield return 5;

            // Продолжаем ещё
            yield return 7;
        }
        
        private void TestForEachWithEndlessList()
        {
            foreach (var element in GetEndlessList(5))
            {
                Debug.Log($"{GetType().Name}.TestForEachWithEndlessList: element = {element}");
            }
        }

        private IEnumerable GetEndlessList(int count)
        {
            var i = 0;
            while (i < count)
            {
                i += 1;
                yield return i;
            }
        }
    }
}