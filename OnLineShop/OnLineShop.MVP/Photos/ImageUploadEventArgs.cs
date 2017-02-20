using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnLineShop.MVP.Photos
{
    public class ImageUploadEventArgs : EventArgs
    {
        public ImageUploadEventArgs(string uploadedFileName, byte[] uploadedFile)
        {
            this.UploadedFileName = uploadedFileName;
            this.UploadedFile = uploadedFile;
        }

        public string UploadedFileName { get; private set; }

        public byte[] UploadedFile { get; private set; }

    }
}
