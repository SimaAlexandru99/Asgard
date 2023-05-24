// <copyright file="Verifications.cs" company="eOverArt Marketng Agency">
// Copyright (c) eOverArt Marketng Agency. All rights reserved.
// </copyright>

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

        private string adresaFacturare;

        private string adresaLivrare;

        private string adresa;

        private string contact;

        private string avans;

        private string email;

        private string posta;

        private string judet;

        private string cnp;

        private string rata;

        private string pretdelista;

        private string codedereducere;

        private string codedereducere2;

        private string pretfinal;

        private string idcomanda;

        private string idpropunere;

        private string datacomanda;

        private string awb;

        private string motivretur;

        private string codagent;

        private string phoneorange;

        private string idsfa;

        private string street;

        private string streetnr;

        private string valabilitateactspatiu;

        private string idcerere;

        private string idsursa;

        private string adresalocconsum;

        private string clc;

        private string pod;

        private string codclienteon;

        private string adresacorespondenta;

        private string niveltensiune;

        private string telefon;

        private string prenume;

        private string consumanualgaz;

        private string codconsumgaz;

        private string clcgaz;

        private string consumanual;

        private string datasemnare;

        private string dataintrare;

        private string categorieconsumgaz;

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

        public string AdresaFacturare
        {
            get { return adresaFacturare; }
            set { OnPropertyChanged(ref adresaFacturare, value); }
        }

        public string AdresaLivrare
        {
            get { return adresaLivrare; }
            set { OnPropertyChanged(ref adresaLivrare, value); }
        }

        public string Adresa
        {
            get { return adresa; }
            set { OnPropertyChanged(ref adresa, value); }
        }

        public string Contact
        {
            get { return contact; }
            set { OnPropertyChanged(ref contact, value); }
        }

        public string Avans
        {
            get { return avans; }
            set { OnPropertyChanged(ref avans, value); }
        }

        public string Email
        {
            get { return email; }
            set { OnPropertyChanged(ref email, value); }
        }

        public string Posta
        {
            get { return posta; }
            set { OnPropertyChanged(ref posta, value); }
        }

        public string Judet
        {
            get { return judet; }
            set { OnPropertyChanged(ref judet, value); }
        }

        public string CNP
        {
            get { return cnp; }
            set { OnPropertyChanged(ref cnp, value); }
        }

        public string Rata
        {
            get { return rata; }
            set { OnPropertyChanged(ref rata, value); }
        }

        public string PretDeListaEuro
        {
            get { return pretdelista; }
            set { OnPropertyChanged(ref pretdelista, value); }
        }

        public string CodDeReducere
        {
            get { return codedereducere; }
            set { OnPropertyChanged(ref codedereducere, value); }
        }

        public string CodDeReducere2
        {
            get { return codedereducere2; }
            set { OnPropertyChanged(ref codedereducere2, value); }
        }

        public string PretFinal
        {
            get { return pretfinal; }
            set { OnPropertyChanged(ref pretfinal, value); }
        }

        public string IDComanda
        {
            get { return idcomanda; }
            set { OnPropertyChanged(ref idcomanda, value); }
        }

        public string IDPropunere
        {
            get { return idpropunere; }
            set { OnPropertyChanged(ref idpropunere, value); }
        }

        public string AWB
        {
            get { return awb; }
            set { OnPropertyChanged(ref awb, value); }
        }

        public string DataComanda
        {
            get { return datacomanda; }
            set { OnPropertyChanged(ref datacomanda, value); }
        }

        public string MotivRetur
        {
            get { return motivretur; }
            set { OnPropertyChanged(ref motivretur, value); }
        }

        public string CodAgent
        {
            get { return codagent; }
            set { OnPropertyChanged(ref codagent, value); }
        }

        public string PhoneOrange
        {
            get { return phoneorange; }
            set { OnPropertyChanged(ref phoneorange, value); }
        }

        public string IDSfa
        {
            get { return idsfa; }
            set { OnPropertyChanged(ref idsfa, value); }
        }

        public string Street
        {
            get { return street; }
            set { OnPropertyChanged(ref street, value); }
        }

        public string StreetNr
        {
            get { return streetnr; }
            set { OnPropertyChanged(ref streetnr, value); }
        }

        // Telekom
        public string IDCerere
        {
            get { return idcerere; }
            set { OnPropertyChanged(ref idcerere, value); }
        }

        public string IDSursa
        {
            get { return idsursa; }
            set { OnPropertyChanged(ref idsursa, value); }
        }

        public string DataIntrare
        {
            get { return dataintrare; }
            set { OnPropertyChanged(ref dataintrare, value); }
        }

        public string DataSemnare
        {
            get { return datasemnare; }
            set { OnPropertyChanged(ref datasemnare, value); }
        }

        public string ConsumAnual
        {
            get { return consumanual; }
            set { OnPropertyChanged(ref consumanual, value); }
        }

        public string CodConsumGaz
        {
            get { return codconsumgaz; }
            set { OnPropertyChanged(ref codconsumgaz, value); }
        }

        public string CLCGaz
        {
            get { return clcgaz; }
            set { OnPropertyChanged(ref clcgaz, value); }
        }

        public string CategorieConsumGaz
        {
            get { return categorieconsumgaz; }
            set { OnPropertyChanged(ref categorieconsumgaz, value); }
        }

        public string ConsumAnualGaz
        {
            get { return consumanualgaz; }
            set { OnPropertyChanged(ref consumanualgaz, value); }
        }

        public string Prenume
        {
            get { return prenume; }
            set { OnPropertyChanged(ref prenume, value); }
        }

        public string Telefon
        {
            get { return telefon; }
            set { OnPropertyChanged(ref telefon, value); }
        }

        public string AdresaCorespondenta
        {
            get { return adresacorespondenta; }
            set { OnPropertyChanged(ref adresacorespondenta, value); }
        }

        public string CodClientEon
        {
            get { return codclienteon; }
            set { OnPropertyChanged(ref codclienteon, value); }
        }

        public string AdresaLocConsum
        {
            get { return adresalocconsum; }
            set { OnPropertyChanged(ref adresalocconsum, value); }
        }

        public string ValabilitateActSpatiu
        {
            get { return valabilitateactspatiu; }
            set { OnPropertyChanged(ref valabilitateactspatiu, value); }
        }

        public string CLC
        {
            get { return clc; }
            set { OnPropertyChanged(ref clc, value); }
        }

        public string POD
        {
            get { return pod; }
            set { OnPropertyChanged(ref pod, value); }
        }

        public string NivelTensiune
        {
            get { return niveltensiune; }
            set { OnPropertyChanged(ref niveltensiune, value); }
        }
    }
}
