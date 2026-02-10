namespace SistemaBancarioV2.Entidades
{
    public class ContaCorrente : ContaBancaria
    {
        public ContaCorrente(int numero, string titular)
            : base(numero, titular)
        {
        }

        public override string TipoConta()
        {
          
            return "Conta Corrente";
        }

    }
}

