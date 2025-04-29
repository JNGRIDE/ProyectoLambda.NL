using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLambda.Services.Interface
{
    public interface IDisplayService
    {
        Task ShowActionAlertAsync(string title, string message, string cancel);
        Task<string> ShowActionPromptAsync(
            string title, string message, string okText, string cancelText,
            string placeholder, int maxLength = -1, string initialValue = null);
        Task Mostrar(string mensaje, string textoBoton = "OK", int duracion = 3000);
        Task<string> ShowActionSheetAsync(string title, string ok, string destruction, params string[] buttons);

    }
}
