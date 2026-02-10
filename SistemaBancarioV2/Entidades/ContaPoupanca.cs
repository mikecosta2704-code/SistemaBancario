namespace SistemaBancarioV2.Entidades
{
    public class ContaPoupanca : ContaBancaria
    {
        public ContaPoupanca(int numero, string titular)
            : base(numero, titular)
        {
        }

        public override string TipoConta()
        {
            return "Conta Poupança";
        }

        public override void VirarMes()
        {
            double rendimento = Saldo * 0.005;
            Saldo += rendimento;
            Historico.Add($"Rendimento mensal: +{rendimento}");
        }
    }
}

