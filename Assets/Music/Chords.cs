using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Create Chords Library")]
public class Chords : ScriptableObject
{
    [SerializeField] Chord[] chords;

    [Serializable] struct Chord
    {
        public string name;
        [Space]
        public int[] steps;
    }


    Chord[] GetChords()
    {
        return chords;
    }
}
