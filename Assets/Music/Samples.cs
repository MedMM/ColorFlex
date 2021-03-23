using UnityEngine;

[CreateAssetMenu(menuName = "New Samples Library")]
public class Samples : ScriptableObject
{
    [SerializeField] private string samplesName;
    [SerializeField] private AudioClip[] notes;

    public AudioClip[] GetNotes()
    {
        return notes;
    }
}
