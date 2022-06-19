using System.Data;
using Newtonsoft.Json;

namespace MusicPlaylist.Code.XML
{
    public class SongMethods
    {

        public SongMethods()
        {
            try
            {
                string jsonString = File.ReadAllText(filename);
                songslist = JsonConvert.DeserializeObject<List<Song>>(jsonString);
            }
            catch (Exception ex)
            {

            }
        }
       
        private List<Song> songslist = null; 
        private string filename = Environment.CurrentDirectory + "\\Data\\SongMethods.json";
        

        public List<Song> GetAllSongs()
        {
            return songslist;
        }

        public Song GetSong(string id)
        {
            int nId = int.Parse(id);
            return songslist.FirstOrDefault(s => s.id == id);
        }

        public void AddSong(Song s)
        {
            songslist.Add(s);
            WriteDataToFile();
        }

        public void SaveSong(Song s)
        {
            WriteDataToFile();
        }

        public void DeleteSong(string id)
        {
            songslist.Remove(GetSong(id));
            WriteDataToFile();
        }

        public void WriteDataToFile()
        {
            string json = JsonConvert.SerializeObject(songslist);
            File.WriteAllText(filename, json);
        }

    }
    
}
