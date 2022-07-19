using System.Net;
using System.Net.Sockets;

class ServidorHTTP
{
    private TcpListener Controlador{get ; set;}
    private int Porta {get; set;}
    private int QtdRequests{get;set;}

    public ServidorHTTP(int porta = 8080)
    {
        this.Porta = porta;
        try
        {
            this.Controlador = new TcpListener(IPAddress.Parse("127.0.0.1"), this.Porta);
            this.Controlador.Start();
            Console.WriteLine($"Servidor HTTP está rodando na porta {this.Porta}.");
            Console.WriteLine($"Para acessar, digite no navegador: http://localhost:{this.Porta}.");

        }catch(Exception e)
        {
            Console.WriteLine($"Erro ao iniciar servidor na porta {this.Porta}:\n{e.Message}");

        }
    }
    private async Task AguardarRequests()
    {
        while(true){
            Socket conexao = await this.Controlador.AcceptSocketAsync();
            this.QtdRequests++;
        }
    }
}