
# Restaurant API - ASP.NET Core Web API

Une API qui permet aux clients de découvrir et de reproduire les recettes emblématiques du restaurant chez eux. Ce projet vise à enrichir l'expérience du client en lui donnant un aperçu des coulisses culinaires du restaurant.

## Modalités Pédagogiques

- Activité en équipe de 3 (ou 2)  personnes.
- Deadline: 6 jours.
  
## Étapes du Projet

### 1. Planification du Projet

- Définition des endpoints de l'API.
- Elaboration de la documentation de l'API à l'aide de Swagger.
- Utilisation de la méthode SCRUM pour une gestion de projet efficace.
- Désignation d'un scrum master.
- Le PO est le formateur.
- Mise en place de Kanban avec lien entre issue et branche.
- Backlog, sprint de 2 jours, daily, revue, retrospective.

### 2. Découpage Technique

- Création des modèles de données pour les recettes, ingrédients et méthodes de préparation.
- Mise en œuvre des contrôleurs API.
- Sécurisation de l'API.

### 3. Développement

- Implémentation des routes API pour l'ajout, la mise à jour, la suppression et la consultation des recettes.
- Tests unitaires et d'intégration.

## Fonctionnalités Principales de l'API

- Consultation des recettes : Accès détaillé aux recettes avec ingrédients et étapes.
- Gestion des recettes : Interface pour le personnel du restaurant pour ajouter et modifier les recettes.

## Eléments Techniques Attendus

- Architecture RESTful.
- Utilisation du pattern Repository avec l'injection de dépendance.
- Authentification et autorisation pour l'accès sécurisé.
- Base de données PostgreSQL ou MongoDB via Docker.
- Tests unitaires et d'intégration.

## Modalités d'Évaluation

Présentation de l'API devant un jury:

- Démonstration des fonctionnalités via des requêtes API.
- Explication de la structure du code et des choix techniques.

 ## Modèle conceptuel de données


![MCD-MF](https://github.com/simplon-lille-csharp-dotnet/RecettesAPI-MFMC/assets/150059186/4f2509b4-5769-4c9e-b655-b9c04401d77e)
![MLD-MF](https://github.com/simplon-lille-csharp-dotnet/RecettesAPI-MFMC/assets/150059186/e77d4298-384b-42b5-ab66-a0869a123569)

![MPD-mf](https://github.com/simplon-lille-csharp-dotnet/RecettesAPI-MFMC/assets/150059186/c3565d9d-b6dd-438c-81a9-44a84934e389)

## Cas d'utilisation

![cas](https://github.com/simplon-lille-csharp-dotnet/RecettesAPI-MFMC/assets/150059186/bd886533-1f00-4ca2-87a5-465342633058)

## Comment Exécuter le Projet

Assurez-vous d'avoir .NET 8.0 installé sur votre machine.

1. Clonez le projet : `git clone https://github.com/simplon-lille-csharp-dotnet/RecettesAPI-MFMC.git`
2. Accédez au répertoire du projet : `cd RecettesAPI`
3. Installez les dépendances : `dotnet restore`
4. Lancez l'application : `dotnet run`



