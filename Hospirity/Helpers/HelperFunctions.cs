using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;


namespace Hospirity.Helpers
{
    public class HelperFunctions
    {
        // folder for the upload
        public static string ItemUploadFolderPath = "";
        public static string FullFileLocation;
        public static string FullThumbFileLocation;
        public static int FileSize;

        public static string renameUploadFile(HttpPostedFileBase file, string ItmUpldFlPth, Int32 counter = 0)
        {
            ItemUploadFolderPath = ItmUpldFlPth;
            var fileName = Path.GetFileName(file.FileName);

            string append = "item_";
            string finalFileName = append + ((counter).ToString()) + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(file.FileName);//fileName;
            if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(ItemUploadFolderPath + finalFileName)))
            {
                //file exists 
                return renameUploadFile(file, ItmUpldFlPth, ++counter);
            }
            //file doesn't exist, upload item but validate first
            return uploadFile(file, finalFileName);
        }

        private static string uploadFile(HttpPostedFileBase file, string fileName)
        {
            var path =
          Path.Combine(HttpContext.Current.Server.MapPath(ItemUploadFolderPath), fileName);
            string extension = Path.GetExtension(file.FileName);

            //make sure the file is valid
            if (!validateExtension(extension))
            {
                return FullFileLocation;
            }

            try
            {
                file.SaveAs(path);
                FullFileLocation = ItemUploadFolderPath + fileName;
                 
                
                return FullFileLocation;
            }
            catch
            {
                FullFileLocation = "~/images/logo.png";
                return FullFileLocation;
            }
        }

        private static bool validateExtension(string extension)
        {
            extension = extension.ToLower();
            switch (extension)
            {
                case ".aif":
                    return true;
                case ".cda":
                    return true;
                case ".mid":
                    return true;
                case ".mp3":
                    return true;
                case ".mpa":
                    return true;
                case ".ogg":
                    return true;
                case ".wav":
                    return true;
                case ".wma":
                    return true;
                case ".wpl":
                    return true;


                case ".7z":
                    return true;
                case ".arj":
                    return true;
                case ".deb":
                    return true;
                case ".pkg":
                    return true;
                case ".rar":
                    return true;
                case ".rpm":
                    return true;
                case ".z":
                    return true;
                case ".zip":
                    return true;


                case ".bin":
                    return true;
                case ".dmg":
                    return true;
                case ".iso":
                    return true;
                case ".toast":
                    return true;
                case ".vcd":
                    return true;


                case ".csv":
                    return true;
                case ".dat":
                    return true;
                case ".db":
                    return true;
                case ".log":
                    return true;
                case ".mdb":
                    return true;
                case ".sav":
                    return true;
                case ".sql":
                    return true;
                case ".tar":
                    return true;
                case ".xml":
                    return true;


                case ".apk":
                    return true;
                case ".bat":
                    return true;
                case ".cgi":
                    return true;
                case ".pl":
                    return true;
                case ".com":
                    return true;
                case ".exe":
                    return true;
                case ".gadget":
                    return true;
                case ".jar":
                    return true;
                case ".py":
                    return true;
                case ".wsf":
                    return true;


                case ".fnt":
                    return true;
                case ".fon":
                    return true;
                case ".otf":
                    return true;
                case ".ttf":
                    return true;


                case ".ai":
                    return true;
                case ".bmp":
                    return true;
                case ".gif":
                    return true;
                case ".ico":
                    return true;
                case ".jpeg":
                    return true;
                case ".jpg":
                    return true;
                case ".JPEG":
                    return true;
                case ".png":
                    return true;
                case ".ps":
                    return true;
                case ".psd":
                    return true;
                case ".svg":
                    return true;
                case ".tif":
                    return true;
                case ".tiff":
                    return true;



                case ".asp":
                    return true;
                case ".aspx":
                    return true;
                case ".cer":
                    return true;
                case ".cfm":
                    return true;
                case ".css":
                    return true;
                case ".htm":
                    return true;
                case ".html":
                    return true;
                case ".js":
                    return true;
                case ".jsp":
                    return true;
                case ".part":
                    return true;
                case ".php":
                    return true;
                case ".rss":
                    return true;
                case ".xhtml":
                    return true;



                case ".key":
                    return true;
                case ".odp":
                    return true;
                case ".pps":
                    return true;
                case ".ppt":
                    return true;
                case ".pptx":
                    return true;



                case ".c":
                    return true;
                case ".class":
                    return true;
                case ".cpp":
                    return true;
                case ".cs":
                    return true;
                case ".h":
                    return true;
                case ".java":
                    return true;
                case ".sh":
                    return true;
                case ".swift":
                    return true;
                case ".vb":
                    return true;



                case ".ods":
                    return true;
                case ".xlr":
                    return true;
                case ".xls":
                    return true;
                case ".xlsx":
                    return true;


                case ".bak":
                    return true;
                case ".cab":
                    return true;
                case ".cfg":
                    return true;
                case ".cpl":
                    return true;
                case ".cur":
                    return true;
                case ".dll":
                    return true;
                case ".dmp":
                    return true;
                case ".drv":
                    return true;
                case ".icns":
                    return true;
                case ".ini":
                    return true;
                case ".lnk":
                    return true;
                case ".msi":
                    return true;
                case ".sys":
                    return true;
                case ".tmp":
                    return true;



                case ".3g2":
                    return true;
                case ".3gp":
                    return true;
                case ".avi":
                    return true;
                case ".flv":
                    return true;
                case ".h264":
                    return true;
                case ".m4v":
                    return true;
                case ".mkv":
                    return true;
                case ".mov":
                    return true;
                case ".mp4":
                    return true;
                case ".mpg":
                    return true;


                case ".mpeg":
                    return true;
                case ".rm":
                    return true;
                case ".swf":
                    return true;
                case ".vob":
                    return true;
                case ".wmv":
                    return true;


                case ".doc":
                    return true;
                case ".docx":
                    return true;
                case ".odt":
                    return true;
                case ".pdf":
                    return true;
                case ".rtf":
                    return true;
                case ".tex":
                    return true;
                case ".txt":
                    return true;
                case ".wks":
                    return true;
                case ".wps":
                    return true;
                case ".wpd":
                    return true;
               

                default:
                    return false;
            }
        }


        ///#################################################### Thumb Image Uploading ##################################################################

        public static string ThumbrenameUploadFile(HttpPostedFileBase file, string ItmUpldFlPth, int size, Int32 counter = 0)
        {
            FileSize = size;
            ItemUploadFolderPath = ItmUpldFlPth;
            var fileName = Path.GetFileName(file.FileName);

            string append = "item_";
            string finalFileName = append + ((counter).ToString()) + "_" + fileName;
            if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(ItemUploadFolderPath + finalFileName)))
            {
                //file exists 
                return ThumbrenameUploadFile(file, ItmUpldFlPth, size, ++counter);
            }
            //file doesn't exist, upload item but validate first
            return ThumbuploadFile(file, finalFileName);
        }

        private static string ThumbuploadFile(HttpPostedFileBase file, string fileName)
        {
            var path =
          Path.Combine(HttpContext.Current.Server.MapPath(ItemUploadFolderPath), fileName);
            string extension = Path.GetExtension(file.FileName);

            //make sure the file is valid
            if (!ThumbvalidateExtension(extension))
            {
                return FullThumbFileLocation;
            }


            try
            {
                file.SaveAs(path);
                FullThumbFileLocation = ItemUploadFolderPath + fileName;

                Image imgOriginal = Image.FromFile(path);

                //pass in whatever value you want 
                Image imgActual = ScaleBySize(imgOriginal, FileSize);
                imgOriginal.Dispose();
                imgActual.Save(path);
                imgActual.Dispose();

                return FullThumbFileLocation;
            }
            catch
            {
                return FullThumbFileLocation;
            }
        }

        private static bool ThumbvalidateExtension(string extension)
        {
            extension = extension.ToLower();
            switch (extension)
            {





                case ".aif":
                    return true;
                case ".cda":
                    return true;
                case ".mid":
                    return true;
                case ".mp3":
                    return true;
                case ".mpa":
                    return true;
                case ".ogg":
                    return true;
                case ".wav":
                    return true;
                case ".wma":
                    return true;
                case ".wpl":
                    return true;


                case ".7z":
                    return true;
                case ".arj":
                    return true;
                case ".deb":
                    return true;
                case ".pkg":
                    return true;
                case ".rar":
                    return true;
                case ".rpm":
                    return true;
                case ".z":
                    return true;
                case ".zip":
                    return true;


                case ".bin":
                    return true;
                case ".dmg":
                    return true;
                case ".iso":
                    return true;
                case ".toast":
                    return true;
                case ".vcd":
                    return true;


                case ".csv":
                    return true;
                case ".dat":
                    return true;
                case ".db":
                    return true;
                case ".log":
                    return true;
                case ".mdb":
                    return true;
                case ".sav":
                    return true;
                case ".sql":
                    return true;
                case ".tar":
                    return true;
                case ".xml":
                    return true;


                case ".apk":
                    return true;
                case ".bat":
                    return true;
                case ".cgi":
                    return true;
                case ".pl":
                    return true;
                case ".com":
                    return true;
                case ".exe":
                    return true;
                case ".gadget":
                    return true;
                case ".jar":
                    return true;
                case ".py":
                    return true;
                case ".wsf":
                    return true;


                case ".fnt":
                    return true;
                case ".fon":
                    return true;
                case ".otf":
                    return true;
                case ".ttf":
                    return true;


                case ".ai":
                    return true;
                case ".bmp":
                    return true;
                case ".gif":
                    return true;
                case ".ico":
                    return true;
                case ".jpeg":
                    return true;
                case ".jpg":
                    return true;
                case ".JPEG":
                    return true;
                case ".png":
                    return true;
                case ".ps":
                    return true;
                case ".psd":
                    return true;
                case ".svg":
                    return true;
                case ".tif":
                    return true;
                case ".tiff":
                    return true;



                case ".asp":
                    return true;
                case ".aspx":
                    return true;
                case ".cer":
                    return true;
                case ".cfm":
                    return true;
                case ".css":
                    return true;
                case ".htm":
                    return true;
                case ".html":
                    return true;
                case ".js":
                    return true;
                case ".jsp":
                    return true;
                case ".part":
                    return true;
                case ".php":
                    return true;
                case ".rss":
                    return true;
                case ".xhtml":
                    return true;



                case ".key":
                    return true;
                case ".odp":
                    return true;
                case ".pps":
                    return true;
                case ".ppt":
                    return true;
                case ".pptx":
                    return true;



                case ".c":
                    return true;
                case ".class":
                    return true;
                case ".cpp":
                    return true;
                case ".cs":
                    return true;
                case ".h":
                    return true;
                case ".java":
                    return true;
                case ".sh":
                    return true;
                case ".swift":
                    return true;
                case ".vb":
                    return true;



                case ".ods":
                    return true;
                case ".xlr":
                    return true;
                case ".xls":
                    return true;
                case ".xlsx":
                    return true;


                case ".bak":
                    return true;
                case ".cab":
                    return true;
                case ".cfg":
                    return true;
                case ".cpl":
                    return true;
                case ".cur":
                    return true;
                case ".dll":
                    return true;
                case ".dmp":
                    return true;
                case ".drv":
                    return true;
                case ".icns":
                    return true;
                case ".ini":
                    return true;
                case ".lnk":
                    return true;
                case ".msi":
                    return true;
                case ".sys":
                    return true;
                case ".tmp":
                    return true;



                case ".3g2":
                    return true;
                case ".3gp":
                    return true;
                case ".avi":
                    return true;
                case ".flv":
                    return true;
                case ".h264":
                    return true;
                case ".m4v":
                    return true;
                case ".mkv":
                    return true;
                case ".mov":
                    return true;
                case ".mp4":
                    return true;
                case ".mpg":
                    return true;


                case ".mpeg":
                    return true;
                case ".rm":
                    return true;
                case ".swf":
                    return true;
                case ".vob":
                    return true;
                case ".wmv":
                    return true;


                case ".doc":
                    return true;
                case ".docx":
                    return true;
                case ".odt":
                    return true;
                case ".pdf":
                    return true;
                case ".rtf":
                    return true;
                case ".tex":
                    return true;
                case ".txt":
                    return true;
                case ".wks":
                    return true;
                case ".wps":
                    return true;
                case ".wpd":
                    return true;


                default:
                    return false;
            }
        }

        public static Image ScaleBySize(Image imgPhoto, int size)
        {

            float sourceWidth = imgPhoto.Width;
            float sourceHeight = imgPhoto.Height;
            float destHeight = 0;
            float destWidth = 0;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;

            if (size == 1)//Small Thumb size //2 for medium size
            {
                destWidth = 160;
                destHeight = 47;
            }
            else if (size == 2)//Small Thumb size //2 for medium size
            {
                destWidth = 1920;
                destHeight = 1080;
            }
            else if (size == 3)//Small Thumb size //2 for medium size
            {
                destWidth =60;
                destHeight = 60;
            }
            // Width is greater than height, set Width = logoSize and resize height accordingly

            Bitmap bmPhoto = new Bitmap((int)destWidth, (int)destHeight,
                                        PixelFormat.Format32bppPArgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, (int)destWidth, (int)destHeight),
                new Rectangle(sourceX, sourceY, (int)sourceWidth, (int)sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();

            return bmPhoto;
        }

        ///#################################################### Resume Uploading ##################################################################
        ///
        public static string renameUploadFileResume(HttpPostedFileBase file, string ItmUpldFlPth, Int32 counter = 0)
        {
            ItemUploadFolderPath = ItmUpldFlPth;
            var fileName = Path.GetFileName(file.FileName);

            string append = "Resume_";
            string finalFileName = append + ((counter).ToString()) + "_" + fileName;
            if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(ItemUploadFolderPath + finalFileName)))
            {
                //file exists 
                return renameUploadFileResume(file, ItmUpldFlPth, ++counter);
            }
            //file doesn't exist, upload item but validate first
            return uploadFileResume(file, finalFileName);
        }

        private static string uploadFileResume(HttpPostedFileBase file, string fileName)
        {
            var path =
          Path.Combine(HttpContext.Current.Server.MapPath(ItemUploadFolderPath), fileName);
            string extension = Path.GetExtension(file.FileName);

            //make sure the file is valid
            if (!validateExtensionResume(extension))
            {
                return FullFileLocation;
            }

            try
            {
                file.SaveAs(path);
                FullFileLocation = ItemUploadFolderPath + fileName;
                return FullFileLocation;
            }
            catch
            {
                FullFileLocation = "~/images/file-not-found.jpg";
                return FullFileLocation;
            }
        }

        private static bool validateExtensionResume(string extension)
        {
            extension = extension.ToLower();
            switch (extension)
            {
                case ".aif":
                    return true;
                case ".cda":
                    return true;
                case ".mid":
                    return true;
                case ".mp3":
                    return true;
                case ".mpa":
                    return true;
                case ".ogg":
                    return true;
                case ".wav":
                    return true;
                case ".wma":
                    return true;
                case ".wpl":
                    return true;


                case ".7z":
                    return true;
                case ".arj":
                    return true;
                case ".deb":
                    return true;
                case ".pkg":
                    return true;
                case ".rar":
                    return true;
                case ".rpm":
                    return true;
                case ".z":
                    return true;
                case ".zip":
                    return true;


                case ".bin":
                    return true;
                case ".dmg":
                    return true;
                case ".iso":
                    return true;
                case ".toast":
                    return true;
                case ".vcd":
                    return true;


                case ".csv":
                    return true;
                case ".dat":
                    return true;
                case ".db":
                    return true;
                case ".log":
                    return true;
                case ".mdb":
                    return true;
                case ".sav":
                    return true;
                case ".sql":
                    return true;
                case ".tar":
                    return true;
                case ".xml":
                    return true;


                case ".apk":
                    return true;
                case ".bat":
                    return true;
                case ".cgi":
                    return true;
                case ".pl":
                    return true;
                case ".com":
                    return true;
                case ".exe":
                    return true;
                case ".gadget":
                    return true;
                case ".jar":
                    return true;
                case ".py":
                    return true;
                case ".wsf":
                    return true;


                case ".fnt":
                    return true;
                case ".fon":
                    return true;
                case ".otf":
                    return true;
                case ".ttf":
                    return true;


                case ".ai":
                    return true;
                case ".bmp":
                    return true;
                case ".gif":
                    return true;
                case ".ico":
                    return true;
                case ".jpeg":
                    return true;
                case ".jpg":
                    return true;
                case ".JPEG":
                    return true;
                case ".png":
                    return true;
                case ".ps":
                    return true;
                case ".psd":
                    return true;
                case ".svg":
                    return true;
                case ".tif":
                    return true;
                case ".tiff":
                    return true;



                case ".asp":
                    return true;
                case ".aspx":
                    return true;
                case ".cer":
                    return true;
                case ".cfm":
                    return true;
                case ".css":
                    return true;
                case ".htm":
                    return true;
                case ".html":
                    return true;
                case ".js":
                    return true;
                case ".jsp":
                    return true;
                case ".part":
                    return true;
                case ".php":
                    return true;
                case ".rss":
                    return true;
                case ".xhtml":
                    return true;



                case ".key":
                    return true;
                case ".odp":
                    return true;
                case ".pps":
                    return true;
                case ".ppt":
                    return true;
                case ".pptx":
                    return true;



                case ".c":
                    return true;
                case ".class":
                    return true;
                case ".cpp":
                    return true;
                case ".cs":
                    return true;
                case ".h":
                    return true;
                case ".java":
                    return true;
                case ".sh":
                    return true;
                case ".swift":
                    return true;
                case ".vb":
                    return true;



                case ".ods":
                    return true;
                case ".xlr":
                    return true;
                case ".xls":
                    return true;
                case ".xlsx":
                    return true;


                case ".bak":
                    return true;
                case ".cab":
                    return true;
                case ".cfg":
                    return true;
                case ".cpl":
                    return true;
                case ".cur":
                    return true;
                case ".dll":
                    return true;
                case ".dmp":
                    return true;
                case ".drv":
                    return true;
                case ".icns":
                    return true;
                case ".ini":
                    return true;
                case ".lnk":
                    return true;
                case ".msi":
                    return true;
                case ".sys":
                    return true;
                case ".tmp":
                    return true;



                case ".3g2":
                    return true;
                case ".3gp":
                    return true;
                case ".avi":
                    return true;
                case ".flv":
                    return true;
                case ".h264":
                    return true;
                case ".m4v":
                    return true;
                case ".mkv":
                    return true;
                case ".mov":
                    return true;
                case ".mp4":
                    return true;
                case ".mpg":
                    return true;


                case ".mpeg":
                    return true;
                case ".rm":
                    return true;
                case ".swf":
                    return true;
                case ".vob":
                    return true;
                case ".wmv":
                    return true;


                case ".doc":
                    return true;
                case ".docx":
                    return true;
                case ".odt":
                    return true;
                case ".pdf":
                    return true;
                case ".rtf":
                    return true;
                case ".tex":
                    return true;
                case ".txt":
                    return true;
                case ".wks":
                    return true;
                case ".wps":
                    return true;
                case ".wpd":
                    return true;
                default:
                    return false;
            }
        }






        ///#################################################### My Helper ##################################################################
        ///
        public static string myrenameUploadFileResume(HttpPostedFileBase file, string ItmUpldFlPth, Int32 counter = 0)
        {
            ItemUploadFolderPath = ItmUpldFlPth;
            var fileName = Path.GetFileName(file.FileName);

            string append = "HMS_";
            string finalFileName = append + ((counter).ToString()) + "_" + fileName; 
            if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(ItemUploadFolderPath + finalFileName)))
            {
                //file exists 
                return myrenameUploadFileResume(file, ItmUpldFlPth, ++counter);
            }
            //file doesn't exist, upload item but validate first
            return myuploadFileResume(file, finalFileName);
        }

        private static string myuploadFileResume(HttpPostedFileBase file, string fileName)
        {
            var path =
          Path.Combine(HttpContext.Current.Server.MapPath(ItemUploadFolderPath), fileName);
            string extension = Path.GetExtension(file.FileName);

            //make sure the file is valid
            if (!myvalidateExtensionResume(extension))
            {
                return FullFileLocation;
            }

            try
            {
                file.SaveAs(path);
                FullFileLocation = ItemUploadFolderPath + fileName;
                return FullFileLocation;
            }
            catch
            {
                FullFileLocation = "~/images/file-not-found.jpg";
                return FullFileLocation;
            }
        }

        private static bool myvalidateExtensionResume(string extension)
        {
            extension = extension.ToLower();
            switch (extension)
            {


                case ".aif":
                    return true;
                case ".cda":
                    return true;
                case ".mid":
                    return true;
                case ".mp3":
                    return true;
                case ".mpa":
                    return true;
                case ".ogg":
                    return true;
                case ".wav":
                    return true;
                case ".wma":
                    return true;
                case ".wpl":
                    return true;


                case ".7z":
                    return true;
                case ".arj":
                    return true;
                case ".deb":
                    return true;
                case ".pkg":
                    return true;
                case ".rar":
                    return true;
                case ".rpm":
                    return true;
                case ".z":
                    return true;
                case ".zip":
                    return true;


                case ".bin":
                    return true;
                case ".dmg":
                    return true;
                case ".iso":
                    return true;
                case ".toast":
                    return true;
                case ".vcd":
                    return true;


                case ".csv":
                    return true;
                case ".dat":
                    return true;
                case ".db":
                    return true;
                case ".log":
                    return true;
                case ".mdb":
                    return true;
                case ".sav":
                    return true;
                case ".sql":
                    return true;
                case ".tar":
                    return true;
                case ".xml":
                    return true;


                case ".apk":
                    return true;
                case ".bat":
                    return true;
                case ".cgi":
                    return true;
                case ".pl":
                    return true;
                case ".com":
                    return true;
                case ".exe":
                    return true;
                case ".gadget":
                    return true;
                case ".jar":
                    return true;
                case ".py":
                    return true;
                case ".wsf":
                    return true;


                case ".fnt":
                    return true;
                case ".fon":
                    return true;
                case ".otf":
                    return true;
                case ".ttf":
                    return true;


                case ".ai":
                    return true;
                case ".bmp":
                    return true;
                case ".gif":
                    return true;
                case ".ico":
                    return true;
                case ".jpeg":
                    return true;
                case ".jpg":
                    return true;
                case ".JPEG":
                    return true;
                case ".png":
                    return true;
                case ".ps":
                    return true;
                case ".psd":
                    return true;
                case ".svg":
                    return true;
                case ".tif":
                    return true;
                case ".tiff":
                    return true;



                case ".asp":
                    return true;
                case ".aspx":
                    return true;
                case ".cer":
                    return true;
                case ".cfm":
                    return true;
                case ".css":
                    return true;
                case ".htm":
                    return true;
                case ".html":
                    return true;
                case ".js":
                    return true;
                case ".jsp":
                    return true;
                case ".part":
                    return true;
                case ".php":
                    return true;
                case ".rss":
                    return true;
                case ".xhtml":
                    return true;



                case ".key":
                    return true;
                case ".odp":
                    return true;
                case ".pps":
                    return true;
                case ".ppt":
                    return true;
                case ".pptx":
                    return true;



                case ".c":
                    return true;
                case ".class":
                    return true;
                case ".cpp":
                    return true;
                case ".cs":
                    return true;
                case ".h":
                    return true;
                case ".java":
                    return true;
                case ".sh":
                    return true;
                case ".swift":
                    return true;
                case ".vb":
                    return true;



                case ".ods":
                    return true;
                case ".xlr":
                    return true;
                case ".xls":
                    return true;
                case ".xlsx":
                    return true;


                case ".bak":
                    return true;
                case ".cab":
                    return true;
                case ".cfg":
                    return true;
                case ".cpl":
                    return true;
                case ".cur":
                    return true;
                case ".dll":
                    return true;
                case ".dmp":
                    return true;
                case ".drv":
                    return true;
                case ".icns":
                    return true;
                case ".ini":
                    return true;
                case ".lnk":
                    return true;
                case ".msi":
                    return true;
                case ".sys":
                    return true;
                case ".tmp":
                    return true;



                case ".3g2":
                    return true;
                case ".3gp":
                    return true;
                case ".avi":
                    return true;
                case ".flv":
                    return true;
                case ".h264":
                    return true;
                case ".m4v":
                    return true;
                case ".mkv":
                    return true;
                case ".mov":
                    return true;
                case ".mp4":
                    return true;
                case ".mpg":
                    return true;


                case ".mpeg":
                    return true;
                case ".rm":
                    return true;
                case ".swf":
                    return true;
                case ".vob":
                    return true;
                case ".wmv":
                    return true;


                case ".doc":
                    return true;
                case ".docx":
                    return true;
                case ".odt":
                    return true;
                case ".pdf":
                    return true;
                case ".rtf":
                    return true;
                case ".tex":
                    return true;
                case ".txt":
                    return true;
                case ".wks":
                    return true;
                case ".wps":
                    return true;
                case ".wpd":
                    return true;

                default:
                    return false;
            }
        }


    }
}