using UnityEngine;

public class Puzzle : MonoBehaviour
{
    [SerializeField] PuzzleType puzzleType;

    /**
     * needs to be triggered when player presses E on a crop sign
     */
    private void Start()
    {
        PuzzleMaker.Create(puzzleType);
    }
}
