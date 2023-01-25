using AjlaBrdarevicReallyFastFoodApp.Models;
namespace AjlaBrdarevicReallyFastFoodApp;

public partial class MainPage : ContentPage
{
    public List<Jelo> JeloList { get; set; }
    private List<Naselja> MjestaLista { get; set; }

    public MainPage() {

        //Lista jela
        JeloList = new List<Jelo>{
            new Jelo() { Id = 1, Slika = "hamburger.png", Ime = "Burger", Cijena = 10, Kalorije = 250 },
            new Jelo() { Id = 2, Slika = "pizza.png", Ime = "Pizza", Cijena = 20, Kalorije = 350 },
            new Jelo() { Id = 3, Slika = "jelo3.png", Ime = "Rolls", Cijena = 30, Kalorije = 450 },
            new Jelo() { Id = 4, Slika = "supa.png", Ime = "Soup", Cijena = 40, Kalorije = 150 }
        };

        //Lista naselja
        MjestaLista = new List<Naselja> {
            new Naselja() { Id = 1, Naziv = "Centar", Udaljenost = 1 },
            new Naselja() { Id = 2, Naziv = "Blatuša", Udaljenost = 2 },
            new Naselja() { Id = 3, Naziv = "Crkvice", Udaljenost = 3 },
            new Naselja() { Id = 4, Naziv = "Radakovo", Udaljenost = 4 }
        };

        InitializeComponent();

        BindingContext = this;

        //Binding jela
        Slika1.Source = JeloList[0].Slika;
        Naziv1.Text = JeloList[0].Ime;
        Cijena1.Text = JeloList[0].Cijena.ToString();
        Kalorije1.Text = JeloList[0].Kalorije.ToString();

        Slika2.Source = JeloList[1].Slika;
        Naziv2.Text = JeloList[1].Ime;
        Cijena2.Text = JeloList[1].Cijena.ToString();
        Kalorije2.Text = JeloList[1].Kalorije.ToString();

        Slika3.Source = JeloList[2].Slika;
        Naziv3.Text = JeloList[2].Ime;
        Cijena3.Text = JeloList[2].Cijena.ToString();
        Kalorije3.Text = JeloList[2].Kalorije.ToString();

        Slika4.Source = JeloList[3].Slika;
        Naziv4.Text = JeloList[3].Ime;
        Cijena4.Text = JeloList[3].Cijena.ToString();
        Kalorije4.Text = JeloList[3].Kalorije.ToString();

        odabirMjesta.ItemsSource = MjestaLista;

    }

    private void Button_Clicked(object sender, EventArgs e)
    {

//CheckBox provjera odabranog
        if (Odabir1.IsChecked == true)
        {
            if (Kolicina1.Text is null)
                JeloList[0].Kolicina = 1;
            else
                JeloList[0].Kolicina = int.Parse(Kolicina1.Text);
        }

        if (Odabir2.IsChecked == true)
        {
            if (Kolicina2.Text is null)
                JeloList[1].Kolicina = 1;
            else
                JeloList[1].Kolicina = int.Parse(Kolicina2.Text);
        }

        if (Odabir3.IsChecked == true)
        {
            if (Kolicina1.Text is null)
                JeloList[2].Kolicina = 1;
            else
                JeloList[2].Kolicina = int.Parse(Kolicina3.Text);
        }

        if (Odabir4.IsChecked == true)
        {
            if (Kolicina1.Text is null)
                JeloList[3].Kolicina = 1;
            else
                JeloList[3].Kolicina = int.Parse(Kolicina4.Text);
        }

        DisplayAlert("Vaša narudžba", Izracunato(), "Ok");
    }

//Računanje cijene narudžbe, kalorija i količine
    string Izracunato() {
        decimal CijenaNarudzbe = 0;
        int UkupnoKalorija = 0;
        int UkupnoKolicina = 0;
        double udaljenostZaDostavu = 0;
        decimal Dostava = 0;
        decimal UkupnaCijena = 0;

        CijenaNarudzbe = CijenaNarudzbe + JeloList[0].Kolicina * JeloList[0].Cijena;
        UkupnoKalorija = UkupnoKalorija + JeloList[0].Kolicina * JeloList[0].Kalorije;
        UkupnoKolicina = UkupnoKolicina + JeloList[0].Kolicina;

        CijenaNarudzbe = CijenaNarudzbe + JeloList[1].Kolicina * JeloList[1].Cijena;
        UkupnoKalorija = UkupnoKalorija + JeloList[1].Kolicina * JeloList[1].Kalorije;
        UkupnoKolicina = UkupnoKolicina + JeloList[1].Kolicina;

        CijenaNarudzbe = CijenaNarudzbe + JeloList[2].Kolicina * JeloList[2].Cijena;
        UkupnoKalorija = UkupnoKalorija + JeloList[2].Kolicina * JeloList[2].Kalorije;
        UkupnoKolicina = UkupnoKolicina + JeloList[2].Kolicina;

        CijenaNarudzbe = CijenaNarudzbe + JeloList[3].Kolicina * JeloList[3].Cijena;
        UkupnoKalorija = UkupnoKalorija + JeloList[3].Kolicina * JeloList[3].Kalorije;
        UkupnoKolicina = UkupnoKolicina + JeloList[3].Kolicina;

//Za 0.10 na svaki pređeni kilometar
        udaljenostZaDostavu = MjestaLista[0].Udaljenost * 0.10;
        udaljenostZaDostavu = MjestaLista[1].Udaljenost * 0.10;
        udaljenostZaDostavu = MjestaLista[2].Udaljenost * 0.10;
        udaljenostZaDostavu = MjestaLista[3].Udaljenost * 0.10;

//Ukupna cijena sa 20% od narudžbe
        decimal x = 0.2m;
        Dostava = Decimal.Multiply(CijenaNarudzbe, x);
        UkupnaCijena = CijenaNarudzbe + Dostava + ((decimal)udaljenostZaDostavu);

//vrijeme dostave
        DateTime.Now.ToString("h:mm ");
        DateTime vrijemeDostavePomocna = DateTime.Now.AddMinutes(20);
        TimeOnly vrijemeDostave = TimeOnly.FromDateTime(vrijemeDostavePomocna);

//Ispis
        string ispis = "Ukupna cijena: " + UkupnaCijena + " KM" + "\nKalorije: " + UkupnoKalorija + "\nBroj porcija: " + UkupnoKolicina + "\nPredviđeno vrijeme dostave: " + vrijemeDostave.ToString();
        return ispis;
    }
}



