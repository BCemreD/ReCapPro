using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Core.Aspects.Autofac;
using Core.Utilities.Business;
using Core.Utilities.FileSystems;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{

        public class CarImageManager : ICarImageService
        {
            private readonly ICarImageDal _carImageDal;
            public CarImageManager(ICarImageDal carImageDal)
            {
                _carImageDal = carImageDal;
            }
            public IDataResult<CarImage> GetById(int id)
            {
                return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == id));
            }
            public IDataResult<List<CarImage>> GetAll()
            {
                return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
            }
        [CacheAspect]
        public IDataResult<List<CarImage>> GetImagesById(int id)
            {
                var result = _carImageDal.GetAll(p => p.Id == id);
                IfCarImageOfCarNotExistsAddDefault(result, id);
                return new SuccessDataResult<List<CarImage>>(result);
            }
        [CacheRemoveAspect("IProductImageService.Get")]
        [SecuredOperation("carimage.add,moderator,admin")]
            public IResult Add(CarImage carImage, IFormFile file)
            {
                var result = BusinessRules.Run(
                    CheckIfCarImageCountOfCarCorrect(carImage.Id));
                if (result != null) return result;
                carImage.ImagePath = new FileManagerOnDisk().Add(file, CreateNewPath(file));
                carImage.Date = DateTime.Now;
                _carImageDal.Add(carImage);
                return new SuccessResult(Messages.CarImageAdded);
            }
        [CacheRemoveAspect("IProductImageService.Get")]
        [SecuredOperation("carimage.update,moderator,admin")]
            public IResult Update(CarImage carImage, IFormFile file)
            {
                var carImageToUpdate = _carImageDal.Get(p => p.Id == carImage.Id);
                carImage.Id = carImageToUpdate.Id;
                carImage.ImagePath = new FileManagerOnDisk().Update(carImageToUpdate.ImagePath, file, CreateNewPath(file));
                carImage.Date = DateTime.Now;
                _carImageDal.Update(carImage);
                return new SuccessResult(Messages.CarImageUpdated);
            }
        [CacheRemoveAspect("IProductImageService.Get")]
        [SecuredOperation("carimage.delete,moderator,admin")]
            public IResult Delete(CarImage carImage)
            {
                new FileManagerOnDisk().Delete(carImage.ImagePath);
                _carImageDal.Delete(carImage);
                return new SuccessResult(Messages.CarImageDeleted);
            }
            private void IfCarImageOfCarNotExistsAddDefault(List<CarImage> result, int id)
            {
                if (!result.Any())
                {
                    var defaultCarImage = new CarImage
                    {
                        Id = id,
                        ImagePath =
                            $@"{Environment.CurrentDirectory}\Public\Images\CarImage\default-img.png",
                        Date = DateTime.Now
                    };
                    result.Add(defaultCarImage);
                }
            }
            private string CreateNewPath(IFormFile file)
            {
                var fileInfo = new FileInfo(file.FileName);
                var newPath =
                    $@"{Environment.CurrentDirectory}\Public\Images\CarImage\Upload\{Guid.NewGuid()}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Year}{fileInfo.Extension}";
                return newPath;
            }
            private IResult CheckIfCarImageCountOfCarCorrect(int id)
            {
                var result = _carImageDal.GetAll(p => p.Id == id).Count;
                if (result >= 5) return new ErrorResult(Messages.CarImageCountOfCarError);
                return new SuccessResult();
            }
        }
    }

