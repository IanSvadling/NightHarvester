using UnityEngine;

public class PuzzleMaker : MonoBehaviour
{
    public static PuzzleType Create(PuzzleType type)
    {
        return type switch
        {
            PuzzleType.PUZZLE1 => OpenPuzzleOne(type),
            PuzzleType.PUZZLE2 => OpenPuzzleTwo(type),
            PuzzleType.PUZZLE3 => OpenPuzzleThree(type),
            PuzzleType.PUZZLE4 => OpenPuzzleFour(type),
            PuzzleType.PUZZLE5 => OpenPuzzleFive(type),
            PuzzleType.PUZZLE6 => OpenPuzzleSix(type)
        };
           
    }

    private static PuzzleType OpenPuzzleOne(PuzzleType type) 
    {
        return type;
    }

    private static PuzzleType OpenPuzzleTwo(PuzzleType type) 
    {
        return type;
    }

    private static PuzzleType OpenPuzzleThree(PuzzleType type) 
    {
        return type;
    }

    private static PuzzleType OpenPuzzleFour(PuzzleType type) 
    {
        return type;
    }

    private static PuzzleType OpenPuzzleFive(PuzzleType type) 
    {
        return type;
    }

    private static PuzzleType OpenPuzzleSix(PuzzleType type) 
    {
        return type;
    }


}
