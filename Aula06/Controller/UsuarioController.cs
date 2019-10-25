using Model;
using MySql.Data.MySqlClient;
using System;

namespace Controller
{
    public class UsuarioController
    {

        public Usuario Logar(Usuario objEntrada)
        {

            if (String.IsNullOrEmpty(objEntrada.Cpf))
                throw new ConsistenciaException("Por favor, preencha o campo cpf!");

            if (String.IsNullOrEmpty(objEntrada.Senha))
                throw new ConsistenciaException("Por favor, prencha o campo senha!");

            Conexao conx = new Conexao();

            MySqlCommand cmd = new MySqlCommand(@"
                select idUsuario,
                       Nome,
                       Cpf,
                       Senha
                  from Usuario
                 where Cpf = @Cpf
                   and Senha = md5(@Senha)");

            conx.Abrir();

            cmd.Parameters.Add(new MySqlParameter("Cpf", objEntrada.Cpf));
            cmd.Parameters.Add(new MySqlParameter("Senha", objEntrada.Senha));

            MySqlDataReader reader = conx.Pesquisar(cmd);

            if (!reader.Read())
            {
                conx.Fechar();
                throw new ConsistenciaException("Usuario ou senha inválido!");
            }

            Usuario us = new Usuario();

            us.idUsuario = reader.GetInt32(0);
            us.Nome = reader.GetString(1);
            us.Cpf = reader.GetString(2);
            us.Senha = reader.GetString(3);

            reader.Close();

            cmd = new MySqlCommand(@"
                select distinct pagina.idPagina,
                       pagina.url,
	                   pagina.descricao,
                       pagina.idPai
                  from pagina
                 inner join modulo_pagina on modulo_pagina.idPagina = pagina.idPagina
                 inner join Modulo on modulo_pagina.idModulo = modulo.idModulo
                 inner join usuario_modulo on modulo.idModulo = usuario_modulo.idModulo
                 where usuario_modulo.idUsuario = @IdUsuario");

            cmd.Parameters.Add(new MySqlParameter("IdUsuario", us.idUsuario));

            reader = conx.Pesquisar(cmd);

            while (reader.Read())
            {

                Pagina p = new Pagina();

                p.idPagina = reader.GetInt32(0);

                if (reader["url"] != DBNull.Value)
                    p.url = reader.GetString(1);

                p.descricao = reader.GetString(2);

                if (reader["idPai"] != DBNull.Value)
                    p.idPai = reader.GetInt32(3);

                us.listaPaginaAcesso.Add(p);

            }

            conx.Fechar();

            return us;

        }

    }
}
