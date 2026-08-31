Résumé des changements et instructions rapides:

- Ajout des modèles de données: PlayerTemplate (ScriptableObject), PlayerInstance, TeamData, ClubDataSO
- Ajout des managers: SaveManager (sauvegarde JSON), GameManager (initialisation runtime, chargement/instantiation de club), MatchManager (simulation basique)
- Ajout d'une vue de match simple (MatchView) pour afficher les événements avec TextMeshPro
- Refactor léger de ClubDatabase pour lire les données depuis GameManager.CurrentClub

Que faire après pull:
1) Ouvrir Unity (version ciblée fournie). Assigner un GameObject dans la scène avec le script GameManager et lier l'initialClub (optionnel) si tu veux utiliser un asset ScriptableObject comme template.
2) Créer un asset (Assets -> Create -> Game -> ClubData) pour définir un club initial si souhaité.
3) Placer un objet UI (TextMeshProUGUI) et assigner MatchView.eventsText si tu veux visualiser les matchs.
4) Vérifier que SaveManager est présent (il est créé à runtime par GameManager si absent). Sauvegarde automatique à la fermeture d'application.

Commit message: "Add core data models, managers, match simulation, and integrate ClubDatabase with GameManager/SaveManager"
