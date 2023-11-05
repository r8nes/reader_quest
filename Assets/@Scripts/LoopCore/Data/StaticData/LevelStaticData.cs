using UnityEngine;

namespace ChooseReader.Data.Static
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "StaticData/Level")]
    public class LevelStaticData : ScriptableObject
    {
        public string BookKey;
        public int ChapterCounter;
    }
}