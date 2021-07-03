using Entools.Model.Requests.Request;
using Entools.Model.ViewModels;
using Google.Apis.Auth.OAuth2;
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

namespace Entools.WinUI.Forms.Request
{
    public partial class frmRequestDetails : Form
    {
        private List<Model.VersionRequest> versionRequests;
        private Model.Request _request;

        private readonly APIService _apiService = new APIService("google");
        private readonly APIService _apiServiceRequest = new APIService("Request");

        static string[] Scopes = { DriveService.Scope.DriveReadonly };
        static string ApplicationName = "EntoolsDrive";
        private DriveService _service = new DriveService();

        private readonly APIService _apiVersionRequest = new APIService("VersionRequest");
        private readonly APIService _apiRequest = new APIService("Request");
        private int requestId = 0;

        public frmRequestDetails()
        {
            InitializeComponent();
        }
        public frmRequestDetails(int id):this()
        {
            requestId = id;
        }

        private async void frmRequestDetails_Load(object sender, EventArgs e)
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


            versionRequests = await _apiVersionRequest.Get<List<Model.VersionRequest>>(requestId);
            _request = await _apiRequest.GetById<Model.Request>(requestId);
            if (_request.IsOpened)
            {
                gbActions.Visible = false;
                lblInfo.Visible = true;
                if (_request.IsApproved)
                {
                    lblStatus.Text = "Odobren";
                    lblStatus.ForeColor = Color.Green;
                }
                else
                {
                    lblStatus.Text = "Odbijen";
                    lblStatus.ForeColor = Color.Red;
                }
            }
            else
            {
                gbActions.Visible = true;
                lblInfo.Visible = false;
            }
            List<VersionRequestVM> listvm = new List<VersionRequestVM>();
            foreach (var item in versionRequests)
            {
                VersionRequestVM vmitem = new VersionRequestVM()
                {
                    Alat = item.Tool.Name,
                    Id = item.Id,
                    Masina = item.Machine.Name,
                    Operacija = item.Operation.Name
                };
                listvm.Add(vmitem);
            }

            dataGridView1.DataSource = listvm;
            dataGridView1.Columns["Id"].Visible = false;
            lblZahtjevId.Text = lblZahtjevId.Text + " #" + _request.Id;
            lblKomad.Text = lblKomad.Text + " " + _request.Part.Name;
            lblKreirao.Text = lblKreirao.Text + " " + _request.CreatedBy;
            lblDatum.Text = lblDatum.Text + " " + _request.DateCreated;


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

        private void btnOdobri_Click(object sender, EventArgs e)
        {
            StringBuilder newFile = new StringBuilder();
            string temp;
            bool flag = true;
            //string[] file = File.ReadAllLines("./Files/defaultGcode.txt"); //for production
            string[] file = File.ReadAllLines("../../../../Files/defaultGcode.txt");

            foreach (string line in file)
            {
                foreach (var operation in versionRequests)
                {
                    if (line.Contains(operation.Operation.GCodeLocation))
                    {
                        temp = line.Replace(line, operation.Operation.GCodeLocation + " " + operation.Machine.Label + " " + operation.Tool.Label + " ()");
                        newFile.Append(temp + "\r\n");
                        flag = false;
                        break;
                    }
                    else flag = true;
                }
                if(flag)
                    newFile.Append(line + "\r\n");
            }

            File.WriteAllText(Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory) + @"\"+"request" +_request.Id+".txt", newFile.ToString());
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(300);
                this.Invoke(new Action(() => Authorize()));
            });
            

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

            var respocne = uploadFile(service, Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory) + @"\request" + _request.Id + ".txt", "");
            // Third parameter is empty it means it would upload to root directory, if you want to upload under a folder, pass folder's id here.
            var request = _service.Files.List();
            var fileId = "";
            var combineString = "request" + _request.Id;
            var searchString = "'" + combineString + "'";
            request.Q = $"name contains " + searchString;
            request.Key = "AIzaSyDhrK-luYMKL89L50jLvaykIFwhT0Xtzk0";
            var results = request.Execute();
            if (results.Files.Count > 0)
            {
                fileId = results.Files[0].Id;
            }
            try
            {
                var updateRequest = new RequestInsertUpdateRequest()
                {
                    CreatedBy = _request.CreatedBy,
                    DateCreated = _request.DateCreated,
                    GCodeUrl = "https://drive.google.com/uc?export=download&id=" + fileId,
                    IsApproved = true,
                    IsOpened = true,
                    PartId = _request.PartId,
                    VersionId = _request.VersionId
                };
                var updateResult = _apiServiceRequest.Update<Model.Request>(_request.Id, updateRequest);
                MessageBox.Show("Uspjesno spašeno na Google Drive", "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Greska");
            }
        }
        private static string GetMimeType(string fileName) { string mimeType = "application/unknown"; string ext = System.IO.Path.GetExtension(fileName).ToLower(); Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext); if (regKey != null && regKey.GetValue("Content Type") != null) mimeType = regKey.GetValue("Content Type").ToString(); System.Diagnostics.Debug.WriteLine(mimeType); return mimeType; }
        public Google.Apis.Drive.v3.Data.File uploadFile(DriveService _service, string _uploadFile, string _parent, string _descrp = "Uploaded with .NET!")
        {
            if (System.IO.File.Exists(_uploadFile))
            {
                Google.Apis.Drive.v3.Data.File body = new Google.Apis.Drive.v3.Data.File();
                body.Name = System.IO.Path.GetFileName(_uploadFile);
                body.Description = _descrp;
                body.MimeType = GetMimeType(_uploadFile);
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
    }
}
