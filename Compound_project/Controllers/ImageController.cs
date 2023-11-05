using BussienesLayer.DTO;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Compound_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ImageController : ControllerBase
    {

        [HttpPost("UploadImage")]
        public async Task <ActionResult<DTOResult>> UploadImage(IFormFile file,DTOUnit _unit)//dtounitimage,buildingimage,
        {
            DTOResult result = new DTOResult();
            if(file == null|| file.Length == 0)
            {
                result.IsPass = false;
                result.Data = "No Images Uploaded";
            }
            try
            {
                var uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

                if (!Directory.Exists(uploadDir))
                {
                    Directory.CreateDirectory(uploadDir);
                }
                var FileName = $"{file.FileName}_{Guid.NewGuid()}";
                var filePath = Path.Combine(uploadDir, FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                //store uploaded file to the database
                

           
                var imageUrl = $"/Uploads/{FileName}";
                result.IsPass = true;
                result.Data = "File Uploaded Successfully";
                return result;
            }
            catch (Exception ex)
            {
                result.IsPass = false;
                result.Data = "An error occurred while processing the file";
                return result;
            }
        }
    }
       
}

