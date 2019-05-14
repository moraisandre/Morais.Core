using FluentValidation;
using Morais.Core.Model.Cliente;
using System;

namespace Morais.Core.Service.Cliente
{
    public class ClienteValidator : AbstractValidator<ClienteDTO>
    {
        private static readonly Lazy<ClienteValidator> _instance = new Lazy<ClienteValidator>(() => new ClienteValidator());
        public static ClienteValidator Instancia => _instance.Value;

        public ClienteValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.TipoPessoa)
                .NotEmpty()
                .NotNull()
                .WithMessage("Por favor escolher entre PJ ou PF");

            RuleFor(x => x.Documento)
                .NotEmpty()
                .WithMessage("Documento não informado")
                .Must((cli, doc) => DocumentoValido(cli))
                .WithMessage("O número do documento não é inválido");

            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome não informado")
                .MinimumLength(3)
                .WithMessage("O nome precisa ter mais do que 3 dígitos");

            RuleFor(x => x.Endereco)
                .NotEmpty()
                .NotNull()
                .WithMessage("Endereco não informado");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email não informado")
                .EmailAddress()
                .WithMessage("Email não é valido");
        }

        private bool DocumentoValido(ClienteDTO cliente)
        {
            if (cliente.TipoPessoa == Util.Enums.TipoPessoa.PF)
            {
                return CPFValido(cliente.Documento);
            }
            else if (cliente.TipoPessoa == Util.Enums.TipoPessoa.PJ)
            {
                return CNPJValido(cliente.Documento);
            }

            return false;
        }

        private bool CPFValido(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            //if (cpf.Count(c => c == cpf[0]) == 11)
            //    return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        public bool CNPJValido(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }
    }
}