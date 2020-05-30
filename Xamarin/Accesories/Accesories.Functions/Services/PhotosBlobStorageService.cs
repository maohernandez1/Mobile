using Accesories.Common.Models;
using Accesories.Functions.Services.Base;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accesories.Functions.Services
{
    public abstract class PhotosBlobStorageService : BaseBlobStorageService
    {
        #region Constant Fields
        readonly static string _photosContainerName = Environment.GetEnvironmentVariable("accessories");
        #endregion

        #region Methods
        public static async Task<PhotoModel> SavePhoto(byte[] photo, string photoTitle)
        {
            var photoBlob = await SaveBlockBlob(_photosContainerName, photo, photoTitle).ConfigureAwait(false);

            return new PhotoModel { Name = photoTitle, Image = photoBlob.Uri.ToString() };
        }

        public static async Task<List<PhotoModel>> GetAllPhotos()
        {
            var blobList = await GetBlobs<CloudBlockBlob>("accesoriesphotoscontainer").ConfigureAwait(false);

            var photoList = blobList.Select(x => new PhotoModel { Image = x.Uri.ToString() }).ToList();

            return photoList;
        }
        #endregion
    }
}
