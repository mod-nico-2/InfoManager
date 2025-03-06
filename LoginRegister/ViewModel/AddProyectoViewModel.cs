using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoginRegister.Helpers;
using LoginRegister.Interface;
using LoginRegister.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace LoginRegister.ViewModel
{
    public partial class AddProyectoViewModel : ViewModelBase
    {

        [ObservableProperty]
        private string _nombre;

        [ObservableProperty]
        private string _descripcion;


        private readonly IHttpJsonProvider<ProyectoDTO> _httpJsonProvider;
       

        public AddProyectoViewModel(IHttpJsonProvider<ProyectoDTO> httpJsonProvider)
        {
            _httpJsonProvider = httpJsonProvider;          
        }

        [RelayCommand]
        public async Task Add()
        {
            if (string.IsNullOrEmpty(Nombre) ||
                string.IsNullOrEmpty(Descripcion))
            {
                MessageBox.Show("Por favor, rellene todos los campos.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            ProyectoDTO proyectoDTO = new()
            {
                Dni_Creador = "111",
                Dni_Prof_Asociado = "111",
                Nombre = Nombre,
                Descripcion = Descripcion,
                Status = "PENDIENTE",
                Fecha = DateTime.Now,
                ID_Departamento = 0,
                Fecha_Presentacion = DateTime.Now,
                Aula_Presentacion = "111"
            };

            try
            {
                ProyectoDTO respuesta = await _httpJsonProvider.PostAsync(Constants.PROYECTO_PATH, proyectoDTO);

                if (respuesta != null)
                {
                    MessageBox.Show("Proyecto añadido con exito");
                    App.Current.Services.GetService<MainViewModel>().LoadAsync();
                }
                 
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error durante el registro: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}


