namespace Teste.Servicos
{
    public static class WallpaperAppServico
    {
        public static void PlanoDeFundo(string caminhoimagem)
        {
            new Handlers.PlanoDeFundoHandler(caminhoimagem).Executa();
        }

        public static void TelaDeBloqueio(string caminhoimagem)
        {
            new Handlers.TelaDeBloqueioHandler(caminhoimagem).Executa();
        }
    }
}