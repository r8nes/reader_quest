namespace ChooseReader.Data
{
    [System.Serializable]
    public class PlayerProgress
    {
        public PlayerData Data;

        public PlayerProgress()
        {
            Data = new PlayerData();
        }
    }

    [System.Serializable]
    public class PlayerData
    {
        // HASH UNIQE ID
        public string Name = "Noname"; 

        public int Books;
        public int Chapters;
        
        public int Gold;
        public int Fame;
        
        public bool IsPremium;
    }
}