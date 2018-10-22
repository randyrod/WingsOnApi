# WingsOnApi

WebApi built on ASP.Net to expose basic Booking service endpoints

## EndPoints

### Person

1. Get Person by Id
  - Url: wingson/api/person/{id}
  - Example result:
    ```
    {
      "Name": "Kendall Velazquez",
      "DateBirth": "1980-09-24T00:00:00",
      "Gender": 0,
      "Address": "805-1408 Mi Rd.",
      "Email": "egestas.a.dui@aliquet.ca",
      "Id": 91
    }
    ```
2. Get all males
  - Url: wingson/api/person/getmales
  - Example output:
  ```
  [
    {
        "Name": "Kendall Velazquez",
        "DateBirth": "1980-09-24T00:00:00",
        "Gender": 0,
        "Address": "805-1408 Mi Rd.",
        "Email": "egestas.a.dui@aliquet.ca",
        "Id": 91
    },
    {
        "Name": "Branden Johnston",
        "DateBirth": "1940-01-01T00:00:00",
        "Gender": 0,
        "Address": "P.O. Box 795, 1956 Odio. Rd.",
        "Email": "egestas.lacinia@Proinmi.com",
        "Id": 77
    }
  ]
  ```
### Bookings
1. Get booking by Id
  - Url: wingson/api/bookings/{id}
  - Example output:
  ```
  {
    "Number": "WO-291470",
    "Flight": {
        "Number": "BB768",
        "Carrier": {
            "Code": "BB",
            "Name": "Proin Fly Corp",
            "Address": "985-9762 Semper Street, Saint-Prime, Bolivia",
            "Id": 45
        },
        "DepartureAirport": {
            "Code": "OQO",
            "Country": "Cuba",
            "City": "Zwijnaarde",
            "Id": 60
        },
        "DepartureDate": "2006-11-15T01:30:00",
        "ArrivalAirport": {
            "Code": "ANH",
            "Country": "Algeria",
            "City": "Chiniot",
            "Id": 80
        },
        "ArrivalDate": "2006-11-14T21:00:00",
        "Price": 416.17,
        "Id": 21
    },
    "Customer": {
        "Name": "Branden Johnston",
        "DateBirth": "1940-01-01T00:00:00",
        "Gender": 0,
        "Address": "P.O. Box 795, 1956 Odio. Rd.",
        "Email": "egestas.lacinia@Proinmi.com",
        "Id": 77
    },
    "Passengers": [
        {
            "Name": "Branden Johnston",
            "DateBirth": "1940-01-01T00:00:00",
            "Gender": 0,
            "Address": "P.O. Box 795, 1956 Odio. Rd.",
            "Email": "egestas.lacinia@Proinmi.com",
            "Id": 77
        }
    ],
    "DateBooking": "2006-03-03T14:30:00",
    "Id": 55
}
  ```
2. Get booking by booking number
  - Url: wingson/api/bookings/{bookingNumber}
  - Example output:
  ```
  {
    "Number": "WO-291470",
    "Flight": {
        "Number": "BB768",
        "Carrier": {
            "Code": "BB",
            "Name": "Proin Fly Corp",
            "Address": "985-9762 Semper Street, Saint-Prime, Bolivia",
            "Id": 45
        },
        "DepartureAirport": {
            "Code": "OQO",
            "Country": "Cuba",
            "City": "Zwijnaarde",
            "Id": 60
        },
        "DepartureDate": "2006-11-15T01:30:00",
        "ArrivalAirport": {
            "Code": "ANH",
            "Country": "Algeria",
            "City": "Chiniot",
            "Id": 80
        },
        "ArrivalDate": "2006-11-14T21:00:00",
        "Price": 416.17,
        "Id": 21
    },
    "Customer": {
        "Name": "Branden Johnston",
        "DateBirth": "1940-01-01T00:00:00",
        "Gender": 0,
        "Address": "P.O. Box 795, 1956 Odio. Rd.",
        "Email": "egestas.lacinia@Proinmi.com",
        "Id": 77
    },
    "Passengers": [
        {
            "Name": "Branden Johnston",
            "DateBirth": "1940-01-01T00:00:00",
            "Gender": 0,
            "Address": "P.O. Box 795, 1956 Odio. Rd.",
            "Email": "egestas.lacinia@Proinmi.com",
            "Id": 77
        }
    ],
    "DateBooking": "2006-03-03T14:30:00",
    "Id": 55
}
  ```
3. Get all passengers in flight
  - Url: wingson/api/bookings/getpassengersinflight/{flightNumber}
  - Example output:
  ```
  [
    {
        "Name": "Claire Stephens",
        "DateBirth": "1948-11-27T00:00:00",
        "Gender": 1,
        "Address": "P.O. Box 344, 5822 Curabitur Rd.",
        "Email": "non.cursus.non@turpisIncondimentum.co.uk",
        "Id": 69
    },
    {
        "Name": "Kendall Velazquez",
        "DateBirth": "1980-09-24T00:00:00",
        "Gender": 0,
        "Address": "805-1408 Mi Rd.",
        "Email": "egestas.a.dui@aliquet.ca",
        "Id": 91
    }
  ]
  ```
4. Get count of passengers in flight
  - Url: wingson/api/bookings/getpassengerscountinflight/{flightNumber}
  - Example output:
  ```
  5
  ```
