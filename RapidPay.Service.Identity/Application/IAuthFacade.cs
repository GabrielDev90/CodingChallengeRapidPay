using RapidPay.Service.Identity.Models.Dto;

namespace RapidPay.Service.Identity.Application
{
    public interface IAuthFacade
    {
        Task<RespondeDto> CreateUser(CreateUserDto createUserDto);
        Task<RespondeDto> SignIn(SignInDto signInDto);
    }
}