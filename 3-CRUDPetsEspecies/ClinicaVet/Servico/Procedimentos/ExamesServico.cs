using Persistencia.DAL.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelos.Procedimentos;

namespace Servico.Procedimentos
{
    public class ExamesServico
    {
        private ExamesDAL exameDAL = new ExamesDAL();
        public IQueryable<Exame> ObterExamesClassificadosPorNome()
        {
            return exameDAL.ObterExamesClassificadosPorNome();
        }

        public Exame ObterExamePorId(long id)
        {
            return exameDAL.ObterExamePorId(id);
        }
        public void GravarExame(Exame exame)
        {
            exameDAL.GravarExame(exame);
        }

        public Exame EliminarExamePorId(long id)
        {
            Exame exame = exameDAL.ObterExamePorId(id);
            exameDAL.EliminarExamePorId(id);
            return exame;
        }

    }
}