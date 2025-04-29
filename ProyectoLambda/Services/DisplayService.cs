using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System;
using System.Threading.Tasks;
using ProyectoLambda.Services.Interface;

namespace ProyectoLambda.Services
{
    public class DisplayService : IDisplayService
    {
        public async Task ShowActionAlertAsync(string title, string message, string cancel)
        {
            if (Application.Current?.MainPage is not Page page)
                throw new InvalidOperationException("MainPage no está inicializada");
            await page.DisplayAlert(title, message, cancel);
        }

        public async Task<string> ShowActionPromptAsync(
            string title, string message, string okText, string cancelText, 
            string placeholder, int maxLength = -1, string initialValue = null)
        {
            if (Application.Current?.MainPage is not Page page)
                throw new InvalidOperationException("MainPage no está inicializada");

            return await page.DisplayPromptAsync(
                title: title, message: message,
                accept: okText, cancel: cancelText,
                placeholder: placeholder,
                initialValue: initialValue
            );

        }

        public async Task<string> ShowActionSheetAsync(
            string title, string cancel, string destruction, params string[] buttons)
        {
            if (Application.Current?.MainPage is not Page page)
                throw new InvalidOperationException("MainPage no está inicializada");

            return await page.DisplayActionSheet(title, cancel, destruction, buttons);
        }

        public async Task Mostrar(string mensaje, string textoBoton = "OK", int duracion = 3000)
        {

            var iconoLabel = new Label
            {
                Text = "\uf05a", // Código del icono de info de FontAwesome
                FontFamily = "FontAwesome",
                FontSize = 24,
                TextColor = Colors.Blue, // Azul estilo Epic Games
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 0, 16, 0)
            };

            var mensajeLabel = new Label
            {
                Text = mensaje,
                TextColor = Colors.White,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            var horizontalStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { iconoLabel, mensajeLabel }
            };

            var contenidoPersonalizado = new ContentView
            {
                Content = horizontalStack,
                Padding = new Thickness(16, 8, 16, 8)
            };

            // Configurar opciones del Snackbar
            var opciones = new SnackbarOptions
            {
                BackgroundColor = Colors.Firebrick, // Gris oscuro estilo Epic
                CornerRadius = new CornerRadius(8)
            };

            // Crear y mostrar el Snackbar
            var snackbar =  Snackbar.Make(
                "¡Hola Mundo!",
                null,
                "OK",
                TimeSpan.FromSeconds(3),
                visualOptions: opciones);

            await snackbar.Show();

        }
    }    
}
