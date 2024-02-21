using SolarLabTask.Interfaces.Repos;
using SolarLabTask.Interfaces.Services;
using SolarLabTask.Models;
using System.Diagnostics;

namespace SolarLabTask.Services
{
    public class PersonService: IPersonService
    {
        private const int defaultImgId = 1;
        private readonly IPersonRepo _personRepo;
        private readonly IUserRepo _userRepo;
        private readonly ICategoryRepo _categoryRepo;
        private readonly IPersonImageRepo _imageRepo;
        public PersonService(IPersonRepo repoPers, ICategoryRepo repoCat, IUserRepo repoUser, IPersonImageRepo imageRepo)
        {
            _personRepo = repoPers;
            _categoryRepo = repoCat;
            _userRepo = repoUser;
            _imageRepo = imageRepo;
        }

        public void CreateUser(Person person, int UserId, IFormFile? File)
        {
            if (File != null)
            {
                var file = _getNewFileName(File.FileName);

                person.Image = _imageRepo.Add(new PersonImage()
                {
                    Name = File.FileName,
                    Path = file
                }
                );

                _uploadFile(File, file);
            }

            person.UserId = UserId;
            person.User = GetUser(UserId);
            person.PersonCategory = _categoryRepo.Get(person.CategoryId);
            _personRepo.Add(person);
        }

        public void UpdateUser(Person person, int UserId, IFormFile? File)
        {
            if (File != null)
            {
                var file = _getNewFileName(File.FileName);

                person.Image = _imageRepo.Add(new PersonImage()
                {
                    Name = File.FileName,
                    Path = file
                }
                );

                if (person.ImageId != defaultImgId)
                    _deletePrevFile(person.Image.Path);

                _uploadFile(File, file);
            } else
            {
                person.Image = _personRepo.GetImageById(person.Id);
                person.ImageId = person.Image.Id;
            }

            person.UserId = UserId;
            person.User = GetUser(UserId);
            person.PersonCategory = _categoryRepo.Get(person.CategoryId);
            _personRepo.Update(person);
        }

        public IEnumerable<PersonCategory> GetCategoryList()
        {
            return _categoryRepo.GetAll().ToList();
        }
  
        public User GetUser(int Id = 1)
        {
            return _userRepo.Get(Id);
        }

        private string _getNewFileName(string fileName)
        {
            string[] type = fileName.Split('.');
            return Guid.NewGuid().ToString() + "." + type[^1];
        }

        private async void _uploadFile(IFormFile file, string fileName)
        {
            string fullPath = $"{Directory.GetCurrentDirectory()}/wwwroot/imgs/{fileName}";

            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
        }

        private void _deletePrevFile(string fileName)
        {
            string fullPath = $"{Directory.GetCurrentDirectory()}/wwwroot/imgs/{fileName}";

            if (File.Exists(fullPath)) {
                File.Delete(fullPath);
            }
            else {
                Debug.WriteLine("File does not exist.");
            }
        }
    }
}
