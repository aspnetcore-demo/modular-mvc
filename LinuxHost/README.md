# Hosting In Ubuntu


Microsoft [blog](https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/linux-apache?view=aspnetcore-7.0)

## System Information

### DotNet
`dotnet --info`
```
NET SDK:
 Version:   7.0.101
 Commit:    bb24aafa11

Runtime Environment:
 OS Name:     ubuntu
 OS Version:  22.04
 OS Platform: Linux
 RID:         ubuntu.22.04-x64
 Base Path:   /usr/share/dotnet/sdk/7.0.101/

Host:
  Version:      7.0.1
  Architecture: x64
  Commit:       97203d38ba

.NET SDKs installed:
  7.0.101 [/usr/share/dotnet/sdk]

.NET runtimes installed:
  Microsoft.AspNetCore.App 7.0.1 [/usr/share/dotnet/shared/Microsoft.AspNetCore.App]
  Microsoft.NETCore.App 7.0.1 [/usr/share/dotnet/shared/Microsoft.NETCore.App]

Other architectures found:
  None

Environment variables:
  Not set

global.json file:
  Not found
```


## Publish App

```
dotnet publish --configuration Release
sudo cp -R `bin/Release/net7.0/publish/` `/var/www/modularmonolith`
sudo chown -R www-data:www-data /var/www/modularmonolith
```


## Linux Service 

Service configuration file

`sudo nano /etc/systemd/system/modularmonolith.service`

```
[Unit]
Description=Modular Monolith - ASP.NET Core Web App.

[Service]
WorkingDirectory=/var/www/ModularMonolith
ExecStart=/usr/share/dotnet/dotnet /var/www/ModularMonolith/ModularMonolith.dll
Restart=always
RestartSec=10
KillSignal=SIGINT
SyslogIdentifier=ModularMonolith
User=www-data
Environment=ASPNETCORE_ENVIRONMENT=Production 
Environment=ASPNETCORE_URLS=http://localhost:5000
[Install]
WantedBy=multi-user.target
```

Enable service.
```
sudo systemctl enable modularmonolith.service
sudo systemctl start modularmonolith.service
sudo systemctl status modularmonolith.service
sudo journalctl -u modularmonolith.service # Listent to the service log
sudo journalctl -fu modularmonolith.service
sudo journalctl -fu modularmonolith.service --since "2016-10-18" --until "2016-10-18 04:00"
``` 


### Apache2

`apache2 -v`
```
Server version: Apache/2.4.52 (Ubuntu)
```


Apache2 virtual host config

```
sudo nano /etc/apache2/sites-available/modularmonolith.conf
```

```
<VirtualHost *:*>
    RequestHeader set "X-Forwarded-Proto" expr=%{REQUEST_SCHEME}
</VirtualHost>

<VirtualHost *:80>
    ProxyPreserveHost On
    ProxyPass / http://127.0.0.1:8080/
    ProxyPassReverse / http://127.0.0.1:8080/
    ServerName 127.0.0.1
    ServerAdmin codeanit@gmail.com
    ErrorLog ${APACHE_LOG_DIR}/modularmonolith/error.log
    CustomLog ${APACHE_LOG_DIR}/modularmonolith/access.log common
</VirtualHost>
```

Enable virtualhost
```
sudo a2ensite modularmonolith.conf
```