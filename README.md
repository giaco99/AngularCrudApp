Aprire il file "PluServiceCoreApi\PluServiceCoreApi\appsettings.json" e modificare il file con la propria connection string in questo modo :

"AllowedHosts": "*",
  "ConnectionStrings": {
    "SqlServer": " Data Source=SQLSERVERPATH;Initial Catalog=DATABASENAME;User ID=DATABASEUSER;Password=DATABASEPWD;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
  }
 
All'interno del progetto di backend è stato utilzzato entity framework che creerà la struttura del db nel vostro server sql , per fare questo
aprire un "Package Manager Console" e lanciare il comando "Update-Database" .

Per far comunicare client e server lanciare prima la Web API e poi il progetto Client .
All'interno del progetto client l'URL base della API è specificato all'interno di questo file "AngularClient\src\environments\environment.ts" nel parametro baseApiUrl,
modificare il valore del parametro con il proprio URL .
