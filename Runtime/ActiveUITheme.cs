using System.Collections.Generic;
using LiteNinja.SOA.Events;
using UnityEngine;

namespace LiteNinja.UIThemes
{
    [CreateAssetMenu(menuName = "LiteNinja/UI/Create Active UI Theme", fileName = "ActiveUITheme", order = 0)]
    public class ActiveUITheme : UITheme
    {
#if UNITY_EDITOR
        [SerializeField] [TextArea] private string _description;
#endif
        
        [SerializeField] private GameEvent onThemeChanged;
        
        [SerializeField] private Color _defaultColor;
        [SerializeField] private Sprite _defaultSprite;
        
  
        private Dictionary<string, Color> _colorCache;
        private Dictionary<string, Sprite> _spriteCache;
        private Dictionary<string, Color[]> _colorGroupCache;

        public GameEvent OnThemeChanged => onThemeChanged;
        
        public void SetTheme(UITheme theme)
        {
            if (theme == null) return;
            colorTags = theme.colorTags;
            spriteTags = theme.spriteTags;
            colorGroupTags = theme.colorGroupTags;
            CreateCache();
            onThemeChanged?.Raise();
        }

        private void CreateCache()
        {
            _colorCache = new Dictionary<string, Color>();
            _spriteCache = new Dictionary<string, Sprite>();
            _colorGroupCache = new Dictionary<string, Color[]>();
            foreach (var colorTag in colorTags)
            {
                _colorCache.Add(colorTag.tagName, colorTag.tagColor);
            }
            
            foreach (var spriteTag in spriteTags)
            {
                _spriteCache.Add(spriteTag.tagName, spriteTag.tagSprite);
            }
            
            foreach (var colorGroupTag in colorGroupTags)
            {
                _colorGroupCache.Add(colorGroupTag.tagName, colorGroupTag.tagColors);
            }
        }
        
        private void CreateCacheIfNull()
        {
            if (_colorCache == null || _spriteCache == null)
            {
                CreateCache();
            }
        }

        public Color GetColor(string tag)
        {
            CreateCacheIfNull();
            return _colorCache.ContainsKey(tag) ? _colorCache[tag] : _defaultColor;
        }

        public Sprite GetSprite(string tag)
        {
            CreateCacheIfNull();
            return _spriteCache.ContainsKey(tag) ? _spriteCache[tag] : _defaultSprite;
        }

        public Color[] GetColorGroup(string tag)
        {
            CreateCacheIfNull();
            return _colorGroupCache.ContainsKey(tag) ? _colorGroupCache[tag] : new []{ _defaultColor };
        }
        
    }
}