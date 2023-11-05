using UnityEngine;

namespace ChooseReader.Service.Randomizer
{
    public class RandomService : IRandomService
    {
        public int Next(int min, int max) =>
          Random.Range(min, max);
    }
}