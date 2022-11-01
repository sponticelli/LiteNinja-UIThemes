using UnityEngine;
using UnityEngine.UI;

namespace LiteNinja.UIThemes
{
    public abstract class  AThemedImage : ThemedComponent<Image>
    {
        [SerializeField] private Image _image;
        protected override Image Component => _image;
        
    }
}