namespace DAL_AdopteUnDev.DTO
{
    public class LangCateg
    {
        //tabella intermedia per unire Categories a ITLang: Mi serve davvero?

        // HO SOLO SERVIZI Get, voglio solo vederla

        //questo mi serve solo se voglio visualizzare (nel mio sito) le 'Categorie' oltre al 'Linguaggio'(:=ITLang)
        //se seleziono categoria 'Web', devo poter visualizzare SOLO i linguaggi associati
        //e viceversa (se seleziono C#, devo vedere solo le categorie associate)
        public int idIT { get; set; }
        public int idCategory { get; set; }

        //non presenti in DB !!!!! sono in BLL
        //public Categories Category { get; set; }
        //public ITLang Language { get; set; }
    }
}
