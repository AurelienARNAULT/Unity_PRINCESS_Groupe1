**A WONDERFUL TRIP**

BEN AISSA Weel
TRICOT Thomas
ARNAULT Aurélien
CHATELAIN Baptiste
PERRAUDEAU EMILIEN

**POUR LANCER LE PROJET** : 
Selon les versions d'unity lorsqu'on import notre projet il peut manquer le package "cinemachine" il faut donc l'installer pour cela : 
Window -> package Manager -> Changer la cible de la recherche en "Unity Registry" -> taper dans la barre de recherche "cinemachine" puis cliquer en bas a droite sur install.
Ensuite il faut ajouter au build settings les scènes suivantes dans le bon ordre : 
-MainMenu/MainMenu                                                    0
-Aurelien/Scenes/portail/portail                                      1
-Baptiste/Scenes/Game                                                 2
-Emilien/Scenes/Introduction/Introduction                             3
-Thomas/Scenes/SampleScene                                            4
-Emilien/Scenes/Snake/Snake                                           5
-Emilien/Scenes/Finition/Finition                                     6
-Weel/Display room/Scene                                              7

Dans le cas où vous n'arrivez pas a ajouter les scenes dans le bon ordre nous vous avons mis un .exe afin de tester le jeu avec le menu et les boutons qui fonctionnent


**FONCTIONNEMENT DU JEU + SOURCES :** 

*Dans tout les mondes on peut appuyer sur P pour mettre pause et retourner au menu principal*

**1-Museum of Art and motions:** 

Le musée regroupant nos animations blender du rendu TD3
Source:
https://unityassetcollection.com/showroom-environment-free-download/ (pour l’environnement du musée)



**2-A Wonderful Trip :** 
Le but du jeu est de collecter des diamants à travers différents paysages. Il y a 6 paysages et un diamant par paysage. Il y a donc 6 diamants à collecter. Une fois collecté, le menu de fin s’affiche, il suffira alors de choisir avec les flèches un bouton et de le sélectionner avec la touche “enter”. 
Pour voyager d’un paysage à un autre il faut emprunter des portails. Afin de simplifier leur localisation, ceux-ci sont muni d’un halo de lumière verticale de couleur violet s’élevant dans le ciel. Les diamant possède eux aussi c’est halo, mais de couleur bleu pour pouvoir les différenciers des portail. 
**Commandes pour jouer:**
w : avancer
s : reculer
a : tourner a gauche
d : tourner à droite
p : menu pause

**Source:**
https://www.youtube.com/@KetraGames
https://assetstore.unity.com/packages/3d/environments/dungeons/low-poly-dungeons-lite-177937
https://www.youtube.com/watch?v=cWpFZbjtSQg&ab_channel=SebastianLague
https://unityassetcollection.com/lowpoly-style-ultra-pack-free-down3load/
https://www.youtube.com/@DerekBrandonFiechter


**3-Tropic Mini Golf :** 

Le but du jeu est de finir trois niveaux de mini golf correspondant au niveau facile moyen et difficile en un minimum de coups. 
**Commandes pour jouer:**
direction souris : faire pivoter la caméra
left-click : maintenir pour tirer la balle avec un indicateur

**Spécification:**
Pour le mini golf, un problème lié à unity est présent. En effet, avec un timestamp élevé et donc un faible taux de calcul par seconde, les collisions ont tendance à être erronées. Pour pouvoir profiter pleinement du jeu, il faut mettre une valeur de timestamp très faible (uniquement pour ce jeu pour ne pas détériorer les autres). Cependant, étant donné que le nombre de calculs par seconde augmente fortement, il est conseillé d’avoir une bonne configuration matérielle.

Source:
https://www.kenney.nl/assets/minigolf-kit
https://assetstore.unity.com/packages/3d/environments/nature-environment-tropical-island-lite-low-poly-3d-by-justcreat-242437
https://assetstore.unity.com/packages/vfx/shaders/mobile-depth-water-shader-89541
https://assetstore.unity.com/packages/3d/environments/low-poly-rock-pack-57874
https://assetstore.unity.com/packages/3d/environments/fantasy/polyart-ancient-village-pack-166022
https://sketchfab.com/3d-models/low-poly-tree-house-a4a46345a7344dc7b98f5073998769e0
https://creazilla.com/nodes/5116-pirate-kit-3d-model
https://assetstore.unity.com/packages/3d/environments/stylized-flora-pack-lite-77400
https://sketchfab.com/3d-models/free-volcano-low-poly-516e0bd4e78d4f5caed3f00f056e2e3a
https://assetstore.unity.com/packages/3d/environments/free-low-poly-raft-on-the-desert-141948

**4 - The Princess and the Snake :**
Le but du jeu est de manger 4 fruits pour terminer le jeu. Néanmoins, tous les 3 fruits mangés par le King Snake, cela réduit le score du joueur de 1. Il devra donc manger 1 fruit en plus afin de finir le jeu.
**Commandes pour jouer:**
il suffit de cliquer sur le bouton “Jouer au jeu” pour rejoindre la scène principale du jeu Snake. Une fois sur cette scène vous pouvez déplacer votre serpent avec les touches :
Z / “haut” du clavier : aller en haut
S / “bas” du clavier: aller en bas
Q / “gauche” du clavier: aller à gauche
D / “droite” du clavier : aller à droite
ainsi que : 
P : menu pause
**Source:**
Tuto suivi afin de faire la base du snake : https://youtu.be/U8gUnpeaMbQ

**5-Race Cars :**

**ressource pour le jeu de voiture :** 
https://assetstore.unity.com/packages/tools/physics/prometeo-car-controller-209444
https://assetstore.unity.com/packages/3d/environments/urban/low-poly-park-61922
https://assetstore.unity.com/packages/3d/environments/urban/low-poly-european-city-pack-71042
