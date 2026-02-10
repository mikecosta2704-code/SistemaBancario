using Microsoft.AspNetCore.Mvc;
using SistemaBancario.Api.DTOs;
using SistemaBancarioV2.Servicos;

[ApiController]
[Route("api/[controller]")]
public class ContaController : ControllerBase
{
    private readonly BancoService _bancoService;

    public ContaController(BancoService bancoService)
    {
        _bancoService = bancoService;
    }

    // 🔹 Criar conta (você já tinha)
    [HttpPost]
    public IActionResult CriarConta([FromBody] CriarContaDto dto)
    {
        if (dto == null)
            return BadRequest("Dados inválidos.");

        bool criado = _bancoService.CriarConta(
            dto.Numero,
            dto.Titular,
            dto.Tipo
        );

        if (!criado)
            return BadRequest("Conta já existe ou tipo inválido.");

        return Ok("Conta criada com sucesso.");
    }

    // 🔹 Depositar
    [HttpPost("{numero}/depositar")]
    public IActionResult Depositar(int numero, [FromBody] double valor)
    {
        bool ok = _bancoService.Depositar(numero, valor);

        if (!ok)
            return BadRequest("Conta não encontrada ou valor inválido.");

        return Ok("Depósito realizado com sucesso.");
    }

    // 🔹 Sacar
    [HttpPost("{numero}/sacar")]
    public IActionResult Sacar(int numero, [FromBody] double valor)
    {
        bool ok = _bancoService.Sacar(numero, valor);

        if (!ok)
            return BadRequest("Conta não encontrada ou saldo insuficiente.");

        return Ok("Saque realizado com sucesso.");
    }

    // 🔹 Ver saldo
    [HttpGet("{numero}/saldo")]
    public IActionResult Saldo(int numero)
    {
        var saldo = _bancoService.ObterSaldo(numero);

        if (saldo == null)
            return NotFound("Conta não encontrada.");

        return Ok(saldo);
    }

    // 🔹 Ver extrato
    [HttpGet("{numero}/extrato")]
    public IActionResult Extrato(int numero)
    {
        var extrato = _bancoService.ObterExtrato(numero);

        if (extrato == null)
            return NotFound("Conta não encontrada.");

        return Ok(extrato);
    }
}


