using API_RandomUser.Interfaces;
using API_RandomUser.DTOs;
using API_RandomUser.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using API_RandomUser.Repositories;

namespace API_RandomUser.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly INameRepository _nameRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly ILoginRepository _loginRepository;
        private readonly IDobRepository _dobRepository;
        private readonly IRegisteredRepository _registeredRepository;
        private readonly IIDRepository _idRepository;
        private readonly IPictureRepository _pictureRepository;
        private readonly IRegisterTokenRepository _registerTokenRepository;

        public UserService(
            IUserRepository userRepository,
            INameRepository nameRepository,
            ILocationRepository locationRepository,
            ILoginRepository loginRepository,
            IDobRepository dobRepository,
            IRegisteredRepository registeredRepository,
            IIDRepository idRepository,
            IPictureRepository pictureRepository,
            IRegisterTokenRepository registerTokenRepository)
        {
            _userRepository = userRepository;
            _nameRepository = nameRepository;
            _locationRepository = locationRepository;
            _loginRepository = loginRepository;
            _dobRepository = dobRepository;
            _registeredRepository = registeredRepository;
            _idRepository = idRepository;
            _pictureRepository = pictureRepository;
            _registerTokenRepository = registerTokenRepository;
        }

        public async Task<List<UserDto>> FetchUsersFromAPI(string apiUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    UserResult resultUsers = JsonConvert.DeserializeObject<UserResult>(json);
                    var userDtos = resultUsers?.results.Select(result => (UserDto)result).ToList() ?? new List<UserDto>();
                    return userDtos;
                }
                return new List<UserDto>();
            }
        }

        public async Task CreateUserAsync(UserDto userDto)
        {
            var user = new Result
            {
                name = (Name)userDto.name,
                location = (Location)userDto.location,
                login = (Login)userDto.login,
                dob = (Dob)userDto.dob,
                registered = (Registered)userDto.registered,
                id = (Id)userDto.id,
                picture = (Picture)userDto.picture,
                gender = userDto.gender,
                email = userDto.email,
                phone = userDto.phone,
                cell = userDto.cell,
                nat = userDto.nat
            };

            user.nameId = await _nameRepository.InsertNameAsync(user.name);
            user.locationId = await _locationRepository.InsertLocationAsync(user.location);
            user.loginId = await _loginRepository.InsertLoginAsync(user.login);
            user.dobId = await _dobRepository.InsertDobAsync(user.dob);
            user.registeredId = await _registeredRepository.InsertRegisteredAsync(user.registered);
            user.idId = await _idRepository.InsertIdAsync(user.id);
            user.pictureId = await _pictureRepository.InsertPictureAsync(user.picture);

            await _userRepository.InsertUserAsync(user);
        }

        public async Task<List<ResultDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return users.Select(user => new ResultDto
            {
                gender = user.gender,
                nameId = user.nameId,
                locationId = user.locationId,
                email = user.email,
                loginId = user.loginId,
                dobId = user.dobId,
                registeredId = user.registeredId,
                phone = user.phone,
                cell = user.cell,
                idId = user.idId,
                pictureId = user.pictureId,
                nat = user.nat,
                
            }).ToList();
        }
        public async Task RegisterUserAsync(RegisterToken registerToken)
        {
            await _registerTokenRepository.InsertRegisterTokenAsync(registerToken);
        }

        
        public async Task<RegisterToken> AuthenticateUserAsync(string email, string password)
        {
            return await _registerTokenRepository.GetRegisterTokenByEmailAndPasswordAsync(email, password);
        }
    }
}