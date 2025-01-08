using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.LoginUser
{
    internal class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;
        public LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;            
        }

        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            //utilizar o algoritmo para criar o hash da senha

            var passwordHash = _authService.ComputSha256Hash(request.Password);

            //buscar no banco os dados[
            var user = await _userRepository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);

            //se não existir: erro no login
            if (user == null)
            {
                return null;
            }

            //se existir, gera o token de dados do usuario
            var token = _authService.GenerateJwtToken(user.Email, user.Role);

            return new LoginUserViewModel(user.Email, token);


        }
    }
}
