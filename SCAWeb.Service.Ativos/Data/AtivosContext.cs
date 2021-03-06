﻿using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using SCAWeb.Service.Ativos.Entities;

namespace SCAWeb.Service.Ativos.Data
{
    public class AtivosContext : DbContext
    {
        public AtivosContext(DbContextOptions<AtivosContext> options)
            : base(options)
        {
        }

        public DbSet<InsumoEntity> Insumos { get; set; }
        public DbSet<TipoInsumoEntity> TipoInsumo { get; set; }
        public DbSet<FornecedorEntity> Fornecedor { get; set; }
        public DbSet<ManutencaoEntity> Manutencao { get; set; }
        public DbSet<AgendaManutencaoEntity> AgendaManutencao { get; set; }
        //  public DbSet<UserAccount> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            modelBuilder.Entity<InsumoEntity>().ToTable("Insumos");
            modelBuilder.Entity<InsumoEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<InsumoEntity>().Property(x => x.user).IsRequired();
            modelBuilder.Entity<InsumoEntity>().Property(x => x.descricao_insumo).HasMaxLength(100).HasColumnType("varchar(100)").IsRequired();
            modelBuilder.Entity<InsumoEntity>().Property(x => x.status_insumo).IsRequired();
          //  modelBuilder.Entity<InsumoEntity>().Property(x => x.data_manut_prev).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<InsumoEntity>().Property(x => x.data_aquisicao).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<InsumoEntity>().Property(x => x.data_atualizacao).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<InsumoEntity>().Property(x => x.qtd_dias_manut_prev).IsRequired();
            modelBuilder.Entity<InsumoEntity>().Property(x => x.id_tipo_insumo).IsRequired();
            modelBuilder.Entity<InsumoEntity>().Property(x => x.id_fornec_insumo).IsRequired();

            modelBuilder.Entity<TipoInsumoEntity>().ToTable("TipoInsumo");
            modelBuilder.Entity<TipoInsumoEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<TipoInsumoEntity>().Property(x => x.user).IsRequired();
            modelBuilder.Entity<TipoInsumoEntity>().Property(x => x.descricao_tp_insumo).HasMaxLength(100).HasColumnType("varchar(100)").IsRequired();
            modelBuilder.Entity<TipoInsumoEntity>().Property(x => x.data_atualizacao).HasColumnType("datetime").IsRequired();

            modelBuilder.Entity<FornecedorEntity>().ToTable("Fornecedor");
            modelBuilder.Entity<FornecedorEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<FornecedorEntity>().Property(x => x.user).IsRequired();
            modelBuilder.Entity<FornecedorEntity>().Property(x => x.cnpj_fornecedor).IsRequired();
            modelBuilder.Entity<FornecedorEntity>().Property(x => x.nome_fantasia).IsRequired();
            modelBuilder.Entity<FornecedorEntity>().Property(x => x.razao_social).IsRequired();
            modelBuilder.Entity<FornecedorEntity>().Property(x => x.data_atualizacao).HasColumnType("datetime").IsRequired();

            modelBuilder.Entity<ManutencaoEntity>().ToTable("Manutencao");
            modelBuilder.Entity<ManutencaoEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<ManutencaoEntity>().Property(x => x.user).IsRequired();
            modelBuilder.Entity<ManutencaoEntity>().Property(x => x.tipo_manutencao).IsRequired();
            modelBuilder.Entity<ManutencaoEntity>().Property(x => x.descricao_manutencao).IsRequired();
            modelBuilder.Entity<ManutencaoEntity>().Property(x => x.status_manutencao).IsRequired();
            modelBuilder.Entity<ManutencaoEntity>().Property(x => x.data_inicio).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<ManutencaoEntity>().Property(x => x.data_fim).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<ManutencaoEntity>().Property(x => x.id_insumo).IsRequired();

            modelBuilder.Entity<AgendaManutencaoEntity>().ToTable("AgendaManutencao");
            modelBuilder.Entity<AgendaManutencaoEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<AgendaManutencaoEntity>().Property(x => x.user).IsRequired();
            modelBuilder.Entity<AgendaManutencaoEntity>().Property(x => x.tipo_manutencao).IsRequired();
            modelBuilder.Entity<AgendaManutencaoEntity>().Property(x => x.status_agenda).IsRequired();
            modelBuilder.Entity<AgendaManutencaoEntity>().Property(x => x.data_manutencao).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<AgendaManutencaoEntity>().Property(x => x.data_atualizacao).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<AgendaManutencaoEntity>().Property(x => x.id_insumo).IsRequired();

            //modelBuilder.Entity<UserAccount>().ToTable("Users");
            //modelBuilder.Entity<UserAccount>().HasKey(x => x.Id);
            //modelBuilder.Entity<UserAccount>().Property(x => x.User).HasMaxLength(100).HasColumnType("varchar(100)").IsRequired();
            //modelBuilder.Entity<UserAccount>().Property(x => x.usuario_ativo).HasColumnType("bit").IsRequired();
            //modelBuilder.Entity<UserAccount>().HasIndex(b => b.User);
        }

    }
}
