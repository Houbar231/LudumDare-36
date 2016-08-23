using UnityEngine;
using System.Collections;

public static class Rand {
    public static T Array<T>(T[] array) {
        return array[Random.Range(0, array.Length-1)];
    }
}
