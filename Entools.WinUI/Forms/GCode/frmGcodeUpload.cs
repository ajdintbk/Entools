using Google.Apis.Auth.OAuth2;
using Google.Apis.Download;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entools.WinUI.Forms.GCode
{
    public partial class frmGcodeUpload : Form
    {
        private readonly APIService _apiService = new APIService("google");

        static string[] Scopes = { DriveService.Scope.DriveReadonly };
        static string ApplicationName = "EntoolsDrive";
        private DriveService _service = new DriveService();
        public frmGcodeUpload()
        {
            InitializeComponent();
        }

        private void frmGcodeUpload_Load(object sender, EventArgs e)
        {
            UserCredential credential;

            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Drive API service.
            _service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var downloader = new MediaDownloader(_service);
            var request = _service.Files.List();
            var fileId = "";
            request.Q = "name contains 'gcode'";
            request.Key = "AIzaSyDhrK-luYMKL89L50jLvaykIFwhT0Xtzk0";
            var results = request.Execute();
            if (results.Files.Count > 0)
                fileId = results.Files[0].Id;


            var file = _service.Files.Get(fileId);
            var stream = new System.IO.MemoryStream();
            // Add a handler which will be notified on progress changes.
            // It will notify on each chunk download and when the
            // download is completed or failed.
            file.MediaDownloader.ProgressChanged +=
                (IDownloadProgress progress) =>
                {
                    switch (progress.Status)
                    {
                        case DownloadStatus.Downloading:
                            {
                                MessageBox.Show(progress.BytesDownloaded.ToString());
                                break;
                            }
                        case DownloadStatus.Completed:
                            {
                                MessageBox.Show("Download complete.");
                                break;
                            }
                        case DownloadStatus.Failed:
                            {
                                MessageBox.Show("Download failed.");
                                break;
                            }
                    }
                };
            file.Download(stream);

        }
        private void Authorize()
        {
            string[] scopes = new string[] { DriveService.Scope.Drive,
                               DriveService.Scope.DriveFile,};
            var clientId = "329707964270-crjjr3mmpps44ms2tgdfn7shnqfl2jcm.apps.googleusercontent.com";       
            var clientSecret = "QA6qRrtbXJxJTHiXncpQ1XJr";          
                                                                         // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%  
            var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets
            {
                ClientId = clientId,
                ClientSecret = clientSecret
            }, scopes,
            Environment.UserName, CancellationToken.None, new FileDataStore("MyAppsToken")).Result;
            //Once consent is recieved, your token will be stored locally on the AppData directory, so that next time you wont be prompted for consent.   

            DriveService service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "MyAppName",

            });
            service.HttpClient.Timeout = TimeSpan.FromMinutes(100);
            //Long Operations like file uploads might timeout. 100 is just precautionary value, can be set to any reasonable value depending on what you use your service for  

            // team drive root https://drive.google.com/drive/folders/0AAE83zjNwK-GUk9PVA   

            var respocne = uploadFile(service, @"C:\Users\ajdin\Desktop\try.txt", "");
            // Third parameter is empty it means it would upload to root directory, if you want to upload under a folder, pass folder's id here.
            MessageBox.Show("Process completed--- Response--" + respocne);
        }
        private static string GetMimeType(string fileName) { string mimeType = "application/unknown"; string ext = System.IO.Path.GetExtension(fileName).ToLower(); Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext); if (regKey != null && regKey.GetValue("Content Type") != null) mimeType = regKey.GetValue("Content Type").ToString(); System.Diagnostics.Debug.WriteLine(mimeType); return mimeType; }
        public Google.Apis.Drive.v3.Data.File uploadFile(DriveService _service, string _uploadFile, string _parent, string _descrp = "Uploaded with .NET!")
        {
            if (System.IO.File.Exists(_uploadFile))
            {
                Google.Apis.Drive.v3.Data.File body = new Google.Apis.Drive.v3.Data.File();
                body.Name = System.IO.Path.GetFileName(_uploadFile);
                body.Description = _descrp;
                body.MimeType= GetMimeType(_uploadFile);
                // body.Parents = new List<string> { _parent };// UN comment if you want to upload to a folder(ID of parent folder need to be send as paramter in above method)
                byte[] byteArray = System.IO.File.ReadAllBytes(_uploadFile);
                System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);
                try
                {
                    FilesResource.CreateMediaUpload request = _service.Files.Create(body, stream, GetMimeType(_uploadFile));
                    request.SupportsTeamDrives = true;
                    // You can bind event handler with progress changed event and response recieved(completed event)
                    request.Upload();
                    return request.ResponseBody;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Error Occured");
                    return null;
                }
            }
            else
            {
                MessageBox.Show("The file does not exist.", "404");
                return null;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            Authorize();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StringBuilder newFile = new StringBuilder();
            string temp = "";
            string[] file = File.ReadAllLines(@"C:\Users\ajdin\Desktop\try.txt");

            foreach (string line in file)
            {
                if (line.Contains("N124 M06 T1 ()"))
                {
                    temp = line.Replace("N124 M06 T1 ()", "N124 M06 TMOJ ()");
                    newFile.Append(temp + "\r\n");
                    continue;
                }
                newFile.Append(line + "\r\n");
            }

            File.WriteAllText(@"C:\Users\ajdin\Desktop\try.txt", newFile.ToString());
        }
    }
}
