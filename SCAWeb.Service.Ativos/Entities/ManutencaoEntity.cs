﻿using Flunt.Notifications;
using Flunt.Validations;
using SCAWeb.Service.Ativos.Util.Enums;
using System;

namespace SCAWeb.Service.Ativos.Entities
{
    public class ManutencaoEntity : Notifiable, IValidatable
    {
        public ManutencaoEntity()
        {

        }

        public ManutencaoEntity(TipoManutencao tipoManutencao, string descricaoManutencao, StatusManutencao statusManutencao, 
            DateTime dataInicio, DateTime dataFim, Guid idInsumo, string User)
        {
            Id = Guid.NewGuid();
            tipo_manutencao = tipoManutencao;
            descricao_manutencao = descricaoManutencao;
            status_manutencao = statusManutencao;
            data_inicio = dataInicio;
            data_fim = dataFim;
            id_insumo = idInsumo;
            user = User;
        }

        public Guid Id { get; set; }
        public TipoManutencao tipo_manutencao { get; set; } //preenchido automaticamente (vem da tabela de agendamento)
        public string descricao_manutencao { get; set; }
        public StatusManutencao status_manutencao { get; set; }
        public DateTime data_inicio { get; set; }
        public DateTime data_fim { get; set; }
        public Guid id_insumo { get; set; }
        public string user { get; set; }

        public void UpdateManutencao(string descricaoManutencao, StatusManutencao statusManutencao, DateTime dataFim, string User)
        {
            descricao_manutencao = descricaoManutencao;
            status_manutencao = statusManutencao;
            data_fim = dataFim;
            user = User;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(descricao_manutencao, "Descrição da Manutenção", "Favor informar uma descrição para a manutenção.")
                    .IsNotNull(tipo_manutencao, "Tipo Manutenção", "O tipo da manutenção não pode ser vazio.")
                    .IsNotNull(id_insumo, "Insumo", "Favor informar o Insumo a ser feito a manutenção.")
             );
        }
    }
}
