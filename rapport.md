 	Rapport — ScanTrack AB: Containerisera och deploya din nod

Grupp:
Deltagare: Kevin Hermansson
Datum: 2026-09-07
Namn: Kevin Hermansson

1. Arkitektur

Vi byggde noden som en Docker-container med en multi-stage Dockerfile.

Dockerfile → docker build → ACR → ACI → publik DNS-adress

Först byggdes appen lokalt och testades. Sedan pushades imagen till Azure Container Registry. Efter det deployades imagen till Azure Container Instances.

Min nod kör staden Örebro.

2. NODE_URL-problemet

Problemet var att containern behövde veta sin egen publika adress i NODE_URL, men adressen får man först när containern är skapad.

Jag löste det genom att använda ett fast DNS-namn:

http://scantrack-orebro-kevin.swedencentral.azurecontainer.io:8080

På så sätt kunde samma adress användas även om containern behövde skapas om.

3. Bevis

Här lägger jag in skärmdumpar på:

GET /status från Örebro-noden
Loggar från az container logs

Exempel från loggen:

Paket PKG-C4A408 anlände till Örebro
Vidarebefordrar PKG-C4A408: Örebro → Gävle
Skickade paket PKG-C4A408 vidare till Gävle

Det visar att ett paket faktiskt passerade min nod.

4. Ansvarsområden

Jag ansvarade främst för min egen nod, Örebro.

Jag gjorde bland annat:

Dockerfile
Docker build
Push till ACR
Deploy till ACI
Miljövariabler
Test av /status
Test av paket mellan noder
Heartbeat mot registret
Individuell reflektion

Vad var svårast?
Det svåraste var Azure-deployen och att få ACI att kunna hämta imagen från ACR.

Vad förstår du nu som du inte förstod innan?
Jag förstår bättre hur Docker, ACR och ACI hänger ihop och hur en container kan köras i Azure.

Vad skulle du ha gjort annorlunda?
Jag hade testat mer steg för steg och kollat loggarna tidigare när något inte fungerade.

Hur planerades projektet?
Vi tog en del i taget. Först kod och Docker, sedan ACR och sist ACI och tester.

Hur fungerade samarbetet?
Vi jobbade mest med våra egna noder men kunde testa mot varandras noder och hjälpa till när något inte fungerade.
