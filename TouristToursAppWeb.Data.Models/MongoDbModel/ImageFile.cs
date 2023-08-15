using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristToursAppWeb.Data.Models.MongoDbModel
{
   public class ImageFile
    {
        public ObjectId Id { get; set; } // ObjectId за MongoDB
        public byte[] ImageData { get; set; } // Байтове на снимката
        public string FileName { get; set; } // Име на файла на снимката (например, "photo.jpg")
        public string Extensions { get; set; } // Разширение на файла (например, "jpg", "png" и т.н.)
        public string TourId { get; set; }
    }
}
