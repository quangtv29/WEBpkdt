using API.Business.DTOs.CustomerDTO;
using API.Business.Helper;
using API.Business.Repository.IRepository;
using API.Business.Services.Interface;
using API.Entities;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Net.WebSockets;

namespace API.Business.Services
{
    public sealed class CustomerService : ICustomerService
    {
        private readonly  IRepositoryManager _repo;
        private readonly IMapper _mapper;
        private readonly Cloudinary _cloudinary;
        private readonly IConfiguration _configuration;

        public CustomerService(IRepositoryManager repo, IMapper mapper, IOptions<CloudinarySettings> config, IConfiguration configuration)
        {
            _configuration = configuration;
            _repo = repo;
            _mapper = mapper;
            var account = new Account(
           _configuration.GetValue<string>("CloudinarySettings:CloudName"),
           _configuration.GetValue<string>("CloudinarySettings:ApiKey"),
           _configuration.GetValue<string>("CloudinarySettings:ApiSecret"));
            _cloudinary = new Cloudinary(account);
        }

        public async Task<Customer> addCustomer(CreateCustomerDTO customer)
        {
             var convert = _mapper.Map<Customer>(customer);
            _repo.Customer.addCustomer(convert); 
            await  _repo.SaveAsync();
            return convert;
        }
        public async Task<Customer> addAvatar (IFormFile Image, string? CustomerId)
        {
            var customer = await _repo.Customer.GetAllByCondition(p => p.isDelete == false,true)
                .Where(p=>p.Id== CustomerId)
                .FirstOrDefaultAsync();
            if (Image == null || Image.Length == 0)
            {
                throw new Exception("Không có ảnh");
            }
            string imagePath = await SaveImage(Image);
            customer.Image = imagePath;
            await _repo.SaveAsync();
            return customer;
        }
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            var publicId = Guid.NewGuid().ToString();
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(imageFile.FileName, imageFile.OpenReadStream()),
                PublicId = publicId
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);


            var imageUrl = uploadResult.SecureUrl.ToString();

            return imageUrl;
        }
        public async Task<IEnumerable<Customer>> GetAllCustomer(bool trackChanges)
        {          
              var customer = await _repo.Customer.GetAllCustomer(trackChanges) 
                ?? throw new Exception ("Customer is null");
                return customer;
        }

        public async Task<IEnumerable<Customer>> GetCustomerByID(string? Id, bool trackChanges)
        {
            var customer =  await _repo.Customer.GetCustomerByCondition(e=> e.Id == Id, trackChanges);
            return customer;
        }

        public async Task<InfoCustomerDTO> getInfoCustomer (string? Id, bool trackChanges)
        {
            var result = await (from cu in _repo.Customer.GetAllByCondition(p => p.Id == Id, trackChanges)
                                join bi in _repo.Bill.GetAll(false) on cu.Id equals bi.CustomerID
                                join or in _repo.OrderDetail.GetAll(false) on bi.Id equals or.BillId
                                select new InfoCustomerDTO
                                {

                                }
                                ).FirstOrDefaultAsync();
            return null;
        }
       public async Task<Customer> updateCustomer (string? Id, UpdateCustomerDTO update)
        {
            var cus = await _repo.Customer.GetAllByCondition(e => e.Id == Id, true).FirstOrDefaultAsync();
            cus.Address1 = update.Address1;
            cus.Address2 = update.Address2;
            cus.Gender = update.Gender;
            await _repo.SaveAsync();
            return cus;
        }

        public async Task<Customer> getCustomerByIDD(string? Id)
        {
           var result = await _repo.Customer.GetAllByCondition(p=> p.isDelete == false,false).Where(p=>p.Id == Id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<Customer> lockAccount (string? id)
        {
            var result = await _repo.Customer.GetAllByCondition(p => p.Id == id, true)
                .Where(p => p.isDelete == false)
                .FirstOrDefaultAsync();
            if (result == null)
            {
                return null;
            }
            if (result.isActive == true)
            {
                result.isActive = false;
            }
            else
            {
                result.isActive = true;
            }
            await _repo.SaveAsync();
            return result;           
        }
    }
}
