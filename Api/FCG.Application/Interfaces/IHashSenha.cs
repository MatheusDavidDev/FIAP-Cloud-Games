namespace FCG.Application.Interfaces;

public interface IHashSenha
{
    public string GerarHash(string senha);

    public bool VerificarHash(string senha, string hash);

}
