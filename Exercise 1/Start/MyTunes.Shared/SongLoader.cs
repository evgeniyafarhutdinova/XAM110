﻿using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;
using MyTunes.Shared;
using System;

namespace MyTunes
{
    public static class SongLoader
    {
        const string Filename = "songs.json";

        public static IStreamLoader Loader;

        public static async Task<IEnumerable<Song>> Load()
        {
            using (var reader = new StreamReader(OpenData()))
            {
                return JsonConvert.DeserializeObject<List<Song>>(await reader.ReadToEndAsync());
            }
        }

        private static Stream OpenData()
        {
            if (Loader == null)
            {
                throw new ArgumentNullException(nameof(Loader));
            }
            return Loader.GetStreamForFilename(Filename);
        }
    }
}

