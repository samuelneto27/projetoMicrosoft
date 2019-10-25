using System;

namespace Model
{
    [Serializable]
    public class Pagina
    {

        public int idPagina { get; set; }
        public String url {get; set;}
        public String descricao { get; set; }
        public int? idPai { get; set; }

    }
}
