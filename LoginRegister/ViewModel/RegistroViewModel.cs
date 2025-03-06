using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoginRegister.Helpers;
using LoginRegister.Interface;
using LoginRegister.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace LoginRegister.ViewModel
{
    public partial class RegistroViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private string _userName;

        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private string _password;

        [ObservableProperty]
        private string _dni;

        [ObservableProperty]
        private string _apellido;

        [ObservableProperty]
        private string _curso;

        [ObservableProperty]
        private string _idDepartamento;

        [ObservableProperty]
        private string[] _opciones;

        private string _opcionSeleccionada;

        [ObservableProperty]
        private Visibility _esAlumno = Visibility.Collapsed;

        [ObservableProperty]
        private Visibility _esProfesor = Visibility.Collapsed;



        public LoginViewModel LoginViewModel { get; }

        private readonly IHttpJsonProvider<UserDTO> _httpJsonProvider;
        private readonly IHttpJsonProvider<AlumnoDTO> _httpJsonProviderAlumno;
        private readonly IHttpJsonProvider<ProfesorDTO> _httpJsonProviderProfesor;

        public RegistroViewModel(IHttpJsonProvider<UserDTO> httpJsonProvider, IHttpJsonProvider<AlumnoDTO> httpJsonProviderAlumno, IHttpJsonProvider<ProfesorDTO> httpJsonProviderProfesor, LoginViewModel loginViewModel)
        {
            _httpJsonProvider = httpJsonProvider;
            _httpJsonProviderAlumno = httpJsonProviderAlumno;
            _httpJsonProviderProfesor = httpJsonProviderProfesor;

            LoginViewModel = loginViewModel;
            Opciones = Constants.OPCIONES_REGISTRO;
        }


        public string OpcionSeleccionada
        {
            get => _opcionSeleccionada;
            set
            {
                if (_opcionSeleccionada != value)
                {
                    _opcionSeleccionada = value;
                    CambiarVisibility();
                }
            }
        }


        public void CambiarVisibility()
        {
            if (OpcionSeleccionada == "Alumno")
            {
                EsAlumno = Visibility.Visible;
                EsProfesor = Visibility.Collapsed;
            }
            else
            {
                EsAlumno = Visibility.Collapsed;
                EsProfesor = Visibility.Visible;
            }
        }


        [RelayCommand]
        public async Task Registro()
        {
            if (string.IsNullOrEmpty(Name) ||
                string.IsNullOrEmpty(UserName) ||
                string.IsNullOrEmpty(Email) ||
                string.IsNullOrEmpty(Password) ||
                string.IsNullOrEmpty(Dni) ||
                string.IsNullOrEmpty(Apellido) ||
                string.IsNullOrEmpty(OpcionSeleccionada) ||
                (OpcionSeleccionada == Constants.OPCIONES_REGISTRO[0] && string.IsNullOrEmpty(Curso)) ||
                (OpcionSeleccionada == Constants.OPCIONES_REGISTRO[1] && string.IsNullOrEmpty(IdDepartamento)))
            {
                MessageBox.Show("Por favor, rellene todos los campos.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            UserRegistroDTO userRegistroDTO = new()
            {
                Name = Name,
                UserName = UserName,
                Email = Email,
                Password = Password,
                Role = "user"
            };

            try
            {
                UserDTO user = await _httpJsonProvider.RegisterPostAsync(Constants.REGISTER_PATH, userRegistroDTO);

                //bool postAlumno = false;
                //bool postProfesor = false;

                if (user != null && user.IsSuccess)
                {
                    if (OpcionSeleccionada == Constants.OPCIONES_REGISTRO[0])
                    {
                        AlumnoDTO alumnoDTO = new()
                        {
                            DNI = int.Parse(Dni),
                            Nombre = Name,
                            Apellido = Apellido,
                            Curso = Curso,
                            Prof_Asociado = ""
                        };

                        AlumnoDTO alumno = await _httpJsonProviderAlumno.PostAsync(Constants.ALUMNO_PATH, alumnoDTO);

                        //if (alumno != null) postAlumno = true;
                    }

                    if (OpcionSeleccionada == Constants.OPCIONES_REGISTRO[1])
                    {
                        ProfesorDTO profesorDTO = new()
                        {
                            DNI = Dni,
                            Nombre = Name,
                            Apellido = Apellido,
                            ID_Departamento = int.Parse(IdDepartamento)
                            
                        };

                        ProfesorDTO profesor = await _httpJsonProviderProfesor.PostAsync(Constants.PROFESOR_PATH, profesorDTO);
                        //if (profesor != null) postProfesor = true;
                    }

                    App.Current.Services.GetService<MainViewModel>().SelectedViewModel = App.Current.Services.GetService<MainViewModel>().LoginViewModel;
                }
                //if (postAlumno || postAlumno)
                //{
                //    
                //}
                else
                {
                    MessageBox.Show($"Ocurrió un error durante el registro", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error durante el registro: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}


