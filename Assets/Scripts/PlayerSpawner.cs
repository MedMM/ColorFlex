using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerSpawner : MonoBehaviour
{
    [SerializeField]  private GameObject playerPrefab;
    [SerializeField] private Vector3 playerSpawnerPosition = new Vector3(0,50,0);
    [SerializeField] private LeanTweenType leanTweenType;
    private GameObject currentPlayer;
    private bool inGame;

    private void Start()
    {
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        if(currentPlayer != null)
            Destroy(currentPlayer, 5);
        currentPlayer = Instantiate(playerPrefab,  playerSpawnerPosition, Quaternion.identity);

        LeanTween.moveY(currentPlayer, -6, 3).setEase(leanTweenType);

        inGame = false;
    }



}
