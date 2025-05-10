using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Teste.Servicos
{
    public class RegistroAppServico
    {
        private RegistryHive registry_hive;
        private RegistryView registry_view;
        public RegistroAppServico(RegistryHive registry_hive, RegistryView registry_view)
        {
            this.registry_hive = registry_hive;
            this.registry_view = registry_view;
        }

        public bool EscreveValorRegistro(string endereco_subchave, string nome_valor, object valor, RegistryValueKind registry_value_kind)
        {
            RegistryKey subchave = null;

            try
            {
                RegistryKey chave_base = RegistryKey.OpenBaseKey(registry_hive, registry_view);
                chave_base.CreateSubKey(endereco_subchave);
                subchave = chave_base.OpenSubKey(endereco_subchave, true);

                if (subchave == null)
                {
                    return false;
                }

                subchave.SetValue(nome_valor, valor, registry_value_kind);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (subchave != null)
                {
                    subchave.Close();
                }
            }
        }
    }
}

