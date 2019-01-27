using System.IO;
using Android.Content;

namespace MyTunes
{
    public class StreamLoader : IStreamLoader
    {
        private readonly Context _context;

        public StreamLoader(Context context)
        {
            _context = context;
        }

        public Stream GetStreamForFilename(string fileName)
        {
            return _context.Assets.Open(fileName);
        }
    }
}