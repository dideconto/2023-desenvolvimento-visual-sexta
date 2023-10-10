namespace Prova.Models;

public class Folha
{
    public Folha(int quantidade, double valor)
    {
        Quantidade = quantidade;
        Valor = valor;
        CalcularSalarioBruto();
        CalcularFgts();
        CalcularIrrf();
        CalcularInss();
        CalcularSalarioLiquido();
    }

    public int FolhaId { get; set; }
    public double Valor { get; set; }
    public int Quantidade { get; set; }
    public int Mes { get; set; }
    public int Ano { get; set; }
    public Funcionario? Funcionario { get; set; }
    public int FuncionarioId { get; set; }
    public double SalarioLiquido { get; set; }
    public double SalarioBruto { get; set; }
    public double ImpostoIrrf { get; set; }
    public double ImpostoInss { get; set; }
    public double ImpostoFgts { get; set; }

    private void CalcularSalarioBruto() =>
        SalarioBruto = Valor * Quantidade;

    private void CalcularSalarioLiquido() =>
        SalarioLiquido = SalarioBruto - ImpostoIrrf - ImpostoInss;

    private void CalcularFgts() =>
        ImpostoFgts = SalarioBruto * .08;

    private void CalcularInss()
    {
        if (SalarioBruto <= 1693.72)
            ImpostoInss = SalarioBruto * .08;
        else if (SalarioBruto <= 2822.9)
            ImpostoInss = SalarioBruto * .09;
        else if (SalarioBruto <= 5645.8)
            ImpostoInss = SalarioBruto * .11;
        else
            ImpostoInss = 621.03;
    }

    private void CalcularIrrf()
    {
        if (SalarioBruto <= 1903.98)
            ImpostoIrrf = 0;
        else if (SalarioBruto <= 2826.65)
            ImpostoIrrf = SalarioBruto * .075 - 142.8;
        else if (SalarioBruto <= 3751.05)
            ImpostoIrrf = SalarioBruto * .15 - 354.8;
        else if (SalarioBruto <= 4664.68)
            ImpostoIrrf = SalarioBruto * .225 - 636.13;
        else
            ImpostoIrrf = SalarioBruto * .275 - 869.39;
    }
}