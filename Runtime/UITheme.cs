using UnityEngine;

namespace LiteNinja.UIThemes
{
    
    [CreateAssetMenu(menuName = "LiteNinja/UI/Create UI Theme", fileName = "UITheme", order = 0)]
    public class UITheme : ScriptableObject
    {

        public ColorRefTag[] colorTags;
        public ColorGroupRefTag[] colorGroupTags;
        public SpriteRefTag[] spriteTags;
        
        
    }
}