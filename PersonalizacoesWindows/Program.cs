using System;
using Teste.Servicos;

namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            string caminhoimagem = @"C:\Users\User\Desktop\2560x1440-black-solid-color-background.jpg";
            WallpaperAppServico.PlanoDeFundo(caminhoimagem);
            WallpaperAppServico.TelaDeBloqueio(caminhoimagem);
        }
    }
}