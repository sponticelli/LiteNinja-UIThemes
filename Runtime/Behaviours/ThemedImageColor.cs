namespace LiteNinja.UIThemes
{
    


    public class ThemedImageColor : AThemedImage 
    {
        
        protected override void ApplyTheme()
        {
            Component.color = _theme.GetColor(_tag);
        }
    }
}