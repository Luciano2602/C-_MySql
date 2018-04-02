using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace ExMySql
{
    public class Negocio
    {
        private string _SQL;
        private MySqlCommand cmd;
        private MySqlDataReader dr;
        private ObjetoTransferencia transportadora;

        public void InserirTransportadora(ObjetoTransferencia transportadora)
        {
            cmd = new MySqlCommand();

            cmd.Connection = AcessoDados.Conectar();

            _SQL = @"insert into transportadoras (nometransportadora,endereco, telefone, cidade, estadoID, cep, cnpj)
                    values
                    (@nometransportadora, @endereco, @telefone, @cidade, @estadoID, @cep, @cnpj)";

            cmd.CommandText = _SQL;
            cmd.Parameters.AddWithValue("@nometransportadora", transportadora.nometransportadora);
            cmd.Parameters.AddWithValue("@endereco", transportadora.endereco);
            cmd.Parameters.AddWithValue("@telefone", transportadora.telefone);
            cmd.Parameters.AddWithValue("@cidade", transportadora.cidade);
            cmd.Parameters.AddWithValue("@estadoID", transportadora.estadoID);
            cmd.Parameters.AddWithValue("@cep", transportadora.cep);
            cmd.Parameters.AddWithValue("@cnpj", transportadora.nometransportadora);

            cmd.ExecuteNonQuery();

            cmd.Parameters.Clear();
            cmd.Connection.Close();
        }

        public List<ObjetoTransferencia> ListarTransportadoras(string nomeTrans)
        {

            //_SQL = "select * from transportadoras where nometransportadora like '%+@nometransportadora+%' ";
            _SQL = "select * from transportadoras where nometransportadora like '%"+nomeTrans+"%' ";


            cmd = new MySqlCommand();
            cmd.Connection = AcessoDados.Conectar();

            //cmd.Parameters.Add("@nometransportadora", MySqlDbType.VarChar, 50).Value = nomeTrans;
            //cmd.Parameters.AddWithValue("@nometransportadora", nomeTrans);
                
            cmd.CommandText = _SQL;

            dr = cmd.ExecuteReader();

            List<ObjetoTransferencia> lsTranp = new List<ObjetoTransferencia>();

            while (dr.Read())
            {
                ObjetoTransferencia t = new ObjetoTransferencia();
                t.transportadoraID = dr.GetInt32(0);
                t.nometransportadora = dr.GetString(1);
                t.endereco = dr.GetString(2);
                t.telefone = dr.GetString(3);
                t.cidade = dr.GetString(4);
                t.estadoID = dr.GetInt32(5);
                t.cep = dr.GetString(6);
                t.cnpj = dr.GetString(7);

                lsTranp.Add(t);
            }

            cmd.Parameters.Clear();
            cmd.Connection.Close();

            return lsTranp;

        }
    }
}
