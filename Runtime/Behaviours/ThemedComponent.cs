using LiteNinja.SOA.Events;
using UnityEngine;
using UnityEngine.Events;

namespace LiteNinja.UIThemes
{
    public abstract class ThemedComponent<T> : GameEventListener where T : Component
    {
        [SerializeField] protected ActiveUITheme _theme;
        [SerializeField] protected string _tag;
        [SerializeField] protected GameEvent _onThemeChange;

        protected abstract T Component { get; }

        private EventResponse _response;
        
        protected override void Awake()
        {
            var unityEvent = new UnityEvent();
            unityEvent.AddListener(OnThemeChanged);
            _response = new EventResponse
            {
                ScriptableEvent = _onThemeChange,
                Response = unityEvent
            };

            AddEventResponse(_response);
            base.Awake();
        }
        
        protected override void OnEnable()
        {
            base.OnEnable();
            ApplyTheme();
        }

        protected void OnThemeChanged()
        {
            ApplyTheme();
        }

        protected abstract void ApplyTheme();

        protected void OnValidate()
        {
            ApplyTheme();
            _onThemeChange = _theme.OnThemeChanged;
        }
    }
}