using Microsoft.Extensions.FileProviders;

namespace Bib.Api
{
    public class AssetFileProvider : PhysicalFileProvider, IAssetFileProvider
    {
        public AssetFileProvider(string root) : base(root)
        {
        }
    }
}