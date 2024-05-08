﻿using OneClick.Infrastructure.Model;
using OneClick.Models;

namespace OneClick.Service.Interface
{
    public interface IGalleryService
    {
        ResponseMessage AddGallery(GalleryRequest req, IFormFile file);
        ResponseMessage AddVideo(GalleryRequest req, IFormFile file);
        List<ImagesResponse> GetGallery();
        List<ImagesResponse> GetVideo();
    }
}
