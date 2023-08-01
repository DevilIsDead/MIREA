using System;
using System.IO;
using System.Configuration;
using System.IO.Compression;
using FluentFTP;

<<<<<<< HEAD
class Program
{
    static void Main()
    {
        var src = ConfigurationManager.AppSettings["src"];
        if (src != null)
        {
            string zipName = "zip_PC_" + ConfigurationManager.AppSettings["pcNum"] + ".zip";
            if (File.Exists(zipName))
            {
                File.Delete(zipName);
=======
class Program {

    static void Main() {

        string startPath;
        var Path = ConfigurationManager.AppSettings["path"];
        if (Path != null) {
            startPath = (Path).ToString();
            string Result = "zip_PC_" + ConfigurationManager.AppSettings["pcNum"];
            if (File.Exists(Result)) {
                File.Delete(Result);
>>>>>>> 75cac3ad30aaa15dbfbde9c43aeb6a0349f2a9ab
            }
            ZipFile.CreateFromDirectory(src, zipName);
            string result = Path.GetFullPath(zipName);

            if (
                ConfigurationManager.AppSettings["ftpUrl"] != null
                && ConfigurationManager.AppSettings["ftpLogin"] != null
                && ConfigurationManager.AppSettings["ftpPassword"] != null
            )
            {
                var client = new FtpClient(
                    ConfigurationManager.AppSettings["ftpUrl"],
                    ConfigurationManager.AppSettings["ftpLogin"],
                    ConfigurationManager.AppSettings["ftpPassword"]
                );
                client.AutoConnect();
                var status = client.UploadFile(
                    result,
                    ConfigurationManager.AppSettings["ftpDir"] + zipName,
                    FtpRemoteExists.Overwrite,
                    true,
                    FtpVerify.Retry
                );

                var msg = status switch
                {
                    FtpStatus.Success => "file successfully uploaded",
                    FtpStatus.Failed => "failed to upload file",
                    _ => "unknown"
                };
                Console.WriteLine(msg);
            }
            else
            {
                Console.WriteLine("Empty FTP information!");
            }
        }
        else
        {
            Console.WriteLine("Wrong directory!");
        }
        Console.WriteLine("Press any key to continue.................");
        Console.ReadKey();
    }
}
