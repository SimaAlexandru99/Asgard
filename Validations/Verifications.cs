namespace Asgard.Validations
{
    public class Verifications : ObservableObject
    {
        private string name;

        private string phone;

        private string serie;

        private string emis;

        private string numarexistent;

        private string numestrada;

        private string numarstrada;

        private string bloc;

        private string scara;

        private string etaj;

        private string apartament;

        private string costRata;

        private string costTotal;

        private string discountcode;

        public string Name
        {
            get { return name; }
            set { OnPropertyChanged(ref name, value); }
        }

        public string Phone
        {
            get { return phone; }
            set { OnPropertyChanged(ref phone, value); }
        }

        public string Serie
        {
            get { return serie; }
            set { OnPropertyChanged(ref serie, value); }
        }

        public string Emis
        {
            get { return emis; }
            set { OnPropertyChanged(ref emis, value); }
        }

        public string NumarExistent
        {
            get { return numarexistent; }
            set { OnPropertyChanged(ref numarexistent, value); }
        }

        public string NumeStrada
        {
            get { return numestrada; }
            set { OnPropertyChanged(ref numestrada, value); }
        }

        public string NumarStrada
        {
            get { return numarstrada; }
            set { OnPropertyChanged(ref numarstrada, value); }
        }

        public string Bloc
        {
            get { return bloc; }
            set { OnPropertyChanged(ref bloc, value); }
        }

        public string Scara
        {
            get { return scara; }
            set { OnPropertyChanged(ref scara, value); }
        }

        public string Etaj
        {
            get { return etaj; }
            set { OnPropertyChanged(ref etaj, value); }
        }

        public string Apartament
        {
            get { return apartament; }
            set { OnPropertyChanged(ref apartament, value); }
        }

        public string CostRata
        {
            get { return costRata; }
            set { OnPropertyChanged(ref costRata, value); }
        }

        public string CostTotal
        {
            get { return costTotal; }
            set { OnPropertyChanged(ref costTotal, value); }
        }



        public string DiscountCode
        {
            get { return discountcode; }
            set { OnPropertyChanged(ref discountcode, value); }
        }

        private string adresaFacturare;

        public string AdresaFacturare
        {
            get { return adresaFacturare; }
            set { OnPropertyChanged(ref adresaFacturare, value); }
        }

        private string adresaLivrare;

        public string AdresaLivrare
        {
            get { return adresaLivrare; }
            set { OnPropertyChanged(ref adresaLivrare, value); }
        }

        private string adresa;

        public string Adresa
        {
            get { return adresa; }
            set { OnPropertyChanged(ref adresa, value); }
        }

        private string contact;

        public string Contact
        {
            get { return contact; }
            set { OnPropertyChanged(ref contact, value); }
        }

        private string avans;

        public string Avans
        {
            get { return avans; }
            set { OnPropertyChanged(ref avans, value); }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { OnPropertyChanged(ref email, value); }
        }

        private string posta;

        public string Posta
        {
            get { return posta; }
            set { OnPropertyChanged(ref posta, value); }
        }

        private string judet;

        public string Judet
        {
            get { return judet; }
            set { OnPropertyChanged(ref judet, value); }
        }

        private string cnp;

        public string CNP
        {
            get { return cnp; }
            set { OnPropertyChanged(ref cnp, value); }
        }

        private string rata;

        public string Rata
        {
            get { return rata; }

            set
            {
                OnPropertyChanged(ref rata, value);
            }
        }

        private string pretdelista;

        public string PretDeListaEuro
        {
            get { return pretdelista; }
            set { OnPropertyChanged(ref pretdelista, value); }
        }

        private string codedereducere;

        public string CodDeReducere
        {
            get { return codedereducere; }
            set { OnPropertyChanged(ref codedereducere, value); }
        }

        private string codedereducere2;

        public string CodDeReducere2
        {
            get { return codedereducere2; }
            set { OnPropertyChanged(ref codedereducere2, value); }
        }

        private string pretfinal;

        public string PretFinal
        {
            get { return pretfinal; }
            set { OnPropertyChanged(ref pretfinal, value); }
        }

        private string idcomanda;

        public string IDComanda
        {
            get { return idcomanda; }
            set { OnPropertyChanged(ref idcomanda, value); }
        }

        private string idpropunere;

        public string IDPropunere
        {
            get { return idpropunere; }
            set { OnPropertyChanged(ref idpropunere, value); }
        }

        private string awb;

        public string AWB
        {
            get { return awb; }
            set { OnPropertyChanged(ref awb, value); }
        }

        private string datacomanda;

        public string DataComanda
        {
            get { return datacomanda; }
            set { OnPropertyChanged(ref datacomanda, value); }
        }

        private string motivretur;

        public string MotivRetur
        {
            get { return motivretur; }
            set { OnPropertyChanged(ref motivretur, value); }
        }

        private string codagent;

        public string CodAgent
        {
            get { return codagent; }
            set { OnPropertyChanged(ref codagent, value); }
        }

        private string phoneorange;

        public string PhoneOrange
        {
            get { return phoneorange; }
            set { OnPropertyChanged(ref phoneorange, value); }
        }

        private string idsfa;

        public string IDSfa
        {
            get { return idsfa; }
            set { OnPropertyChanged(ref idsfa, value); }
        }

        private string street;

        public string Street
        {
            get { return street; }
            set { OnPropertyChanged(ref street, value); }
        }

        private string streetnr;

        public string StreetNr
        {
            get { return streetnr; }
            set { OnPropertyChanged(ref streetnr, value); }
        }

        // Telekom
        private string idcerere;

        public string IDCerere
        {
            get { return idcerere; }
            set { OnPropertyChanged(ref idcerere, value); }
        }

        private string idsursa;

        public string IDSursa
        {
            get { return idsursa; }
            set { OnPropertyChanged(ref idsursa, value); }
        }

        private string dataintrare;

        public string DataIntrare
        {
            get { return dataintrare; }
            set { OnPropertyChanged(ref dataintrare, value); }
        }

        private string datasemnare;

        public string DataSemnare
        {
            get { return datasemnare; }
            set { OnPropertyChanged(ref datasemnare, value); }
        }

        private string consumanual;

        public string ConsumAnual
        {
            get { return consumanual; }
            set { OnPropertyChanged(ref consumanual, value); }
        }

        private string codconsumgaz;

        public string CodConsumGaz
        {
            get { return codconsumgaz; }
            set { OnPropertyChanged(ref codconsumgaz, value); }
        }

        private string clcgaz;

        public string CLCGaz
        {
            get { return clcgaz; }
            set { OnPropertyChanged(ref clcgaz, value); }
        }

        private string categorieconsumgaz;

        public string CategorieConsumGaz
        {
            get { return categorieconsumgaz; }
            set { OnPropertyChanged(ref categorieconsumgaz, value); }
        }

        private string consumanualgaz;

        public string ConsumAnualGaz
        {
            get { return consumanualgaz; }
            set { OnPropertyChanged(ref consumanualgaz, value); }
        }

        private string prenume;

        public string Prenume
        {
            get { return prenume; }
            set { OnPropertyChanged(ref prenume, value); }
        }

        private string telefon;

        public string Telefon
        {
            get { return telefon; }
            set { OnPropertyChanged(ref telefon, value); }
        }

        private string adresacorespondenta;

        public string AdresaCorespondenta
        {
            get { return adresacorespondenta; }
            set { OnPropertyChanged(ref adresacorespondenta, value); }
        }

        private string codclienteon;

        public string CodClientEon
        {
            get { return codclienteon; }
            set { OnPropertyChanged(ref codclienteon, value); }
        }

        private string adresalocconsum;

        public string AdresaLocConsum
        {
            get { return adresalocconsum; }
            set { OnPropertyChanged(ref adresalocconsum, value); }
        }

        private string valabilitateactspatiu;

        public string ValabilitateActSpatiu
        {
            get { return valabilitateactspatiu; }
            set { OnPropertyChanged(ref valabilitateactspatiu, value); }
        }

        private string clc;

        public string CLC
        {
            get { return clc; }
            set { OnPropertyChanged(ref clc, value); }
        }

        private string pod;

        public string POD
        {
            get { return pod; }
            set { OnPropertyChanged(ref pod, value); }
        }

        private string niveltensiune;

        public string NivelTensiune
        {
            get { return niveltensiune; }
            set { OnPropertyChanged(ref niveltensiune, value); }
        }
    }
}
