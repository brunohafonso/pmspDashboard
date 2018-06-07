using System;
using System.Collections.Generic;

namespace bruno.pmsp.domain.Entities 
{
    public class Field
    {
        public string type { get; set; }
        public string id { get; set; }
    }

    public class Record
    {
        public string TEL1 { get; set; }
        public string DTURNOS15 { get; set; }
        public string TEL2 { get; set; }
        public string SITUACAO { get; set; }
        public string T2D3D07 { get; set; }
        public string T2D3D08 { get; set; }
        public string BAIRRO { get; set; }
        public string DTURNOS08 { get; set; }
        public string DTURNOS09 { get; set; }
        public string DTURNOS16 { get; set; }
        public string DT_AUTORIZA { get; set; }
        public string SETOR { get; set; }
        public string DRE { get; set; }
        public string T2D3D16 { get; set; }
        public string DTURNOS { get; set; }
        public string FAX { get; set; }
        public string DTURNOS13 { get; set; }
        public string ATO_CRIACAO { get; set; }
        public string TIPOESC { get; set; }
        public string DTURNOS12 { get; set; }
        public string T2D3D09 { get; set; }
        public string CEU { get; set; }
        public string CEP { get; set; }
        public string T2D3D13 { get; set; }
        public string T2D3D12 { get; set; }
        public string T2D3D11 { get; set; }
        public string T2D3D10 { get; set; }
        public string DTURNOS11 { get; set; }
        public string EH { get; set; }
        public string T2D3D15 { get; set; }
        public string T2D3D14 { get; set; }
        public string NUMERO { get; set; }
        public string CODINEP { get; set; }
        public string REDE { get; set; }
        public string DT_INI_FUNC { get; set; }
        public string CODDIST { get; set; }
        public string DTURNOS10 { get; set; }
        public string CODESC { get; set; }
        public string DTURNOS14 { get; set; }
        public string LONGITUDE { get; set; }
        public string CODCIE { get; set; }
        public string DIRETORIA { get; set; }
        public string DOM_CRIACAO { get; set; }
        public string DATABASE { get; set; }
        public string NOME_ANT { get; set; }
        public string SUBPREF { get; set; }
        public string NOMESC { get; set; }
        public string _full_text { get; set; }
        public string DTURNOS07 { get; set; }
        public string DT_CRIACAO { get; set; }
        public string LATITUDE { get; set; }
        public string ENDERECO { get; set; }
        public int _id { get; set; }
        public string DISTRITO { get; set; }
        public string T2D3D { get; set; }
    }

    public class Result
    {
        public string limit { get; set; }
        public List<Field> fields { get; set; }
        public List<Record> records { get; set; }
        public string sql { get; set; }
    }

    public class RootObject
    {
        public string help { get; set; }
        public bool success { get; set; }
        public Result result { get; set; }
    }
}