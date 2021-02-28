using System;
using System.Collections.Generic;

namespace GestaoTreinamento.Data
{
    interface IData<T> where T : class
    {
        void Criar(T model);
        void Atualizar(T model);
        void Excluir(long id);
        List<T> BuscarTodosRegistros();
        T BuscarPeloID(long id);
    }
}
