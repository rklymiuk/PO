using System;

namespace lab01
{
    class Car
    {
        private string _brand;
        private string _model;
        private int _doorCount;
        private float _engineVolume;
        private double _avgConsump;
        private string _registrationNumber;
        private static int carCount;
        public string Brand{
            get { return _brand; }
            set { _brand = value; }
        }
        public string Model{
            get { return _model; }
            set { _model = value; }
            
        }
        public int DoorCount{
            get { return _doorCount; }
            set { _doorCount = value; }
            
        }
        public float EngineVolume{
            get { return _engineVolume; }
            set { _engineVolume = value; }
            
        }
        public double AvgConsump{
            get { return _avgConsump; }
            set { _avgConsump = value; }
            
        }
        public string RegistrationNumber{
            get { return _registrationNumber; }
            set { _registrationNumber = value; }
        }

        public static int CarCount
        {
            get => carCount;
            private set => carCount = value;
        }

        public Car(string brand, string model, int doorCount, float engineVolume, double avgConsump,
            string registrationNumber)
        {
            Brand = brand;
            Model = model;
            DoorCount = doorCount;
            EngineVolume = engineVolume;
            AvgConsump = avgConsump;
            RegistrationNumber = registrationNumber;
            CarCount++;
        }
        public Car():this(string.Empty,string.Empty,0,0,0,string.Empty){}
        public double FuelConsumption(double roadLenght)
        {
            return (AvgConsump / 100) * roadLenght;
        }

        public double CostOfTheTrip(double roadLenght, double petrolCost)
        {
            return FuelConsumption(roadLenght) * petrolCost;
        }

        public override string ToString()
        {
            return string.Format("Samochod:{0}/{1}/{2}/{3}/{4}/{5}", Brand, Model, DoorCount, EngineVolume, AvgConsump, RegistrationNumber);
        }
    }

    class Garage
    {
        private List<Car> _cars;
        private string _address;
        private int _capacity;

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public int Capacity
        {
            get { return _capacity; }
            set { _capacity = value; }
        }

        public int CarsCount
        {
            get { return _cars.Count; }
        }

        public Garage() : this(string.Empty, 0)
        {
        }

        public Garage(string address, int capacity)
        {
            _address = address;
            _capacity = capacity;
            _cars = new List<Car>(_capacity);
        }

        public bool CarIn(Car car)
        {
            if (car == null || _cars.Count >= _capacity) return false;
            foreach (Car c in _cars)
            {
                if (c.Equals(car)) return false;
            }

            _cars.Add(car);
            return true;
        }

        public Car? CarOut()
        {

            Car car = _cars[_cars.Count - 1];
            _cars.Remove(car);
            return car;
        }

        public bool CarOut(Car car)
        {
            _cars.Remove(car);
            return true;
        }

        public Car? CarOut(string registrationNumber)
        {
            if (string.IsNullOrWhiteSpace(registrationNumber))
            {
                return null;
            }


            Car car = null;
            foreach (Car c in _cars)
            {
                if (registrationNumber == c.RegistrationNumber)
                {
                    car = c;

                    break;
                }
                else return null;
            }

            _cars.Remove(car);
            return car;
        }

        public double CalculateAverageFuelConsumption()
        {
            double sum = 0;
            foreach (Car car in _cars)
            {
                sum += car.AvgConsump;
            }

            return _cars.Count == 0 ? 0 : sum / _cars.Count;
        }

        public override string ToString()
        {
            string s = string.Format("Garaż {0} ({1}/{2} samochodów):", _address, _cars.Count, _capacity);
            foreach (Car car in _cars)
            {
                s += "\n- " + car;
            }

            return s;
        }

        /*public Car GetCarsByBrand(string brand)
        {
            List <Car> temp = null;
            foreach (Car car in _cars)
            {
                if (car.Brand == brand)
                {
                    temp.Add(car);
                }

            }

            return temp;
        }*/
    }

    class Person
    {
        private List<Car> _cars;
        private string _address;
        private int _carCount;
        private string _firstName;
        private string _lastName;
        
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int CarsCount { get { return _cars.Count; } }
        
