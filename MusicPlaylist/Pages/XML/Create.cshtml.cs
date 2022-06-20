using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MusicPlaylist.Pages.XML
{
    public class CreateModel : PageModel
    {
        private IWebHostEnvironment Environment;

        public CreateModel(IWebHostEnvironment _environment)
        {
            Environment = _environment;
        }

        public string Nieuwliedje;
            

        public void OnGet()
        {
        }

        public void OnPostUpload (List<IFormFile> file)
        {
            string wwwPath = this.Environment.WebRootPath;
            string path = Path.Combine(this.Environment.WebRootPath, "Upload");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            
            if (file.Count > 1)
            {
                return;
            }

            foreach (IFormFile postedFile in file)
            {
                string filename = Path.GetFileName(postedFile.FileName);
                using (FileStream stream = new FileStream(Path.Combine(path, filename), FileMode.Open, FileAccess.Read))
                {
                    postedFile.CopyTo(stream);
                }
            }
                
        }
    }
}
