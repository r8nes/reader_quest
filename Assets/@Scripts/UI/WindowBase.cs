using System;
using ChooseReader.Data;
using ChooseReader.Service.Progress;
using ChooseReader.UI.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ChooseReader.UI
{
    public abstract class WindowBase : MonoBehaviour
    {
        public Button CloseButton;

        protected WindowId _windowId;
        protected IProgressService _progressService;

        protected PlayerProgress Progress => _progressService.Progress;
        public event Action<WindowId> WindowClosed;

        public void Construct(WindowId Id, IProgressService progressService)
        {
            _windowId = Id;
            _progressService = progressService;
        }

        private void Awake() => OnAwake();
        private void Start()
        {
            Initialize();
            SubScribeUpdates();
        }
        private void OnDestroy() => CleanUp();

        public WindowId GetId() => _windowId;

        protected virtual void OnAwake() => CloseButton.onClick.AddListener(() => Destroy(gameObject));
        protected virtual void Initialize() {}
        protected virtual void SubScribeUpdates() {}
        protected virtual void CleanUp() => WindowClosed?.Invoke(_windowId);
    }
}
