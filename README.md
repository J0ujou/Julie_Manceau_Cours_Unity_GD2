# Julie_Manceau_Cours_Unity_GD2

Cours et exercices UNITY

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

///////_19/10_///////
- j'ai réglé le système de saut en vérifiant si la boule touche le sol
- j'ai ajouté un système où tous les collectibles (qui se nomment maintenant Fragment) disparaissent 5 sec après lancement du jeu (temps de memorisation à modifier si il est trop court)
- j'ai créé un malus qui ralenti la boule pendant 5 sec, pareil pour le bonus (ils peuvent etre ramassés)
- au lieu de faire spawn des murs, un bonus spawn quand je ramasse un fragment mais l'effet du bonus ne s'applique pas (problème avec référence préfab: je demande de lancer un caroutine mais il ne se lance pas car la référence de player movement dans mon bonus c'est le prefab player, et comme un prefab n'est pas actif cela ne marche pas) --> problème à régler
- j'ai commencé la mise en place du second collectible: la clé pour activer la zone de mémorisation ( pour l'instant elle s'appelle target hard mais j'ai séparé son score data avec celui des fragments --> à continuer car l'affichage reste encore associé aux fragments

///////_20/10_///////
- j'ai arrangé l'affichage de la clé (second collectible)
- il doit permettre l'utilisation de la zone bénéfique, alors je l'ai créer, il faut faire la fin du code (j'ai juste fait les conditions)
- j'ai créé la défaite environnementale (manque fin script)
- je n'ai pas encore réglé le probleme d'apparition du bonus fonctionnel après récupération du fragment (manque de temps) --> voir à prochaine session

 ///////_26/10_///////
 - j'ai essayé de faire le système de memoryzone mais je n'y arrive pas, je comprend la logique mais je n'arrive pas à correctement l'appliquer en code
 - j'ai voulu essayer une solution trouvée sur internet mais elle ne fonctionnait pas.
 - j'ai tout de même réussi à lier la clef avec la memoryzone.
 - j'ai terminée la zone poison en affichant game over si je la touche
 - j'ai réussi l'apparition des bonus qui fonctionne avec une nouvelle commande. Au start j'initialise la ref playermovement en récupérant le premier objet de type player movement. ( _playerMovement = Object.FindFirstObjectByType<PlayerMovement>();) j'ai appris que c'était l'équivalent du get actor of class de unity. J'ai essayé de trouver une autre solution pour régler ce problème mais avec le temps limité j'ai dû laisser cette option.)

 ///////_27/10_///////
 - j'ai réfléchi sur papier aux 2 différents level designs pour les deux niveaux du jeu.
 - j'ai cherché différents sons pour le jeu (musiques, sons contextuels...)
 - j'ai importé les sons sur le projet
 - j'ai modifié le nom des deux map

///////_28/10_///////
- j'ai essayé d'ajouter les sons mais cela ne fonctionnait pas

///////_29/10_///////
- Je suis retourné sur la memory zone et j'ai essayé de tester une autre technique: j'ai fais un update puis j'ai demandé si le joueur avait la clef et qu'il était dans la zone, si oui, les fragments s'affiche
- Cette technique a des limites car l'update donne beaucoup trop de fois l'ordre en peu de temps ce qui stoppe le fonctionnement au bout de plusieurs utilisations
- j'ai réussi à associer chaque action à un son et à mettre les musiques de fond.

///////_30/10_///////
- j'ai copié collé le niveau 1 pour faire le 2
- j'ai stoppé les mouvements du joueurs avant qu'il ne commence à joueur et quand il arrete de jouer (victoire et game over)
- le bouton restart reset le jeu au début (niveau1)

///////_31/10_///////
- j'ai changer le fond du jeu pour ajouter de l'esthétique (à voir pour le changer car image test)
-  j'ai ajusté la caméra pour qu'on puisse voir une vue d'ensemble du jeu (caméra fixe)
-  j'ai fait le level design des deux niveaux
-  j'ai ajusté le saut pour que le joueur ne saute pas trop haut
-  j'ai ajusté la taille des collectibles pour que le joueur soit obligé de les récupérer
-  j'ai ajusté quelques widgets pour le niveau 2 (restart, victory...)

//////_01/11_///////
- j'ai changé le code de la memory zone et il marche sans bug
- par contre c'est avec un find object by type
- je récupère dans une liste tous mes fragments puis lorsque la memoryzone capte en trigger le joueur qui a la clef, alors il montre tous les fragments de la liste
- le soucis c'est qu'il affiche même ceux qui ont récupéré (avec le temps limité je laisse cette problématique de côté pour terminer le projet)
- j'ai importé des images pour un nouveau fond de partie, pour le fond de mes widgets et de certains boutons
- j'ai créer des widgets tuto que j'ai codé pour qu'ils s'affichent au bon moment (but du jeu, clef et memory zone)
- j'ai commencé a créer un panel audio settings que j'ai caché. Le temps qu'il reste avant le rendu du projet m'oblige à laisser ce bonus de coté pour privilégier l'aspect esthétique et équilibrage de mon jeu qui n'est pas terminé.
- je n'ai pas pu faire l'esthétique des widgets

//////_02/11_///////
- j'ai fait l'esthétique de mes widgets car la conversion en sprite des images a enfin fonctionnée.
- j'ai changé quelques boutons mais je doit modifier leur taille
- j'ai changé la couleurs de tous les éléments de mon jeu pour les assortir avec mon HUD.
- Par manque de temps, je risque de laisser les éléments seulement coloré, même si mon projet de base était d'ajouter des assets et des textures pour ajouter un peu plus de vie au jeu.
- j'ai ajouté des images îcones pour expliquer les touches à utiliser pour les déplacements.
Compte-rendu final: 
