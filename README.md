# Weather serivce

There is a simple pet-project based on WebAPI and OpenWeather

!!IMPORTANT!! This is just demo: not enough clean architecture, no any extend options except temperature, no SSL. It's just a my vision of task for pet-project. 

If you want to see full template of .Net Core Clean Architecture, go [here](https://github.com/Kingmidas74/WebAPILight) 

## Components

* .WebAPI services - Incoming point
    * [.Net Core WebAPI](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-3.1&tabs=visual-studio) - Basic framework
    * [Swagger](https://swagger.io/) - It's a very simple in use and informative instrument for documentation your API
* Business services - Separate class library with example of some "business" logic. In this case I implement next techniques:
    * [MediatR](https://github.com/jbogard/MediatR) - for CQRS 
    * [Specification](https://www.c-sharpcorner.com/article/the-specification-pattern-in-c-sharp/) - for Q in CQRS
    * [FluentValidation](https://fluentvalidation.net/) - basically.. for validation.
* DataAccess
    * Api of [OpenWeatherMap](https://openweathermap.org/)
* Angular application. Basically it's just a huge map on the page. Feel free to click in any place on that map for information about weather. I suppose it's a best approach to show  key information to user instead of tables, graphs..etc.


## Installation

1) Just clone repository ...
2) check settings in docker-compose.yml (API_URL and API_KEY)
3) ... and run docker-compose from solution folder.
```bash
docker-compose up -d
```
4) Open localhost:8888 and enjoy it!
5) Also swagger on localhost:5002/swagger

That's all!

## License
[MIT](https://choosealicense.com/licenses/mit/)