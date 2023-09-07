using Alura.Estacionamento.Modelos;
using System.IO;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes
    {
        /*
        PM> dotnet new xunit -o Alura.Estacionamento.Tests
        Preparando...
        O modelo "xUnit Test Project" foi criado com êxito.

        Processando ações pós-criação...
        Executando 'dotnet restore' em Alura.Estacionamento.Tests\Alura.Estacionamento.Tests.csproj...
        Determinando os projetos a serem restaurados...
        ….Alura.Estacionamento\Alura.Estacionamento.Tests\Alura.Estacionamento.Tests.csproj restaurado (em 728 ms).
        A restauração foi bem-sucedida*/

        /*
         dotnet sln add ./ProjetoTeste.Tests/ProjetoTeste.Tests.csproj
         */

        /*
         Ou pelo visual studio
        Botão direito na solução > Adicionar > Novo Projeto > Pesquisar por xunit
        Botão direito no projeto criado > Adicionar > Referência do Projeto
         */
        private readonly Veiculo _veiculo;
        private readonly Patio _patio;
        public VeiculoTestes()
        {
            _veiculo = new Veiculo();
            _patio = new Patio();
        }


        [Fact]
        public void TestaVeiculoAcelerar()
        {
            //Adicionar > Referencia do Projeto
            //Arrange

            //Act
            _veiculo.Acelerar(10);
            //Assert
            Assert.Equal(100, _veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaVeiculoFrear()
        {
            _veiculo.Frear(10);
            Assert.Equal(-150, _veiculo.VelocidadeAtual);
        }

        [Theory]
        [InlineData("Adriano", "ASD-1498", "preto", "Gol")]
        public void LocalizaVeiculoNoPatio(string propietario, string placa, string cor, string modelo)
        {
            //Arrange
            var veiculo = new Veiculo();
            veiculo.Proprietario = propietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            _patio.RegistrarEntradaVeiculo(veiculo);

            //Act
            var consulta = _patio.PesquisaVeiculo(placa);

            //Assert
            Assert.Equal(placa, consulta.Placa);
        }

        [Fact]
        public void TestaNomePropietarioDoVeiculoComMenosDeTresCaracteres()
        {
            //Arrange
            string propietario = "Ab";

            //Assert
            Assert.Throws<System.FormatException>(
                () => new Veiculo(propietario)
         );
        }
    }
}