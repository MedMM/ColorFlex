using UnityEngine;

public class MusicHarmony : MonoBehaviour
{
    [SerializeField] MusicController musicController;
    [SerializeField] private int mainKey = 3; //Main tonality relatively circleOfFifths
    [SerializeField] private int[] chordsProgression;
    private int[] circleOfFifths = new int[] { 2, 5, 9, 0, 4, 7, 11, 2, 6, 9, 0, 4, 8, 11, 3, 6, 10, 1, 4, 8, 0, 3, 7, 10 };
    private int index = 0;

    void Start()
    {
        GenerateChordsProgression();
    }

    public void Shoot()
    { 
        if (index % 2 == 0)
        {
            musicController.PlayMajChord(circleOfFifths[index]);
        }
        else
        {
            musicController.PlayMajChord(circleOfFifths[index]);
        }

        index++;
        if (index >= circleOfFifths.Length)
        {
            index = 0;
        }
    }

    public void GenerateChordsProgression()
    {

    }
}
