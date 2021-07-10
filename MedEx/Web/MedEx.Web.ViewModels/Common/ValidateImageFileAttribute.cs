using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace MedEx.Web.ViewModels.Common
{
    public class ValidateImageFileAttribute : RequiredAttribute
    {
        private const int MaxFileLengthInBytes = 1048576; // = (1 * 1024 * 1024) = 1 MB;

        public override bool IsValid(object value)
        {
            // Represents the file sent with the HttpRequest
            if (!(value is IFormFile file))
            {
                return false;
            }

            if (file.Length > MaxFileLengthInBytes)
            {
                return false;
            }

            // Check the image mime types
            return file.ContentType.ToLower() == "image/jpg" || file.ContentType.ToLower() == "image/jpeg" || file.ContentType.ToLower() == "image/png";
        }
    }
}
