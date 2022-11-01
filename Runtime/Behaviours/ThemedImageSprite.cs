namespace LiteNinja.UIThemes
{
    public class ThemedImageSprite : AThemedImage
    {
       
        protected override void ApplyTheme()
        {
            Component.sprite = _theme.GetSprite(_tag);
        }
    }
}