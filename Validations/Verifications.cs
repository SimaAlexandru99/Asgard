namespace Asgard.Validations
{
    public class Verifications : ObservableObject
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                OnPropertyChanged(ref _name, value);
            }
        }

        private string _phone;

        public string Phone
        {
            get { return _phone; }
            set
            {
                OnPropertyChanged(ref _phone, value);
            }
        }

        private string _serie;
        public string Serie
        {
            get { return _serie; }
            set
            {
                OnPropertyChanged(ref _serie, value);
            }
        }

        private string _emis;
        public string Emis
        {
            get { return _emis; }
            set
            {
                OnPropertyChanged(ref _emis, value);
            }
        }

        private string _numarexistent;
        public string NumarExistent
        {
            get { return _numarexistent; }
            set
            {
                OnPropertyChanged(ref _numarexistent, value);
            }
        }

        private string _numestrada;
        public string NumeStrada
        {
            get { return _numestrada; }
            set
            {
                OnPropertyChanged(ref _numestrada, value);
            }
        }

        private string _numarstrada;
        public string NumarStrada
        {
            get { return _numarstrada; }
            set
            {
                OnPropertyChanged(ref _numarstrada, value);
            }
        }

        private string _bloc;
        public string Bloc
        {
            get { return _bloc; }
            set
            {
                OnPropertyChanged(ref _bloc, value);
            }
        }

        private string _scara;
        public string Scara
        {
            get { return _scara; }
            set
            {
                OnPropertyChanged(ref _scara, value);
            }
        }

        private string _etaj;
        public string Etaj
        {
            get { return _etaj; }
            set
            {
                OnPropertyChanged(ref _etaj, value);
            }
        }

        private string _apartament;
        public string Apartament
        {
            get { return _apartament; }
            set
            {
                OnPropertyChanged(ref _apartament, value);
            }
        }

        private string _cost_rata;
        public string CostRata
        {
            get { return _cost_rata; }
            set
            {
                OnPropertyChanged(ref _cost_rata, value);
            }
        }

        private string _cost_total;
        public string CostTotal
        {
            get { return _cost_total; }
            set
            {
                OnPropertyChanged(ref _cost_total, value);
            }
        }

        private string _discountcode;
        public string DiscountCode
        {
            get { return _discountcode; }
            set
            {
                OnPropertyChanged(ref _discountcode, value);
            }
        }

        private string _adresa_facturare;
        public string AdresaFacturare
        {
            get { return _adresa_facturare; }
            set
            {
                OnPropertyChanged(ref _adresa_facturare, value);
            }
        }

        private string _adresa_livrare;
        public string AdresaLivrare
        {
            get { return _adresa_livrare; }
            set
            {
                OnPropertyChanged(ref _adresa_livrare, value);
            }
        }



        private string _adresa;
        public string Adresa
        {
            get { return _adresa; }
            set
            {
                OnPropertyChanged(ref _adresa, value);
            }
        }

        private string _contact;
        public string Contact
        {
            get { return _contact; }
            set
            {
                OnPropertyChanged(ref _contact, value);
            }
        }

        private string _avans;
        public string Avans
        {
            get { return _avans; }
            set
            {
                OnPropertyChanged(ref _avans, value);
            }
        }


        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                OnPropertyChanged(ref _email, value);
            }
        }

        private string _posta;
        public string Posta
        {
            get { return _posta; }
            set
            {
                OnPropertyChanged(ref _posta, value);
            }
        }

        private string _judet;

        public string Judet
        {
            get { return _judet; }
            set
            {
                OnPropertyChanged(ref _judet, value);
            }
        }

        private string _cnp;

        public string CNP
        {
            get { return _cnp; }
            set
            {
                OnPropertyChanged(ref _cnp, value);
            }
        }

        private string _rata;

        public string Rata
        {
            get { return _rata; }
            set
            {
                OnPropertyChanged(ref _rata, value);
            }
        }

        private string _pretdelista;

        public string PretDeListaEuro
        {
            get { return _pretdelista; }
            set
            {
                OnPropertyChanged(ref _pretdelista, value);
            }
        }

        private string _codedereducere;

        public string CodDeReducere
        {
            get { return _codedereducere; }
            set
            {
                OnPropertyChanged(ref _codedereducere, value);
            }
        }

        private string _codedereducere2;

        public string CodDeReducere2
        {
            get { return _codedereducere2; }
            set
            {
                OnPropertyChanged(ref _codedereducere2, value);
            }
        }

        private string _pretfinal;

        public string PretFinal
        {
            get { return _pretfinal; }
            set
            {
                OnPropertyChanged(ref _pretfinal, value);
            }
        }

        private string _idcomanda;

        public string IDComanda
        {
            get { return _idcomanda; }
            set
            {
                OnPropertyChanged(ref _idcomanda, value);
            }
        }

        private string _idpropunere;

        public string IDPropunere
        {
            get { return _idpropunere; }
            set
            {
                OnPropertyChanged(ref _idpropunere, value);
            }
        }

        private string _awb;

        public string AWB
        {
            get { return _awb; }
            set
            {
                OnPropertyChanged(ref _awb, value);
            }
        }

        private string _datacomanda;

        public string DataComanda
        {
            get { return _datacomanda; }
            set
            {
                OnPropertyChanged(ref _datacomanda, value);
            }
        }

        private string _motivretur;

        public string MotivRetur
        {
            get { return _motivretur; }
            set
            {
                OnPropertyChanged(ref _motivretur, value);
            }
        }

        private string _codagent;

        public string CodAgent
        {
            get { return _codagent; }
            set
            {
                OnPropertyChanged(ref _codagent, value);
            }
        }

        private string _phoneorange;

        public string PhoneOrange
        {
            get { return _phoneorange; }
            set
            {
                OnPropertyChanged(ref _phoneorange, value);
            }
        }

        private string _idsfa;

        public string IDSfa
        {
            get { return _idsfa; }
            set
            {
                OnPropertyChanged(ref _idsfa, value);
            }
        }

        private string _street;

        public string Street
        {
            get { return _street; }
            set
            {
                OnPropertyChanged(ref _street, value);
            }
        }

        private string _streetnr;

        public string StreetNr
        {
            get { return _streetnr; }
            set
            {
                OnPropertyChanged(ref _streetnr, value);
            }
        }






        // Telekom 

        private string _idcerere;

        public string IDCerere
        {
            get { return _idcerere; }
            set
            {
                OnPropertyChanged(ref _idcerere, value);
            }
        }


        private string _idsursa;

        public string IDSursa
        {
            get { return _idsursa; }
            set
            {
                OnPropertyChanged(ref _idsursa, value);
            }
        }

        private string _dataintrare;

        public string DataIntrare
        {
            get { return _dataintrare; }
            set
            {
                OnPropertyChanged(ref _dataintrare, value);
            }
        }

        private string _datasemnare;

        public string DataSemnare
        {
            get { return _datasemnare; }
            set
            {
                OnPropertyChanged(ref _datasemnare, value);
            }
        }

        private string _consumanual;
        public string ConsumAnual
        {
            get { return _consumanual; }
            set
            {
                OnPropertyChanged(ref _consumanual, value);
            }
        }

        private string _codconsumgaz;
        public string CodConsumGaz
        {
            get { return _codconsumgaz; }
            set
            {
                OnPropertyChanged(ref _codconsumgaz, value);
            }
        }

        private string _clcgaz;
        public string CLCGaz
        {
            get { return _clcgaz; }
            set
            {
                OnPropertyChanged(ref _clcgaz, value);
            }
        }

        private string _categorieconsumgaz;
        public string CategorieConsumGaz
        {
            get { return _categorieconsumgaz; }
            set
            {
                OnPropertyChanged(ref _categorieconsumgaz, value);
            }
        }

        private string _consumanualgaz;
        public string ConsumAnualGaz
        {
            get { return _consumanualgaz; }
            set
            {
                OnPropertyChanged(ref _consumanualgaz, value);
            }
        }

        private string _prenume;
        public string Prenume
        {
            get { return _prenume; }
            set
            {
                OnPropertyChanged(ref _prenume, value);
            }
        }

        private string _telefon;
        public string Telefon
        {
            get { return _telefon; }
            set
            {
                OnPropertyChanged(ref _telefon, value);
            }
        }

        private string _adresacorespondenta;
        public string AdresaCorespondenta
        {
            get { return _adresacorespondenta; }
            set
            {
                OnPropertyChanged(ref _adresacorespondenta, value);
            }
        }

        private string _codclienteon;
        public string CodClientEon
        {
            get { return _codclienteon; }
            set
            {
                OnPropertyChanged(ref _codclienteon, value);
            }
        }

        private string _adresalocconsum;
        public string AdresaLocConsum
        {
            get { return _adresalocconsum; }

            set
            {
                OnPropertyChanged(ref _adresalocconsum, value);
            }
        }

        private string _valabilitateactspatiu;
        public string ValabilitateActSpatiu
        {
            get { return _valabilitateactspatiu; }
            set
            {
                OnPropertyChanged(ref _valabilitateactspatiu, value);
            }
        }

        private string _clc;
        public string CLC
        {
            get { return _clc; }
            set
            {
                OnPropertyChanged(ref _clc, value);
            }
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
