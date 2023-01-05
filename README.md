# ParentSpy

***Часть приложения родительского контроля*** - Windows Service родительского контроля на ASP.NET Core 

***Строка подключения сервиса в PowerShell New-Service -Name ParentSpy -BinaryPathName "C:\Parent_Spy\Parent_Spy.exe"***

Через appsettings.json задается строка подключения к SQLite БД браузера Mozilla Firefox на локальном компьютере и адрес расположения файла hosts. 

***Функционал сервиса доступен аутентифицированным пользователям, аутентификация осуществляется посредством JWT-токена.***

***WEB API:***

http://localhost:5100/ParentSpy/echo - проверка работоспособности сервиса - POST

http://localhost:5100/ParentSpy/echoGet - проверка работоспособности сервиса - GET

http://localhost:5100/ParentSpy/sites - Список сайтов (журнал браузера Mozilla Firefox) - POST

http://localhost:5100/ParentSpy/files - Список файлов (загрузки в браузере Mozilla Firefox) - POST 

http://localhost:5100/ParentSpy/block/site - Блокировка сайта - POST 

http://localhost:5100/ParentSpy/unblock/site - Разблокировка  веб-сайта на компьютере - POST

http://localhost:5100/ParentSpy/getFile?filePath=filePath - Загрузка файла с компьютера - POST 


***Порт 5100 задан через Kestrel***

Блокировка/разблокировка сайта осуществляется путем внесения/удаления адреса сайта в файле hosts.

![1](https://github.com/Presstomsk/Parent_Spy/blob/master/jpg/vc.jpg)

![2](https://github.com/Presstomsk/Parent_Spy/blob/master/jpg/hosts.jpg)

![3](https://github.com/Presstomsk/Parent_Spy/blob/master/jpg/BlockedVK.jpg)



