using System.Collections;
using UnityEngine;

namespace ChooseReader.Structure
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}

