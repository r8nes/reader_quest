using System.Collections;
using System.Collections.Generic;
using ChooseReader.Data;
using UnityEngine;

namespace ChooseReader.Service.Progress
{
    public class ProgressService : IProgressService
    {
        public PlayerProgress Progress { get; set; }
    }
}
