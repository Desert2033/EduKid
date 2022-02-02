using System.Collections.Generic;
using UnityEngine;

public class RandomWithOutRepeat
{

    private List<int> randomNumbers = new List<int>();

    public int GetRandom(int min, int max)
    {
        int randomNumber;
        do
        {
            randomNumber = Random.Range(min, max);
        }
        while (randomNumbers.Contains(randomNumber));

        randomNumbers.Add(randomNumber);

        return randomNumber;

    }
}
