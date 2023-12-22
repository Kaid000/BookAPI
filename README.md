## О проекте

Тестовое задание на стажировку в MODSEN. Представляет собой Web API для работы с данными из базы данных и CRUD операциями

## Использующиеся технологии 

.NET 8.0
Entity Framework Core,
MS SQL Server 2019,
AutoMapper,
MediatR,
EF Fluent API,
Swagger,
Authentication via bearer token.

## Как запустить проект

Перед началом работы с проектом удостоверьтесь, что у вас установлен .NET SDK.Если его нет, то его можно скачать с официального сайта Microsoft.

Затем, откройте проект в IDE и настройте для MS SQL Server строку подключения к БД. Сделать это нужно в файле проекта appsettings.json.Ниже приведен пример строки подключения.

```json
 "ConnectionStrings": {
   "DefaultConnection": "Server=.;Database=BookAPI;Trusted_Connection=True;TrustServerCertificate=True;"
 }
```

Далее, когда вы создали подключение к БД, обновите БД в консоли. И запустите программу.
После этого, заходите на сайт (для https подключения) https://localhost:7175, где вам нужно зарегистироваться в registration действии.Ниже пример регистрации.
```json
{
  "email": "Admin@admin.com",
  "password": "E1g#ne"
}
```

Далее тоже самое, что мы написали в действие registration нужно написать в действие login для авторизации и полученни access-токена.
После получение токена вводим его в Postman, либо же на имеющемся сайте открываем действие и вводим запрашиваемые данные.




