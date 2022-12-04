using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Persistencia.DAL.Consultas;
using Modelos.Procedimentos;

namespace Servico.Procedimentos
{
    public class ConsultasServico
    {
        private ConsultasDAL ConsultaDAL = new ConsultasDAL();
        public IQueryable<Consulta> ObterConsultasClassificadasPorData()
        {
            return ConsultaDAL.ObterConsultasClassificadasPorData();
        }

        public Consulta ObterConsultaPorId(long id)
        {
            return ConsultaDAL.ObterConsultaPorId(id);
        }
        public void GravarConsulta(Consulta Consulta)
        {
            ConsultaDAL.GravarConsulta(Consulta);
        }
        public Consulta EliminarConsultaPorId(long id)
        {
            Consulta Consulta = ConsultaDAL.ObterConsultaPorId(id);
            ConsultaDAL.EliminarConsultaPorId(id);
            return Consulta;
        }
    }
}