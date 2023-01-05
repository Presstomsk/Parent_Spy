# ParentSpy

***Часть приложения родительского контроля*** - Windows Service родительского контроля на ASP.NET Core 

***Строка подключения сервиса в PowerShell New-Service -Name ParentSpy -BinaryPathName "C:\Parent_Spy\Parent_Spy.exe"***

***WEB API:***

http://localhost:5100/ParentSpy/echo - проверка работоспособности сервиса - POST

http://localhost:5100/ParentSpy/echoGet - проверка работоспособности сервиса - GET

http://localhost:5100/ParentSpy/sites - Список сайтов (журнал браузера Mozilla Firefox) - POST

http://localhost:5100/ParentSpy/files - Список файлов (загрузки в браузере Mozilla Firefox) - POST 

http://localhost:5100/ParentSpy/block?site=url - Блокировка сайта - POST 

http://localhost:5100/ParentSpy/getFile?filePath=filePath - Загрузка файла с компьютера - POST 


***Порт 5100 задан через Kestrel***

