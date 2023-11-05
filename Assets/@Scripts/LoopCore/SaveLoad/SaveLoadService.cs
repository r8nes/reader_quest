using ChooseReader.Data;
using ChooseReader.Service.Progress;
using UnityEngine;

namespace ChooseReader.Structure
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string PROGRESS_KEY = "Progress";

        private readonly IProgressService _progress;

        public SaveLoadService(IProgressService progress)
        {
            _progress = progress;
        }

        public void SaveProgress()
        {            
            PlayerPrefs.SetString(PROGRESS_KEY, _progress.Progress.ToJson());
        }

        public PlayerProgress LoadProgress() => PlayerPrefs.GetString(PROGRESS_KEY)?
                .ToDeserialized<PlayerProgress>();

        public void PrintPlayerPrefs() 
        {
            Debug.Log(PlayerPrefs.HasKey(PROGRESS_KEY));
        }
    }
}
 