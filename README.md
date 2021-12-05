## About Sondage Project

### EN

It is an ASP.NET core web project in MVC, which aims to create surveys and display the results once they are completed.

### FR

C'est un projet Web ASP.NET core en MVC, qui a pour but de créer des sondages et d'en afficher les résultats une fois ceux-ci terminer.


### Installation step:
```
1. Nettoyer et générer la solution
2. Restaurer les packages nuGet
3. Créer la bdd et modifier connexion dans appsettings.json (table Sondage : ID (INT AUTO-INCREMENT NOT NULL), Descriptif VARCHAR(500) NOT NULL, Question_1 VARCHAR(500) NULL, Question_2 VARCHAR(500) NULL, Question_3 VARCHAR(500) NULL, Question_4 VARCHAR(500) NULL)
4. faire les migrations (dotnet ef migrations add nom_migrations -p ../(repo des data/file.csproj)) et faire executer avec dotnet migrations update  
```

### Programmation step :
```
1. Mise en place du système de Connection/Authentification (dossier Sondage_Projet.Services / Injection dépendance / Fichiers Auth et Controllers / Authentification Cookie)
2. Création d'un formulaire d'identification, de connection (ajout d'un lien de connection sur la page de garde)
3. Mise en place de la page de création de sondage (Dossier Sondage_Projet.Data / Injection dépendance / package Nuget / Controllers / View / Migration / Repository)
```
