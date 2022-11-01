using TMPro;
using UnityEngine;

namespace LiteNinja.UIThemes
{
    public class ThemedTMPTextColor : ThemedComponent<TMP_Text>
    {
        [SerializeField] private TMP_Text _text;
        protected override TMP_Text Component => _text;
        protected override void ApplyTheme()
        {
            Component.color = _theme.GetColor(_tag);
        }
    }
}