# Contenedor Docker de Redis

Este proyecto utiliza Docker únicamente para ejecutar Redis. La API .NET y SQL Server se ejecutan fuera de Docker.

## Requisitos

- Docker Desktop instalado y en ejecución.
- Docker Compose disponible mediante `docker compose`.
- Puerto `6379` disponible en el equipo local.

## Levantar Redis

Desde la raíz del repositorio, ejecutar:

```powershell
docker compose up -d redis
```

El comando descarga la imagen `redis:7-alpine` si todavía no está disponible, crea el contenedor y lo inicia en segundo plano.

Redis quedará disponible en:

```text
localhost:6379
```

## Verificar el estado

Comprobar que el contenedor está ejecutándose:

```powershell
docker compose ps
```

El servicio `redis` debe aparecer con estado `Up` y publicado mediante `6379:6379`.

También se puede comprobar la respuesta de Redis con:

```powershell
docker compose exec redis redis-cli ping
```

La respuesta esperada es:

```text
PONG
```

## Configuración de la aplicación .NET

La aplicación utiliza la cadena de conexión definida en `Desafio2_DES/appsettings.json`:

```json
"ConnectionStrings": {
  "Redis": "localhost:6379"
}
```

Por tanto, al ejecutar la API desde Visual Studio o mediante `dotnet run`, se conectará al Redis publicado por Docker.

## Consultar los logs

```powershell
docker compose logs -f redis
```

Para salir de la visualización de logs, pulsar `Ctrl+C`. Esto no detiene el contenedor.

## Detener Redis

Para detener y eliminar el contenedor, manteniendo los datos persistidos:

```powershell
docker compose down
```

Los datos se almacenan en el volumen Docker `redis_data`.

## Eliminar también los datos

Para detener Redis y eliminar el volumen asociado:

```powershell
docker compose down -v
```

Esta acción elimina los datos persistidos de Redis y debe utilizarse únicamente cuando sea necesario empezar con una instancia limpia.

## Levantamiento limpio

Si existían contenedores de una configuración anterior, ejecutar:

```powershell
docker compose down
docker compose up -d redis
```

Después, verificar el estado con:

```powershell
docker compose ps
```

> Nota: `docker-compose.yml` y `Desafio2_DES/compose.yaml` contienen la configuración equivalente para ejecutar únicamente Redis.
