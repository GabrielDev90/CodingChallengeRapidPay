using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RapidPay.Service.Identity.Models.Dto;
using RapidPay.Service.Identity.Service;
using System.Security.Claims;

namespace RapidPay.Service.Identity.Application
{
    public class AuthFacade : IAuthFacade
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IJWTokenService _iJWTService;
        private RespondeDto _respondeDto;
        private IMapper _mapper;

        public AuthFacade(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
                          IJWTokenService jWTokenService, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _iJWTService = jWTokenService;
            _respondeDto = new RespondeDto();
            _mapper = mapper;
        }

        public async Task<RespondeDto> CreateUser(CreateUserDto _createUserDto)
        {
            var user = _mapper.Map<IdentityUser>(_createUserDto);

            var result = await _userManager.CreateAsync(user, _createUserDto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddClaimsAsync(user, new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email)
                });

                _createUserDto.Password = "********";
                _respondeDto.IsSuccess = result.Succeeded;
                _respondeDto.DisplayMessage = "User has been created successfully";
                _respondeDto.Result = _createUserDto;
                _respondeDto.StatusCode = 200;
            }
            else
            {
                _respondeDto.IsSuccess = result.Succeeded;
                _respondeDto.StatusCode = 200;
                _respondeDto.Result = result.Errors.ToList();
            }

            return _respondeDto;
        }

        public async Task<RespondeDto> SignIn(SignInDto signInDto)
        {
            var result = await _signInManager.PasswordSignInAsync(signInDto.UserName, signInDto.Password, false, false);

            if (result.Succeeded)
            {
                var resultUser = await _userManager.FindByNameAsync(signInDto.UserName);
                var resultClaims = await _userManager.GetClaimsAsync(resultUser);
                _respondeDto.Result = _iJWTService.GenerateToken(resultClaims);
                _respondeDto.IsSuccess = true;
                _respondeDto.StatusCode = 200;
            }
            else
            {
                _respondeDto.IsSuccess = false;
                _respondeDto.StatusCode = 200;
                _respondeDto.DisplayMessage = "User not found";
            }

            return _respondeDto;
        }
    }
}
