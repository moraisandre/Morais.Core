using System.ComponentModel;

namespace Morais.Core.Util.Enums
{
    public enum TipoPessoa
    {
        [Description("Pessoa Física")]
        PF = 1,
        [Description("Pessoa Juridica")]
        PJ = 2
    }
}