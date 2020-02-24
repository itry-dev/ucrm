# ucrm - unconventional crm

Do you need something simple to track hours spent everyday on a customer project? Try ucrm.

Website developed using [Nuxt](https://nuxtjs.org/)

Don't like Nuxt? No problem, your not tied to it, you can build your own website.

Webservice developed in C# and [netcore](https://dotnet.microsoft.com/download)

Database at your choice, just use the one you prefer on appsettings.json, project CrmApi

```bash
"ConnectionStrings": {
    "DefaultConnection": "data source=localhost;Database=crm;User Id=crm;Password=a_complicated_password;multipleactiveresultsets=true;Integrated Security=False",
    //"DefaultConnection": "Server=localhost;Database=crm;User=crm;Password=a_complicated_password;"
  }
````

Then run migrations

```bash
dotnet ef database update
```

## Available functionalities

1. Create / Modify Customers
2. Create / Modify Projects
3. Create / Modify Worked Hours, using a calendar
4. Export worked hours on a csv file

Do you have a linux machine? Install the webservice using the script below, this is what I did on my Raspberry PI 4

## Use this script to create a new service

```bash
[Unit]

Description=CRM .netcore Api

[Service]

WorkingDirectory=[** path to CrmApi webservice folder **]

ExecStart=[** path to dotnet folder **] [** path to CrmApi webservice folder **]/CrmApi.dll

Restart=always

RestartSec=10

KillSignal=SIGINT

SyslogIdentifier=crm_api

User=[** a user that can run this service **]

Environment=ASPNETCORE_ENVIRONMENT=Production

Environment=DOTNET_PRINT_TELEMETRY_MESSAGE=false


[Install]

WantedBy=multi-user.target
```

Installing the service and checking that everything is ok

```bash
sudo systemctl enable crm_api.service
sudo systemctl status crm_api.service
```

## Nginx webserver? This is the configuration file you need


```bash
server {
        server_name crm.local;

#if you want to access the website on a different port
#        listen 81;
#        listen [::]:81;

        gzip on;
        gzip_types text/plain application/xml text/css application/javascript;
        gzip_min_length 1000;


        location / {
                #path to website folder
                root /var/www/html/crm/website;

                proxy_pass http://localhost:3000;
                proxy_http_version 1.1;
                proxy_set_header Upgrade $http_upgrade;
                proxy_set_header Connection keep-alive;
                proxy_set_header Host $host;
                proxy_cache_bypass $http_upgrade;
                proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
                proxy_set_header X-Forwarded-Proto $scheme;
        }
        
        location /api {
                #if you want to use a different port make the change also in appsettings.json file on CrmApi project
                proxy_pass http://localhost:5002;
                proxy_http_version 1.1;
                proxy_set_header Upgrade $http_upgrade;
                proxy_set_header Connection keep-alive;
                proxy_set_header Host $host;
                proxy_cache_bypass $http_upgrade;
                proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
                proxy_set_header X-Forwarded-Proto $scheme;
        }
}
```
