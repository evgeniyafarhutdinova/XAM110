using Android.App;
using Android.OS;
using System.Linq;

namespace MyTunes
{
    [Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : ListActivity
    {
        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            /*ListAdapter = new ListAdapter<string>()
            {
                DataSource = new[] { "One", "Two", "Three" }
            };*/
            var songs = await SongLoader.Load();
            var songsList = songs.ToList();

            ListAdapter = new ListAdapter<Song>()
            {
                DataSource = songsList,
                TextProc = s => s.Name,
                DetailTextProc = s => $"{s.Artist} - {s.Album}"
            };
        }
    }
}
