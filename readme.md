## Upd8 Api:

Build do Container:

```docker build -f src/Upd8.Api/Dockerfile -t upd8api_image .```

Iniciar Container:
```docker run --name upd8api_container -p 8001:80 upd8api_image .```

## Upd8 Web:

Build do Container:

```docker build -f src/Upd8.Web/Dockerfile -t upd8web_image .```

Iniciar Container:
```docker run --name upd8web_container -p 8000:80 upd8web_image .```
