using FCG.Domain.Entities;

namespace FCG.Tests.Domain.Entities;

public class PromocaoTests
{
    // Teste em TDD para verificar se o desconto é aplicado corretamente quando a promoção é válida
    [Fact]
    public void Deve_Aplicar_Desconto_Quando_Promocao_Valida()
    {
        var jogo = new Jogo("Fifa 26", 200);

        var promocao = new Promocao(jogo.Id, 50, DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1));

        var precoFinal = jogo.CalcularDesconto(promocao);

        Assert.Equal(100, precoFinal);
    }

    [Fact]
    public void Nao_Deve_Aplicar_Desconto_Quando_Data_Promocao_For_Invalida()
    {
        var jogo = new Jogo("Fifa 26", 200);

        var promocao = new Promocao(jogo.Id, 50, DateTime.Now.AddDays(-3), DateTime.Now.AddDays(-2));

        var precoFinal = jogo.CalcularDesconto(promocao);

        Assert.Equal(200, precoFinal);
    }

    [Fact]
    public void Nao_Deve_Aplicar_Desconto_Quando_Promocao_Estiver_Desativada()
    {
        var jogo = new Jogo("Fifa 26", 200);

        var promocao = new Promocao(jogo.Id, 50, DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1));

        promocao.DesativarPromocao();

        var precoFinal = jogo.CalcularDesconto(promocao);

        Assert.Equal(200, precoFinal);
    }
}
