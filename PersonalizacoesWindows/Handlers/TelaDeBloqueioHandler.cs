using System;
using Microsoft.Win32;
using Teste.Servicos;
using System.IO;

namespace Teste.Handlers
{
    public class TelaDeBloqueioHandler
    {
        public string caminhoimagem;
        public TelaDeBloqueioHandler(string caminhoimagem)
        {
            this.caminhoimagem = caminhoimagem;
        }
        public void Executa()
        {
            try
            {
                ExisteArquivo();
                CriaChave();
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
        public void CriaChave()
        {
            RegistroAppServico registro = new RegistroAppServico(RegistryHive.LocalMachine, RegistryView.Registry64);
            registro.EscreveValorRegistro(@"SOFTWARE\Microsoft\Windows\CurrentVersion\PersonalizationCSP", "LockScreenImagePath", caminhoimagem, RegistryValueKind.String);
            registro.EscreveValorRegistro(@"SOFTWARE\Microsoft\Windows\CurrentVersion\PersonalizationCSP", "LockScreenImageUrl", caminhoimagem, RegistryValueKind.String);
            registro.EscreveValorRegistro(@"SOFTWARE\Microsoft\Windows\CurrentVersion\PersonalizationCSP", "LockScreenImageStatus", "1", RegistryValueKind.DWord);
        }
    }
}
