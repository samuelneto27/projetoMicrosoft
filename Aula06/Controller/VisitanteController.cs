using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using MySql.Data.MySqlClient;

namespace Controller
{
    class VisitanteController
    {

        public void Incluir(Visitante objEntrada)
        {

            if (String.IsNullOrEmpty(objEntrada.Nome))
            {
                throw new ConsistenciaException("Por favor, digite o nome do visitante.");
            }

            if (String.IsNullOrEmpty(objEntrada.Cpf))
            {
                throw new ConsistenciaException("Por favor, digite o CPF do visitante");
            }

            if (String.IsNullOrEmpty(objEntrada.Endereco))
            {
                throw new ConsistenciaException("Por favor, digite o endereço do visitante.");
            }

            if (String.IsNullOrEmpty(objEntrada.Telefone))
            {
                throw new ConsistenciaException("Por favor, informe o telefone do visitante.");
            }

            MySqlCommand cmd = new MySqlCommand(@"insert into Visitante values(
                 default,
                 @Cpf,
                 @Endereco,
                 @Telefone,
                 @idUsuario)");

            cmd.Parameters.Add(new MySqlParameter("Nome", objEntrada.Nome));
            cmd.Parameters.Add(new MySqlParameter("Cpf", objEntrada.Cpf));
            cmd.Parameters.Add(new MySqlParameter("Endereco", objEntrada.Endereco));
            cmd.Parameters.Add(new MySqlParameter("Telefone", objEntrada.Telefone));
            cmd.Parameters.Add(new MySqlParameter("idUsuario", objEntrada.usuario.idUsuario));

            Conexao c = new Conexao();
            c.Abrir();
            c.Executar(cmd);
            c.Fechar();

        }

        public void Atualizar(Visitante objEntrada)
        {

            if (String.IsNullOrEmpty(objEntrada.Nome))
            {
                throw new ConsistenciaException("Por favor, digite o nome do visitante.");
            }

            if (String.IsNullOrEmpty(objEntrada.Cpf))
            {
                throw new ConsistenciaException("Por favor, digite o CPF do visitante");
            }

            if (String.IsNullOrEmpty(objEntrada.Endereco))
            {
                throw new ConsistenciaException("Por favor, digite o endereço do visitante.");
            }

            if (String.IsNullOrEmpty(objEntrada.Telefone))
            {
                throw new ConsistenciaException("Por favor, informe o telefone do visitante.");
            }

            MySqlCommand cmd = new MySqlCommand(@"update Visitante
                 set Nome = @Nome,
                     Cpf = @Cpf,
                     Endereco = @Endereco,
                     Telefone = @Telefone
               where idVisitante = @idVisitante
             ");

            cmd.Parameters.Add(new MySqlParameter("Nome", objEntrada.Nome));
            cmd.Parameters.Add(new MySqlParameter("Cpf", objEntrada.Cpf));
            cmd.Parameters.Add(new MySqlParameter("Endereco", objEntrada.Endereco));
            cmd.Parameters.Add(new MySqlParameter("Telefone", objEntrada.Telefone));
            cmd.Parameters.Add(new MySqlParameter("idVisitante", objEntrada.idVisitante));

            Conexao c = new Conexao();
            c.Abrir();
            c.Executar(cmd);
            c.Fechar();

        }

        public void Excluir(Visitante objEntrada)
        {

            MySqlCommand cmd = new MySqlCommand("delete from Visitante where idVisitante = @idVisitante");

            cmd.Parameters.Add(new MySqlParameter("idVisitante", objEntrada.idVisitante));

            Conexao c = new Conexao();
            c.Abrir();
            c.Executar(cmd);
            c.Fechar();

        }

        public List<Visitante> Listar(Visitante objEntrada)
        {

            MySqlCommand cmd = null;

            if (objEntrada.idVisitante != 0)
            {

                cmd = new MySqlCommand(@"
                 select Visitante.idVisitante,
                        Visitante.Nome,
                        Visitante.Cpf,
                        Visitante.Endereco,
                        Visitante.Telefone
                        Visitante.idUsuario
                        Usuario.Nome
                   from Visitante
                  inner join Usuario on Usuario.idUsuario = Visitante.idUsuario
                  where Visitante.idVisitante = @idVisitante");

                cmd.Parameters.Add(new MySqlParameter("idVisitante", objEntrada.idVisitante));

            }
            else
            {
                cmd = new MySqlCommand(@"
                 select Unidade.idUnidade,
                        Unidade.Nome,
                        Unidade.Estado,
                        Unidade.idUsuario,
                        Usuario.Nome
                   from Unidade
                  inner join Usuario on Usuario.idUsuario = Unidade.idUsuario");
            }

            Conexao c = new Conexao();

            c.Abrir();

            MySqlDataReader reader = c.Pesquisar(cmd);

            List<Visitante> lstRetorno = new List<Visitante>();

            while (reader.Read())
            {
                Visitante visitante = new Visitante();

                visitante.idVisitante = reader.GetInt32(0);
                visitante.Nome = reader.GetString(1);
                visitante.Cpf = reader.GetString(2);
                visitante.Endereco = reader.GetString(3);
                visitante.Telefone = reader.GetString(4);

                Usuario usuario = new Usuario();

                usuario.idUsuario = reader.GetInt32(3);
                usuario.Nome = reader.GetString(4);

                visitante.usuario = usuario;

                lstRetorno.Add(visitante);

            }

            c.Fechar();

            return lstRetorno;

        }

    }
}
}
