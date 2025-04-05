using Giro.Animes.Application.DTOs;
using Giro.Animes.Application.Interfaces.Services;
using Giro.Animes.Application.Mappers;
using Giro.Animes.Application.Requests.User;
using Giro.Animes.Application.Services.Base;
using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Enums;
using Giro.Animes.Domain.Interfaces.Services;
using Giro.Animes.Domain.ValueObjects;
using Giro.Animes.Infra.Interfaces;

namespace Giro.Animes.Application.Services
{
    public class UserService : ApplicationServiceBase<IUserDomainService>, IUserService
    {
        private readonly ILanguageDomainService _languageDomainService;

        public UserService(IApplicationUser applicationUser, IUserDomainService domainService, INotificationService notificationService, ILanguageDomainService languageDomainService) :
            base(applicationUser, notificationService, domainService)
        {
            _languageDomainService = languageDomainService;
        }

        public async Task<UserDTO> GetUserAndAccountByUserIdAsync(long userId)
        {
            User user = await _domainService.GetUserAndAccountById(userId);
            UserDTO userDTO = user?.Map();

            return userDTO;
        }

        public async Task<UserDTO> CreateUserAsync(UserCreateRequest request)
        {
            // Cria as tasks para obter o idioma da interface e os idiomas favoritos
            Language interfaceLanguage = await _languageDomainService.GetLanguageByCode();
            IEnumerable<Language> favoriteLanguages = await _languageDomainService.GetLanguagesByCodes(_applicationUser.Languages);

            // Cria as configurações do usuário
            Settings settings = Settings.Create(interfaceLanguage, favoriteLanguages);

            // Cria os objetos de valor para senha e email
            Password password = Password.Create(request.Password, request.ConfirmPassword);
            Email email = Email.Create(request.Email);

            // Cria a conta do usuário
            Account account = Account.Create(email, password, settings);

            // Cria o usuário com status inativo
            User user = User.Create(request.Name, UserStatus.Inactive, account);

            // Chama o serviço de domínio para demais validações e persistência
            EntityResult<User> resultUser = await _domainService.CreateUser(user);

            if (!resultUser.IsValid)
            {
                // Adiciona as notificações de erro
                await _notificationService.AddNotification(resultUser.Errors);
                return null;
            }


            // Mapeia o usuário para UserDTO e retorna
            return user?.Map();
        }
    }
}
