using System;
using System.Collections.Generic;

namespace SistemaBancarioV2.Entidades
{
    public abstract class ContaBancaria
    {
        public int Numero { get; }
        public string Titular { get; }
        public double Saldo { get; protected set; }

        public List<string> Historico { get; } = new();

        protected ContaBancaria(int numero, string titular)
        {
            Numero = numero;
            Titular = titular;
            Saldo = 0;
        }

        public virtual bool Depositar(double valor)
        {
            if (valor <= 0) return false;

            Saldo += valor;
            Historico.Add($"Depósito: +{valor}");
            return true;
        }

        public virtual bool Sacar(double valor)
        {
            if (valor <= 0 || valor > Saldo) return false;

            Saldo -= valor;
            Historico.Add($"Saque: -{valor}");
            return true;
        }

        public abstract string TipoConta();

        public virtual void VirarMes()
        {
            // comportamento padrão (nada)
        }
    }
}


