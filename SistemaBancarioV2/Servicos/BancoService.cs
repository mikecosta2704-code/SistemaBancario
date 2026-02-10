using SistemaBancarioV2.Entidades;

namespace SistemaBancarioV2.Servicos
{
    public class BancoService
    {
        private readonly List<ContaBancaria> _contas = new();

        public bool CriarConta(int numero, string titular, int tipo)
        {
            if (_contas.Any(c => c.Numero == numero))
                return false;

            ContaBancaria conta;

            if (tipo == 1)
                conta = new ContaCorrente(numero, titular);
            else if (tipo == 2)
                conta = new ContaPoupanca(numero, titular);
            else
                return false;

            _contas.Add(conta);
            return true;
        }

        public bool Depositar(int numero, double valor)
        {
            var conta = _contas.FirstOrDefault(c => c.Numero == numero);
            if (conta == null) return false;

            return conta.Depositar(valor);
        }

        public bool Sacar(int numero, double valor)
        {
            var conta = _contas.FirstOrDefault(c => c.Numero == numero);
            if (conta == null) return false;

            return conta.Sacar(valor);
        }

        public double? ObterSaldo(int numero)
        {
            var conta = _contas.FirstOrDefault(c => c.Numero == numero);
            return conta?.Saldo;
        }

        public List<string>? ObterExtrato(int numero)
        {
            var conta = _contas.FirstOrDefault(c => c.Numero == numero);
            return conta?.Historico;
        }
    }
}



