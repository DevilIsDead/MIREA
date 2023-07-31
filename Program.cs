using System;
using System.Configuration;
using System.IO.Compression;
using System.IO;
using System.Net.FtpClient;
using System.Net;

class Program {

    static void Main() {

        string startPath;
        var Path = ConfigurationManager.AppSettings["path"];
        if (Path != null) {
            startPath = (Path).ToString();
            string Result = "zip_PC_" + ConfigurationManager.AppSettings["pcNum"];
            if (File.Exists(Result)) {
                File.Delete(Result);
            }
            ZipFile.CreateFromDirectory(startPath, Result);

            if (ftpUrl != null && ftpLogin != null && ftpPassword != null) {
                using (FtpClient client = new FtpClient()) {
                        client.Host = ConfigurationManager.AppSettings["ftpUrl"];
                        client.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["ftpLogin"], ConfigurationManager.AppSettings["ftpPassword"]);

                        using (Stream ostream = client.OpenWrite(Result)) {
                            try {
                                // istream.Position is incremented accordingly to the writes you perform
                            }
                            finally {
                                ostream.Close();
                            }
                        }
                }
            } else {
                Console.WriteLine("Wrong FTP information!");
            }
        } else {
            Console.WriteLine("Wrong directory!");
        }
        Console.WriteLine("Press any key to continue.................");
        Console.ReadKey();
    }
}
