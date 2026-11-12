## Önskemål ifrån kunden:
Kunna navigera ifrån kundlista till en sida som listar
kundens alla beställningar
Om det inte finns några beställningar så ska det visa på sidan
Finns det beställningar så ska antalet beställningar visas samt en lista
av beställningar där följande information ska visas
 - Ordernummer
 - Beställningsdatum
 - Totalsumma för beställningen

Det ska förberedas så att man ska kunna välja en beställning och komma till en ny sida som visar detaljer om beställningen såsom
 - produkt
 - antal
 - pris
 - ev rabatt
samt en summerad summa av varje produkt

1.	Skapa en ny ViewModel
	Lägg till de egenskaper som behövs
	Skapa en konstruktor om det behövs

2.	Skapa en View som matchar vår ViewModel

3.	Koppla samman vår MainWindowViewModel

4.	Koppla samman kundlista med MainWindowViewModel
	Command attributet i kundlista
	Skapa en ny kolumn för en knapp för navigeringen

5.	Skriver en test fråga i SQL och testkör

6.	När frågan fungerar så kopierar jag den och går vidare till nästa steg

7.	Uppdatera vårt interface ICustomerService
	Metod ListOrders(int customerId)

8.	Implementerar den nya metoden i CustomerService

9.	Skicka med id för vald kund i axaml filen

10.	Använd id i MainWindowViewModel för att aktivera
	en instans av CustomerOrdersViewModel

11.	Skapa en variabel för CustomerService