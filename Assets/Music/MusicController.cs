using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicController : MonoBehaviour
{
    [SerializeField] private Samples samplesLibrary;
    [SerializeField] private Scale scale;
    private AudioSource audioSource;
    private AudioClip[] notes;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        notes = samplesLibrary.GetNotes();
    }

    public void PlayNote(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }

    public void PlayNoteInScale(Scale scale)
    {
        PlayNote(scale.steps[Random.Range(0, scale.steps.Length)]);
    }

    public void PlayNoteInScale(Scale scale, int index)
    {
        PlayNote(scale.steps[index]);
    }

    public void PlayNote(int index)
    {
        if(index < 0) { return; }
        if (index >= notes.Length)
        {
            PlayNote(index - 12);
            return;
        }
        audioSource.PlayOneShot(notes[index]);
    }

    public void PlayRandomNote()
    {
        var currentNote = notes[Random.Range(0, notes.Length)];
        Debug.Log(currentNote.name);
        PlayNote(currentNote);
    }

    public void PlayChord(AudioClip[] audioClips)
    {
        foreach (AudioClip audioClip in audioClips)
        {
            PlayNote(audioClip);
        }
    }

    public void PlayChord(int[] notes )
    {
        foreach(int noteIndex in notes)
        {
            PlayNote(noteIndex);
        }
    }

    public void PlayMajChord(int rootNote)
    {
        PlayNote(rootNote);
        PlayNote(rootNote + 4);
        PlayNote(rootNote + 7);
    }

    public void PlayMinChord(int rootNote)
    {
        PlayNote(rootNote);
        PlayNote(rootNote + 3);
        PlayNote(rootNote + 7);
    }
}
