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

            SongLoader.Loader = new StreamLoader(this);
            var data = await SongLoader.Load();
            var songs = data.ToList();

            ListAdapter = new ListAdapter<Song>()
            {
                DataSource = songs,
                TextProc = s => s.Name,
                DetailTextProc = s => $"{s.Artist} - {s.Album}"
            };
        }
    }
}