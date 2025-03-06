using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoginRegister.Helpers;
using LoginRegister.Interface;
using LoginRegister.Models;
using LoginRegister.Services;
using LoginRegister.View;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Reflection.Metadata;
using System.Windows;
using System.Windows.Controls;

namespace LoginRegister.ViewModel;

public partial class DashboardViewModel : ViewModelBase
{
    private readonly IHttpJsonProvider<ProyectoDTO> _httpJsonProvider;
    private readonly AddProyectoViewModel _addProyectoViewModel;

    public DashboardViewModel(IHttpJsonProvider<ProyectoDTO> httpJsonProvider, AddProyectoViewModel addProyectoViewModel)
    {
        _httpJsonProvider = httpJsonProvider;
        _addProyectoViewModel = addProyectoViewModel;

        _proyectos = new List<ProyectoDTO>();
        PagedProyectos = new ObservableCollection<ProyectoDTO>();

        ItemsPerPage = 5; 
        CurrentPage = 0; 
    }

    private List<ProyectoDTO> _proyectos; 

    [ObservableProperty]
    private ObservableCollection<ProyectoDTO> pagedProyectos;

    [ObservableProperty]
    private int currentPage; 

    [ObservableProperty]
    private int itemsPerPage; 

    public int TotalPages => (int)Math.Ceiling((double)_proyectos.Count / ItemsPerPage);

 
    public override async Task LoadAsync()
    {
        try
        {

            _proyectos.Clear();
            PagedProyectos.Clear();


            IEnumerable<ProyectoDTO> listaProyectos = await _httpJsonProvider.GetAsync(Constants.PROYECTO_PATH);
            _proyectos.AddRange(listaProyectos.OrderBy(d => d.Id));

          
            CurrentPage = 0;
            UpdatePagedList();
        }
        catch (Exception ex)
        {
            
            Console.WriteLine($"Error al cargar datos: {ex.Message}");
        }
    }

   
    private void UpdatePagedList()
    {

        PagedProyectos.Clear();

        var pagedItems = _proyectos.Skip(CurrentPage * ItemsPerPage).Take(ItemsPerPage).ToList();
        foreach (var item in pagedItems)
        {
            PagedProyectos.Add(item);
        }
    }

    [RelayCommand]
    public async Task AddProyecto()
    {
        var addProyectoWindow = new AddProyectoView();

        var addProyectoViewModel = App.Current.Services.GetService<AddProyectoViewModel>();
        addProyectoWindow.DataContext = addProyectoViewModel;
        addProyectoWindow.ShowDialog();       
        await LoadAsync();
    }


    [RelayCommand]
    public async Task Logout() 
    {
        App.Current.Services.GetService<LoginDTO>().Token = "";
        App.Current.Services.GetService<MainViewModel>().SelectedViewModel = App.Current.Services.GetService<MainViewModel>().LoginViewModel;
    }

    [RelayCommand]
    public void PreviousPage()
    {
        if (CurrentPage > 0)
        {
            CurrentPage--;
            UpdatePagedList();
        }
    }

    [RelayCommand]
    public void NextPage()
    {
        if (CurrentPage < TotalPages - 1)
        {
            CurrentPage++;
            UpdatePagedList();
        }
    }


    private ProyectoDTO _proyectoSeleccionado;
    public ProyectoDTO ProyectoSeleccionado
    {
        get => _proyectoSeleccionado;
        set
        {
            _proyectoSeleccionado = value;
        }
    }

    [RelayCommand]
    public async Task Delete()
    {

        if (_proyectoSeleccionado is ProyectoDTO)
        {

            if (await _httpJsonProvider.Delete($"{Constants.PROYECTO_PATH}", _proyectoSeleccionado.Id))
            {
                LoadAsync();
            }
            else
            {
                MessageBox.Show("Error", "Error al borrar", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }

    /*
    public async void  MyDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
    {
        if (e.Row.Item is ProyectoDTO proyectoDTO)
        {
           await _dicatadorServiceToApi.PutDicatador(dicatadorDTO);
        }
    }
    */

    private bool CanGoToPreviousPage() => CurrentPage > 0;

    private bool CanGoToNextPage() => CurrentPage < TotalPages - 1;
}