        public static int MaxCarCount { get; private set; } = 3;

        public Person(string firstName, string lastName, string address, int carCount, List <Car> cars)
        {
            _firstName = firstName;
            _lastName = lastName;
            _address = address;
            _carCount = carCount;
            if(cars.Count<=MaxCarCount){
            _cars = new List<Car>(cars);
            
            }
            
        }
        public Person(string firstName, string lastName, string address, int carCount)
        {
            _firstName = firstName;
            _lastName = lastName;
            _address = address;
            _carCount = carCount;
            

        }
        public Person():this(string.Empty,string.Empty,string.Empty,0,new List <Car>()){}

        public void AddCar(Car car)
        {
            if (_cars.Count <= MaxCarCount)
            {
                _cars.Add(car);
            }
        }

        public void RemoveCar(string registrationNumber)
        {
            Car tempCar=null;
            foreach (Car car in _cars)
            {
                if (registrationNumber == car.RegistrationNumber)
                {
                    tempCar = car;
                    break;
                }
                
            }
            _cars.Remove(tempCar);
        }

        public void RemoveCar(Car car)
        {
            if (_cars.Contains(car))
            {
                _cars.Remove(car);
            }
        }
        public override string ToString() {
            string s = string.Format("Osoba: {0}, {1},{2},posiadane samochody:{3}\n",
                    FirstName, LastName, Address, CarsCount);
            foreach (Car car in _cars)
            {
                s += "\n-" + car;
            }
            return s;
        }
        
        
        
    }
    class Program
        {


