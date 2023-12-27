using System.Collections;
using UnityEngine;

namespace _1_Scripts.Logic
{
    public interface ICoroutineRunner
    {
        public Coroutine StartCoroutine(IEnumerator coroutine);
        public void StopCoroutine(Coroutine coroutine);
        public void StopAllCoroutines();
    }
}