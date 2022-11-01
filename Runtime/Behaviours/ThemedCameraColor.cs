using UnityEngine;

namespace LiteNinja.UIThemes
{
    public class ThemedCameraColor : ThemedComponent<Camera>
    {
        [SerializeField] private Camera _camera;

        protected override Camera Component => _camera;

        protected override void ApplyTheme()
        {
            Component.backgroundColor = _theme.GetColor(_tag);
        }
    }
}