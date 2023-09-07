using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Estacionamento.Testes
{
    public class PatioTestes
    {
        private readonly Veiculo _veiculo;
        private readonly Patio _patio;

        public PatioTestes()
        {
            _veiculo = new Veiculo();
            _patio = new Patio();
        }

        [Fact]
        public void validaFaturamento()
        {
            //Arrange  
            _veiculo.Proprietario = "Adriano";
            _veiculo.Tipo = TipoVeiculo.Automovel;
            _veiculo.Cor = "Azul";
            _veiculo.Modelo = "Fusca";
            _veiculo.Placa = "ABC-1234";

            _patio.RegistrarEntradaVeiculo(_veiculo);
            _patio.RegistrarSaidaVeiculo(_veiculo.Placa);

            //Act
            double faturamento = _patio.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Adriano", "Azul", "Fusca", "ABC-1234")]
        [InlineData("Roberto", "Verde", "Brasilia", "ABC-5678")]
        [InlineData("Mariana", "Prata", "Corda", "ABC-9101")]
        public void validarFaturamentComVariosVeiculos(string nome, string cor, string modelo, string placa)
        {
            var estacionanmento = new Patio();
            _veiculo.Proprietario = nome;
            _veiculo.Tipo = TipoVeiculo.Automovel;
            _veiculo.Cor = cor;
            _veiculo.Modelo = modelo;
            _veiculo.Placa = placa;

            estacionanmento.RegistrarEntradaVeiculo(_veiculo);
            estacionanmento.RegistrarSaidaVeiculo(_veiculo.Placa);

            //Act
            double faturamento = estacionanmento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }
    }
}
