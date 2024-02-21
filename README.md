# Задание для курсов SolarLabTask

### Для того, чтобы запустить проект, необходимо:
  1. Создать файл appsettings.json c конфигурацией БД, пример
   ```
    "ConnectionStrings": {
    "DefaultConnection": "Host=ВашХост;Port=ВашПорт;Database=ВашаБазаДанных;Username=ВашЛогин;Password=ВашПароль"
   }
```
  2.   Запустить docker-compose
  3.   Создать базу данных при помощи команд
     
     
      Add-Migration Initial
      Update-Database
    
    
4. Приступать к проверке =)

### Если во время сборки произошла ошибка:
1. Остановить контейнер с приложением ASP.NET Core MVC
2. Выполнить 3 пункт
3. Запустить приложение локально/при помощи Docker
