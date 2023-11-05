﻿using ChooseReader.Data;

namespace ChooseReader.Service.Progress
{
    public interface ISavedProgress : ISavedProgressReader
    {
        void UpdateProgress(PlayerProgress progress);
    }

    public interface ISavedProgressReader 
    {
        void LoadProgress(PlayerProgress progress);
    }
}