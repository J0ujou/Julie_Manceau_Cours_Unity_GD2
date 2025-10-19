# Julie_Manceau_Cours_Unity_GD2
cours et exercices UNITY
///////
// Exercice Roll a Ball pour le 5 Novembre 2025 //
Nom du projet: "Roll’n’Find"
Présentation du projet:
  Dans ce jeu, le joueur contrôle une petite boule se déplaçant à travers un labyrinthe.
  L’objectif est de collecter tous les objets disséminés dans le niveau avant la fin du temps imparti.
  Les objets sont visibles au départ, mais deviennent invisibles après quelques secondes, obligeant le joueur à mémoriser leur emplacement pour tous les récupérer.
Intention:
  Le jeu doit présenter:
  - 2/3 niveaux différents
  - une balle mobile
  - des collectibles à ramasser qui deviennent invisibles après un certain temps
  - un marquage quand on récupère un collectible (exemple: 2 / 10 objets) et marquage du temps restant
  - un sound design de base ( musique de fond )
  - un HUD de menu start, victoire et défaite
  - condition de victoire: ramasser un nombre d'objets avant la limite de temps / condition de défaite: le temps est écoulé avant d'avoir ramassé le nombre d'objets demandé
  - effets lié au temps: la partie limité par le temps, récupération de bonus et malus qui respectrivement accélère la vitesse du joueur, ralenti sa vitesse (les bonus et malus deviennent transparents comme les collectibles)
  - une apparition de gameobject conditionnelle: après avoir ramassé un objet, un bonus devient visible
  - un autre type de collectible qui permet l'activation d'une zone de mémoritation, avec son HUD associé (exemple: 1 / 1)
  - un effet environemental bénéfique: la zone de mémorisation. Activée quand le joueur ramasse son énergie: une fois dessus elle affiche brievement tous les collectibles restants
  - défaite environnemental : une zone empoisonnée à éviter (emplacement à mémoriser car elle devient invisible aussi
  - possibilité de sauter car présence de petits murs qui sont traversable en sautant
  - un sound design avancé (son contextuel)
  - un menu settings pour réglage du son
  - un level design avec un labyrinthe très simplifié, différent selon les niveaux
  - des cohérences sur les couleurs/matières/lumières
Compte-rendu par jour:
///////_18/10_///////
- j'ai modifié l'affichage de la récupération de point et modifié le code pour avoir une limite. Pour l'instant j'ai laissé le nombre de collectible à prendre à 5.
- Quand le max est récupéré le widget de victoire s'affiche (il n'y a que un fond avec victory) et j'ai aussi instancié les autres widgets (sans m'appliquer sur l'esthétique): game over, start: ils ont des boutons, pour l'instant seul le commencer, recommencer et quitter fonctionnent. J'ai fais en sorte que quand on recommence, tout est remis à 0 (points et compte à rebours)
- J'ai ajouté un compte à rebours et le j'ai affiché. Il se lance quans je commence la partie. Pour l'instant il est à 60 secondes. Si il arrive à 0 avant d'avoir récupéré les 5 collectibles, le widget game over s'affiche
- j'ai essayé d'ajouter un système de saut au personnage mais il saute sans limite, à régler à la prochaine session
 
Compte-rendu final: 
