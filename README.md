# ScanTrack Node

A distributed .NET Web API for routing and forwarding packages between Swedish cities.

## Overview

ScanTrack Node is a containerized ASP.NET Core application that represents one node in a distributed package delivery network.

Each node:
- Registers itself with a central registry
- Receives packages via HTTP
- Calculates the shortest route using Dijkstra's algorithm
- Forwards packages to the next node
- Keeps track of package history to prevent routing loops

## Tech Stack

- .NET 8
- ASP.NET Core Web API
- Docker
- Azure Container Instances
- Azure Container Registry
- Dijkstra's shortest path algorithm

## API Endpoints

| Method | Endpoint | Description |
|---|---|---|
| POST | `/paket` | Receives and forwards a package |
| GET | `/paket` | Lists delivered packages |
| GET | `/status` | Health/status endpoint |
| GET | `/route?from=X&to=Y` | Calculates the shortest route |
| GET | `/swagger` | Swagger API documentation |

## Environment Variables

| Variable | Description |
|---|---|
| `CITY_NAME` | Name of the city represented by the node |
| `NODE_URL` | Public URL of this node |
| `REGISTRY_URL` | URL of the central node registry |

## Run locally

```bash
cd ScanTrackNode
dotnet restore
dotnet run