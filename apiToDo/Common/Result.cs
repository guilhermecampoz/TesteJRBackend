using System.Collections.Generic;
using System.Linq;

namespace apiToDo.Common
{
    public class Result<T>
    {
        public bool ehSucesso { get; set; }
        public T Valor { get; set; }
        public List<string>? Erros { get; set; }
        public Erro? TipoErro { get; set; }

        public Result(bool sucesso, T valor, List<string> erros, Erro? tipoErro)
        {
            ehSucesso = sucesso;
            Valor = valor;
            Erros = erros;
            TipoErro = tipoErro;
        }

        public static Result<T> Sucesso(T valor)
            => new(true, valor, new List<string>(), null);

        public static Result<T> Falha(Erro tipoErro, List<string> erros)
            => new(false, default, erros, tipoErro);
    }
}