            static void Main(string[] args)
            {
                Console.WriteLine("-----------------------------------------------------------------------");
                Console.WriteLine("Testowanie klasy Car");
                Console.WriteLine("-----------------------------------------------------------------------");
//Samochód bez parametrów (domyślny konstruktor)
                Car car1 = new Car();
                Console.WriteLine(car1); //Sprawdzamy domyślne wartości pól samochodu
//Samochód z parametrami (konstruktor z parametrami)
                Car car2 = new Car("Fiat", "500", 2, 1.2f, 5.2, "FI500");
                Console.WriteLine(car2); //Sprawdzamy wartości po przypisaniu danych
                Car car3 = new Car("Tesla", "Model S", 4, 0f, 15.0, "TS100");
                Console.WriteLine(car3); //Sprawdzamy inny pojazd
//Testowanie właściwości
                car1.Brand = "BMW";
                car1.Model = "X5";
                car1.DoorCount = 5;
                car1.EngineVolume = 3.0f;
                car1.AvgConsump = 9.5;
                car1.RegistrationNumber = "BMW1234";
                Console.WriteLine(car1); //Właściwości po zmianach
//Testowanie metod
                double roadLength = 200; //Długość trasy w km
                double petrolCost = 5.2; //Koszt paliwa za litr
                double fuelConsumption = car2.FuelConsumption(roadLength);
                Console.WriteLine($"Zużycie paliwa dla {roadLength} km: {fuelConsumption} litrów");
                double tripCost = car2.CostOfTheTrip(roadLength, petrolCost);
                Console.WriteLine($"Koszt paliwa dla {roadLength} km: {tripCost} PLN");
//Testowanie statycznej zmiennej CarCount

                Console.WriteLine($"Liczba samochodów stworzonych: {Car.CarCount}"); //Powinna wynosić 3
//Testowanie metody ToString()
                Console.WriteLine("Opis samochodu car3: " + car3);
                Console.WriteLine("-----------------------------------------------------------------------");
                Console.WriteLine("Testowanie klasy Garage");
                Console.WriteLine("-----------------------------------------------------------------------");
//Testowanie klasy Garage
                Garage garage = new Garage("Garaż przy ul. Kwiatowej", 2);
                Console.WriteLine("Adres garażu: " + garage.Address);
                Console.WriteLine("Pojemność garażu: " + garage.Capacity);
                Console.WriteLine("Liczba samochodów w garażu: " + garage.CarsCount);
//Dodawanie samochodów do garażu
                Console.WriteLine("Dodawanie samochodów do garażu...");
                garage.CarIn(car1);
                garage.CarIn(car2);
                Console.WriteLine(garage);
//Sprawdzanie, czy samochód można dodać ponownie (jest już w garażu)
                bool addedAgain = garage.CarIn(car1); //Próba dodania ponownie car1
                Console.WriteLine($"Próba ponownego dodania car1 do garażu: {addedAgain}");
//Usuwanie samochodu z garażu
                garage.CarOut(car1);
                Console.WriteLine("Po usunięciu car1 z garażu:");
                Console.WriteLine(garage);
//Testowanie metody CarOut() bez argumentów
                Car? carOut = garage.CarOut();
                Console.WriteLine("Samochód wyjęty z garażu (bez numeru rejestracyjnego): " +
                                  (carOut != null ? carOut.ToString() : "Brak"));
//Testowanie metody CarOut() z numerem rejestracyjnym
                carOut = garage.CarOut("FI500");
                Console.WriteLine("Samochód wyprowadzony z garażu: " + (carOut != null ? carOut.ToString() : "Brak"));


//Testowanie metody CalculateAverageFuelConsumption()
                double avgFuelConsump = garage.CalculateAverageFuelConsumption();
                Console.WriteLine($"Średnie zużycie paliwa aut w garażu: {avgFuelConsump} l/100km");
                
                Console.WriteLine("-----------------------------------------------------------------------");
                Console.WriteLine("Testowanie klasy Person");
                Console.WriteLine("-----------------------------------------------------------------------");

// Tworzymy kilka samochodów, które przypiszemy osobie
                Car carA = new Car("Audi", "A4", 4, 2.0f, 7.5, "AU123");
                Car carB = new Car("Toyota", "Corolla", 4, 1.6f, 6.5, "TO456");
                Car carC = new Car("Ford", "Focus", 5, 1.8f, 7.0, "FO789");
                Car carD = new Car("Opel", "Astra", 5, 1.4f, 6.0, "OP101");

// Tworzymy listę samochodów początkowych
                List<Car> carsList = new List<Car> { carA, carB };

// Tworzymy osobę z listą samochodów
                Person person1 = new Person("Jan", "Kowalski", "Warszawa, ul. Słoneczna 5", carsList.Count, carsList);
                Console.WriteLine("Dane osoby po utworzeniu:");
                Console.WriteLine(person1);

// Dodajemy nowy samochód (powinno się udać, bo ma mniej niż MaxCarCount)
                Console.WriteLine("\nDodawanie nowego samochodu (Ford Focus)...");
                person1.AddCar(carC);
                Console.WriteLine(person1);

// Próba dodania czwartego samochodu (nie powinna się udać, MaxCarCount = 3)
                Console.WriteLine("\nPróba dodania czwartego samochodu (Opel Astra)...");
                person1.AddCar(carD);
                Console.WriteLine(person1);

                // Usuwamy samochód po numerze rejestracyjnym
                Console.WriteLine("\nUsuwanie samochodu o numerze rejestracyjnym 'AU123'...");
                person1.RemoveCar("AU123");
                Console.WriteLine(person1);

                // Usuwamy samochód przekazując obiekt
                Console.WriteLine("\nUsuwanie samochodu Toyota Corolla (obiektem)...");
                person1.RemoveCar(carB);
                Console.WriteLine(person1);

                // Tworzymy osobę bez samochodów (konstruktor domyślny)
                Console.WriteLine("\nTworzenie osoby bez samochodów (domyślny konstruktor):");
                Person person2 = new Person();
                Console.WriteLine(person2);

                // Test właściwości (ustawienie imienia, nazwiska, adresu)
                Console.WriteLine("\nUstawianie danych osobowych dla person2:");
                person2.FirstName = "Anna";
                person2.LastName = "Nowak";
                person2.Address = "Kraków, ul. Zielona 10";
                Console.WriteLine(person2);

            }
        }

    }