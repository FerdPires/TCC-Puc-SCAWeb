﻿using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace SCAWeb.Service.Ativos.Entities
{
    public class TipoInsumoEntity : Notifiable, IValidatable
    {
        public TipoInsumoEntity()
        {

        }

        public TipoInsumoEntity(string descricaoTpInsumo, DateTime dataAtualizacao, string User)
        {
            Id = Guid.NewGuid();
            descricao_tp_insumo = descricaoTpInsumo;
         //   qtd_dias_manut_prev = qtdDiasManutPrev;
            data_atualizacao = dataAtualizacao;
            user = User;
        }

        public Guid Id { get; set; }
        public string descricao_tp_insumo { get; set; }
       // public int qtd_dias_manut_prev { get; private set; }
        public DateTime data_atualizacao { get; set; }
        public string user { get; set; }

        public void UpdateTipoInsumo(string descricaoTpInsumo, DateTime dataAtualizacao, string User)
        {
            descricao_tp_insumo = descricaoTpInsumo;
            data_atualizacao = dataAtualizacao;
            user = User;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(descricao_tp_insumo, "Tipo Insumo", "Favor informar o Tipo do Insumo.")
                     //    .IsNotNull(qtd_dias_manut_prev, "Dias Manutenção Preventiva", "Favor informar a quantidade de dias da Manutenção Preventiva.")
                    .HasMaxLen(descricao_tp_insumo, 100, "Tipo Insumo", "O Tipo do Insumo deve conter no máximo 100 caracteres.")
            );
        }
    }
}
