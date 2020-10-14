﻿using Flunt.Validations;
using System;

namespace SCAWeb.Service.Ativos.Entities
{
    public class InsumoEntity : Entity, IValidatable
    {
        public InsumoEntity()
        {

        }

        public InsumoEntity(string descricaoInsumo, string statusInsumo, DateTime dataManutPrev, 
            DateTime dataAquisicao, DateTime dataAtualizacao, int qtdDiasManutPrev, string tipoInsumo, string fornecInsumo, string User)
        {
            descricao_insumo = descricaoInsumo;
            status_insumo = statusInsumo;
            data_manut_prev = dataManutPrev;
            data_aquisicao = dataAquisicao;
            data_atualizacao = dataAtualizacao;
            qtd_dias_manut_prev = qtdDiasManutPrev;
            tipo_insumo = tipoInsumo;
            fornec_insumo = fornecInsumo;
            user = User;
        }

        public string descricao_insumo { get; private set; }
        public string status_insumo { get; private set; }
        public DateTime data_manut_prev { get; private set; }
        public DateTime data_aquisicao { get; private set; }
        public DateTime data_atualizacao { get; private set; }
        public int qtd_dias_manut_prev { get; private set; }
        public string tipo_insumo { get; private set; }
        public string fornec_insumo { get; private set; }
        public string user { get; private set; }

        public void UpdateInsumo(string descricaoInsumo, string statusInsumo, DateTime dataManutPrev, 
            DateTime dataAtualizacao, string User)
        {
            descricao_insumo = descricaoInsumo;
            status_insumo = statusInsumo;
            data_manut_prev = dataManutPrev;
            data_atualizacao = dataAtualizacao;
            user = User;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(descricao_insumo, "Descrição do Insumo", "Favor informar a Descrição do Insumo.")
                    .IsNotNullOrEmpty(status_insumo, "Status do Insumo", "Favor informar o Status do Insumo.")
                    .IsNotNull(data_manut_prev, "Manutenção Preventiva", "Favor informar a data da Manutenção Preventiva.")
                    .IsNotNull(data_aquisicao, "Data Aquisição", "A data de aquisição do Insumo não pode ser vazia.")
                    .IsNotNull(data_atualizacao, "Data Atualização", "A data de atualização do Insumo não pode ser vazia.")
                    .IsNotNull(qtd_dias_manut_prev, "Dias Manutenção Preventiva", "A quantidade de dias da Manutenção Preventiva não pode ser vazia.")
                    .IsGreaterThan(data_manut_prev, data_manut_prev.AddDays(qtd_dias_manut_prev), "Manutenção Preventida", "A data da Manutenção preventiva deve ser maior que a informada.")
                    .HasMaxLen(descricao_insumo, 100, "Descrição do Insumo", "A Descrição do Insumo deve conter no máximo 100 caracteres.")
            );
        }
    }
}