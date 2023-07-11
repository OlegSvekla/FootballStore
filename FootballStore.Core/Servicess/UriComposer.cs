using FootballStore.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStore.Core.Servicess
{
    public sealed class UriComposer : IUriComposer
    {
        private readonly CatalogSettings _catalogSettings;

        public UriComposer(CatalogSettings catalogSettings)
        {
            _catalogSettings = catalogSettings;
        }

        public string ComposeImageUri(string uriTemplate)
        {
            return uriTemplate.Replace("", _catalogSettings.CatalogBaseUrl);
        }
    }
}