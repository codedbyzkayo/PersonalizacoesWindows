using System;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using Teste.Servicos;

namespace Teste.Handlers
{
    public class PlanoDeFundoHandler
    {
        public string caminhoimagem;
        public PlanoDeFundoHandler(string caminhoimagem)
        {
            this.caminhoimagem = caminhoimagem;
        }
        public void Executa()
        {
            try
            {
                ExisteArquivo();
                CriaChave();
                AtualizaWallpaper();
            }
            catch (Exception ex)
            {
                // Log de exceção
            }
        }
        private void ExisteArquivo()
        {
            if (!File.Exists(caminhoimagem))
            {
                throw new FileNotFoundException("O arquivo especificado não existe.", caminhoimagem);
            }
        }
        private void CriaChave()
        {
            RegistroAppServico registro = new RegistroAppServico(RegistryHive.CurrentUser, RegistryView.Registry64);
            registro.EscreveValorRegistro(@"Control Panel\Desktop", "Wallpaper", caminhoimagem, RegistryValueKind.String);
            registro.EscreveValorRegistro(@"Control Panel\Desktop", "WallpaperStyle", "6", RegistryValueKind.String);
            registro.EscreveValorRegistro(@"Control Panel\Desktop", "TileWallpaper", "0", RegistryValueKind.String);
        }
        private void AtualizaWallpaper()
        {
            SystemParametersInfo(20, 0, caminhoimagem, 0x01 | 0x02);
        }


        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
    }
}
