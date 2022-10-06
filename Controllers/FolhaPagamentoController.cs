using System.Collections.Generic;
using System.Linq;
using API_Folhas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Folhas.Controllers
{
    [ApiController]
    [Route("api/folha")]
    public class FolhaPagamentoController : ControllerBase
    {
        private readonly DataContext _context;

        //Injeção de dependência - balta.io
        public FolhaPagamentoController(DataContext context) =>
            _context = context;

        
        // POST: /api/folha/cadastrar
        [Route("cadastrar")]
        [HttpPost]
        public IActionResult Cadastrar([FromBody] FolhaPagamento folha)
        {
            var salario_bruto = folha.QuantidadedeHoras * folha.ValorHora;

            //validando se o funcionário do id passado existe mesmo

            Funcionario funcionario = _context.Funcionarios.FirstOrDefault
            (
                f => f.FuncionarioId.Equals(folha.FuncionarioId)
            );
            if (funcionario == null)
            {
                return NotFound();
            }
            else
            {
                //calculando imposto de renda

            if(salario_bruto < 1903.98)
            {
                folha.ImpostoRenda = 0;
            }
            else if(salario_bruto < 2826.65)
            {
                folha.ImpostoRenda = (salario_bruto * 0.075) - 142.80;
            }
            else if(salario_bruto < 3751.05)
            {
                folha.ImpostoRenda = (salario_bruto * 0.15) - 354.80;
            }
            else if(salario_bruto < 4664.68)
            {
                folha.ImpostoRenda = (salario_bruto * 0.225) - 636.13;
            }
            else
            {
                folha.ImpostoRenda = (salario_bruto * 0.275) - 869.36;
            }


            //calculo INSS
            if(salario_bruto < 1693.72)
            {
                folha.ImpostoInss = salario_bruto * 0.08;
            }
            else if(salario_bruto < 2822.9)
            {
                folha.ImpostoInss = salario_bruto * 0.09;
            }
            else if(salario_bruto < 5645.80)
            {
                folha.ImpostoInss = salario_bruto * 0.11;
            }
            else
            {
                folha.ImpostoInss = 621.03;
            }

            //calculo FGTS

            folha.ImpostoFgts = salario_bruto * 0.08;

            //calculo salario liquido
            folha.SalarioLiquido = salario_bruto - folha.ImpostoInss - folha.ImpostoRenda;

            
            _context.Folhas.Add(folha);
            _context.SaveChanges();
            return Created("", folha);

            }

            
        }

        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            var folhas = _context.Folhas.Include(p => p.Funcionario).ToList();

            if(folhas == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(folhas);

            }
        }

        [Route("buscar/{cpf}/{mes}/{ano}")]
        [HttpGet]
        public IActionResult Buscar([FromRoute] string cpf, int mes, int ano)
        {
            //Expressão lambda
            Funcionario funcionario =
                _context.Funcionarios.FirstOrDefault
            (
                f => f.Cpf.Equals(cpf)
            );
            
            if (funcionario == null)
            {
                return NotFound();
            }
            else
            {
                var folhas_funcionario = _context.Folhas.Where(f => f.FuncionarioId == funcionario.FuncionarioId).ToList();

                FolhaPagamento folha = folhas_funcionario.FirstOrDefault
                (
                    f => f.Mes.Equals(mes) && f.Ano.Equals(ano)
                );

                if(folha == null)
                {
                    return NotFound();
                }

                else
                {
                    return Ok(folha);
                }
            }
            
        }



    }
}

