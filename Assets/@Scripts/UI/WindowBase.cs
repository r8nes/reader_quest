using System;
using ChooseReader.Data;
using ChooseReader.Service.Progress;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ChooseReader.UI
{
    public abstract class WindowBase : MonoBehaviour
    {
        public Button CloseButton;

        protected IProgressService _progressService;
        protected PlayerProgress Progress => _progressService.Progress;

        public void Construct(IProgressService progressService) => _progressService = progressService;

        private void Awake() => OnAwake();
        
        private void Start()
        {
            Initialize();
            SubScribeUpdates();
        }

        protected virtual void OnAwake() => CloseButton.onClick.AddListener(() => Destroy(gameObject));
        protected virtual void Initialize() {}
        protected virtual void SubScribeUpdates() {}
        protected virtual void CleanUp() {}
        
        private void OnDestroy() => CleanUp();
    }
}
