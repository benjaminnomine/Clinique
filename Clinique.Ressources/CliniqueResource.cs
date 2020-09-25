using Microsoft.Extensions.Localization;

namespace Clinique.Ressources
{
    public class CliniqueResource : ICliniqueResource
    {
        private readonly IStringLocalizer _localizer;

        public CliniqueResource(IStringLocalizer<CliniqueResource> localizer)
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
