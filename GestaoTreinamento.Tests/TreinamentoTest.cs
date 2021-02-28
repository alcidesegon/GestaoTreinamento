using System;
using System.Collections.Generic;
using GestaoTreinamento.Data;
using GestaoTreinamento.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GestaoTreinamento.Tests
{
    [TestClass]
    public class TreinamentoTest
    {
        [TestMethod]
        public void PossuiDoisEspacosCadatrados()
        {
            var lista = new List<EspacoModel>();
            lista.Add(new EspacoModel { ID = 1, Nome = "Teste1" });
            lista.Add(new EspacoModel { ID = 2, Nome = "Teste2" });

            Assert.IsTrue(new TreinamentoData().PossuiDoisEspacosCadastrados(lista));
        }

        [TestMethod]
        public void NaoPossuiDoisEspacosCadatrados()
        {
            var lista = new List<EspacoModel>();
            lista.Add(new EspacoModel { ID = 1, Nome = "Teste1" });

            Assert.IsFalse(new TreinamentoData().PossuiDoisEspacosCadastrados(lista));
        }

        [TestMethod]
        public void PossuiDuasSalasCadatradas()
        {
            var lista = new List<SalaModel>();
            lista.Add(new SalaModel { ID = 1, Nome = "Teste1" });
            lista.Add(new SalaModel { ID = 2, Nome = "Teste2" });

            Assert.IsTrue(new TreinamentoData().PossuiDuasSalasCadastradas(lista));
        }

        [TestMethod]
        public void NaoPossuiDuasSalasCadatradas()
        {
            var lista = new List<SalaModel>();
            lista.Add(new SalaModel { ID = 1, Nome = "Teste1" });

            Assert.IsFalse(new TreinamentoData().PossuiDuasSalasCadastradas(lista));
        }

    }
}
