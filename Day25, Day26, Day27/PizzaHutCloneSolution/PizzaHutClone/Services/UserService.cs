using System.Security.Cryptography;
using System.Text;
using PizzaHutClone.Exceptions;
using PizzaHutClone.Interfaces;
using PizzaHutClone.Models;
using PizzaHutClone.Models.DTO;
using PizzaHutClone.Models.DTOs;
using PizzaHutClone.Repositories;

namespace PizzaHutClone.Services
{
    public class UserService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IRepository<User, int> _userRepository;
        private readonly TokenService _tokenService;

        public UserService(IRepository<User, int> userRepo, ICustomerRepository customerRepo, TokenService tokenService)
        {
            _customerRepository = customerRepo;
            _userRepository = userRepo;
            _tokenService = tokenService;
        }

        /// <exception cref="UserEmailAlreadyRegisteredException"/>
        public async Task RegisterUser(RegisterDTO userRegisterDTO)
        {
            Customer? existingCustomer =
                await _customerRepository.GetByEmailWithUser(userRegisterDTO.Email);
            if (existingCustomer != null)
            {
                throw new UserEmailAlreadyRegisteredException();
            }

            Customer customer = MapUserRegisterDTOWithCustomer(userRegisterDTO);
            await _customerRepository.Add(customer);
        }

        /// <exception cref= "UnauthorizedUserException" />
        public async Task<LoginReturnDTO> Login(LoginDTO userLoginDTO)
        {
            Customer? storedCustomer =
                await _customerRepository.GetByEmailWithUser(userLoginDTO.Email);


            if (storedCustomer == null) throw new UnauthorizedUserException();

            HMACSHA512 hMACSHA = new HMACSHA512(storedCustomer.User.PasswordHashKey);
            var encrypterPass = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(userLoginDTO.Password));

            bool isPasswordSame = ComparePassword(encrypterPass, storedCustomer.User.HashedPassword);
            if (isPasswordSame)
            {
                LoginReturnDTO loginReturnDTO = MapCustomerToLoginReturnDTO(storedCustomer);
                return loginReturnDTO;
            }
            throw new UnauthorizedUserException();

        }

        private bool ComparePassword(byte[] encrypterPass, byte[] password)
        {
            for (int i = 0; i < encrypterPass.Length; i++)
            {
                if (encrypterPass[i] != password[i])
                {
                    return false;
                }
            }
            return true;
        }

        private LoginReturnDTO MapCustomerToLoginReturnDTO(Customer customer)
        {
            LoginReturnDTO returnDTO = new LoginReturnDTO();
            returnDTO.CustomerId = customer.CustomerId;
            returnDTO.Token = _tokenService.GenerateToken(customer);

            return returnDTO;
        }

        private User MapUserRegisterDTOWithUser(RegisterDTO userRegisterDTO)
        {
            HMACSHA512 hMACSHA = new HMACSHA512();

            User user = new User
            {
                Status = "DISABLED",
                Roles = "SELLER",
                PasswordHashKey = hMACSHA.Key,
                HashedPassword = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(userRegisterDTO.Password))
            };

            return user;
        }

        private Customer MapUserRegisterDTOWithCustomer(RegisterDTO userRegisterDTO)
        {
            User user = MapUserRegisterDTOWithUser(userRegisterDTO);

            Customer customer = new Customer
            {
                Name = userRegisterDTO.Name,
                PhoneNumber = userRegisterDTO.PhoneNumber,
                Email = userRegisterDTO.Email,
                User = user
            };

            return customer;
        }

    }


}
