using System.Data; 

namespace MusicPlaylist.Code.XML
{
    public class SongMethods
    {
        DataSet ds = new DataSet("Playlist");
        public SongMethods()
        {
            try
            {
                string jsonString = File.ReadAllText(filename);
                songslist = JsonConvert.DeserializeObject<list<Song>>(jsonString);
            }
            catch (Exception ex)
            {

            }
        }
       
        private list<Song> songslist = null; 
        private string filename = Environment.CurrentDirectory + "\\Data\\SongMethods.json";
        

        public List<songs> GetAllSongs(string file)
        {
            DataTable dtSongs = new DataTable("song");

            DataColumn dcId = new DataColumn("id");
            DataColumn dcArtist = new DataColumn("artist");
            DataColumn dcTitle = new DataColumn("title");
            DataColumn dcYear = new DataColumn("year");
            DataColumn dcGenre = new DataColumn("genre");
            DataColumn dcTime = new DataColumn("time");

            dtSongs.Columns.Add(dcId);
            dtSongs.Columns.Add(dcArtist);
            dtSongs.Columns.Add(dcTitle);
            dtSongs.Columns.Add(dcYear);
            dtSongs.Columns.Add(dcGenre);
            dtSongs.Columns.Add(dcTime);

            ds.Tables.Add(dtSongs);

            try
            {
                ds.ReadXml(Environment.CurrentDirectory + file);
            }
            catch (Exception ex)
            {

            }

            List<Song> songList = new List<Song>();
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                Song X = new Song();

                songList.Add(x);
            }
            return ds;
        }
        
        public DataRow GetEmptyDataRow()
        {
            DataRow dr = ds.Tables["song"].NewRow();
            return dr;
        }

        public void CreateSong(DataRow dr, string file)
        {
            ds.Tables["song"].Rows.Add(dr);
            ds.WriteXml(Environment.CurrentDirectory + file);   
        }

        public void DeleteSong(string id, string file)
        {
            DataRow[] drSongs = ds.Tables["song"].Select("id = '" + id + "'");
            if (drSongs != null && drSongs.Length > 0)
            {
                drSongs[0].Delete();
                ds.WriteXml(Environment.CurrentDirectory + file);
            }
        }

        public void EditSong(string id, DataRow editedRow, string file)
        {
            DataRow[] drSongs = ds.Tables["song"].Select("id = '" + id + "'");
            if (drSongs != null && drSongs.Length > 0)
            {
                drSongs[0]["id"] = editedRow["id"];
                drSongs[0]["artist"] = editedRow["artist"];
                drSongs[0]["title"] = editedRow["title"];
                drSongs[0]["year"] = editedRow["year"];
                drSongs[0]["genre"] = editedRow["genre"];
                drSongs[0]["time"] = editedRow["time"];

                ds.WriteXml(Environment.CurrentDirectory + file);
            }
        }
        public void save()
        {
            string json = jsonConvert.SerializeObject(Songs);
            File.WriteAllText(filename, json);
        }
    }
    
}
