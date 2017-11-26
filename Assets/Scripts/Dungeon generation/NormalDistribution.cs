using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Normal distribution.
/// The Gaussian function giving the min, max and standard deviation it returns an int
/// which is favored in a bell shape. 
/// Found at: https://stackoverflow.com/questions/218060/random-gaussian-variables
/// </summary>
/// 
public class NormalDistribution : MonoBehaviour
{
    [SerializeField, Tooltip("The mean used in the distribution")] float mean = 5;
    [SerializeField, Tooltip("The standard deviation in the distribution")] float stdDev = 2;

    public int Gaussian()
    {
        float u1 = 1.0f - Random.Range(0.0f, 1.0f);
        float u2 = 1.0f - Random.Range(0.0f, 1.0f);
        float randStdNormal = Mathf.Sqrt(-2.0f * Mathf.Log(u1)) * Mathf.Sin(2.0f * Mathf.PI * u2);
        float randNormal = mean + stdDev * randStdNormal;
        return Mathf.Max(Mathf.RoundToInt(randNormal), 2);
    }
}
