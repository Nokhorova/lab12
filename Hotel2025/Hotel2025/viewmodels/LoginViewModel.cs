using HotelProgram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HotelProgram.Repositories;
using System.Net;
using System.Threading;
using System.Security.Principal;
using HotelProgram.Views;
using System.Windows;

namespace HotelProgram.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        //Поля
        private string _username;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true;
        private IUserRepository userRepository;
        private static User _authenticatedUser;

        //Свойства
        public string Username
        {
            get
            {
                return _username;
            }

            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public SecureString Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        public bool IsViewVisible
        {
            get
            {
                return _isViewVisible;
            }
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }
        // -> Command
        
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }
        public ICommand LoginCommand { get; }
        //Конструктор
        public LoginViewModel()
        {
            userRepository = new UserRepository();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordCommand = new ViewModelCommand(p => ExecuteRecoverPassCommand("", ""));
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            return !string.IsNullOrWhiteSpace(Username) && Username.Length >= 3 &&
               Password != null && Password.Length >= 3;
        }
        public void ExecuteLoginCommand(object obj)
        {
            var isValidUser = userRepository.AuthenticateUser(new NetworkCredential(Username, Password));
            if (isValidUser)
            {

                _authenticatedUser = userRepository.GetByUsername(Username);
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(Username), null);

                IsViewVisible = false;
            }
            else
            {
                ErrorMessage = "* Неверно введен логин или пароль";
            }
        }
        public static User GetAuthenticatedUser()
        {
            return _authenticatedUser;
        }
        private void ExecuteRecoverPassCommand(string username, string email)
        {
            throw new NotImplementedException();
        }

    }
}
