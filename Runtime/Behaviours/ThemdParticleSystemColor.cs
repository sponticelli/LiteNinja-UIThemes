using UnityEngine;

namespace LiteNinja.UIThemes
{
    /// <summary>
    /// Todo Add support for other colors in particle 
    /// </summary>
    public class ThemdParticleSystemColor : ThemedComponent<ParticleSystem>
    {
        [SerializeField] private ParticleSystem _particleSystem;
        protected override ParticleSystem Component => _particleSystem;
        

        protected override void ApplyTheme()
        {
            var componentMain = Component.main;
            componentMain.startColor = _theme.GetColor(_tag);
        }
    }
}