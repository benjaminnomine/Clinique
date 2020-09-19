using Microsoft.Extensions.Localization;

namespace Clinique.Ressources
{
    public class CliniqueRessource : ICliniqueRessource
    {
        private readonly IStringLocalizer _localizer;

        public CliniqueRessource(IStringLocalizer<CliniqueRessource> localizer)
        {
            _localizer = localizer;
        }

        public string this[string index]
        {
            get
            {
                return _localizer[index];
            }
        }
    }
}
