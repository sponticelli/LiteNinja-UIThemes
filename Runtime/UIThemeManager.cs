using UnityEngine;



namespace LiteNinja.UIThemes
{
    [CreateAssetMenu(menuName = "LiteNinja/UI/Create Theme Manager", fileName = "UIThemeManager", order = 0)]
    public class UIThemeManager : ScriptableObject, ISerializationCallbackReceiver
    {
        [SerializeField] private UITheme[] themes;
        [SerializeField] private UITheme currentTheme;
        [SerializeField] private ActiveUITheme activeTheme;
        
        public UITheme CurrentTheme => currentTheme;
        
        public void SetTheme(UITheme theme)
        {
            currentTheme = theme;
            activeTheme.SetTheme(theme);
        }
        
        
        
        
        public void SetTheme(string themeName)
        {
            foreach (var theme in themes)
            {
                if (theme.name != themeName) continue;
                SetTheme(theme);
                return;
            }
        }
        
        public void SetTheme(int themeIndex)
        {
            SetTheme(themes[themeIndex]);
        }


        private void OnValidate()
        {
            SetActiveTheme();
        }

        private void SetActiveTheme()
        {
            if (themes.Length == 0)
            {
                return;
            }

            if (currentTheme == null)
            {
                SetTheme(0);
            }
            else
            {
                SetTheme(currentTheme);
            }


        }

        public void OnBeforeSerialize()
        {
     
        }

        public void OnAfterDeserialize()
        {
            SetActiveTheme();
        }
    }
}