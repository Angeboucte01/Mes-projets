
//Declaration des variables 
let canvas, ctx, width, height;
let tuille, donjon, fondEcran, tresor, piege;
let afficheBase, affichageJeu, boutonLancement, boutonSortie, grandeBoite, plusGrandScore;
let tableau = [];
let largeurInterface = 25;
let hauteurInterface = 20;
let boite, scoreEmplacement, nouv;
let maximun_boite = 40;
let etat, score;
let haut, bas, gauche, droit, affiche, autreAffiche;
let positionJoueur = { x: 12, y: 7 };
let debut = false;
let fin = false;

//Declaration d'une fonction qui donne la nature du tableau qui est un canvas en 2d et donne sa largeur ainsi que sa hauteur
function initialisaionJeu() {
   canvas = document.getElementById("canva");
   ctx = canvas.getContext("2d");
   width = canvas.width = largeurInterface * 25;
   height = canvas.height = hauteurInterface * 15;


// Recuperation des element a travers leurs ID
   afficheBase = document.getElementById("afficheBase");
   affichageJeu = document.getElementById("affichageJeu");
   boutonLancement = document.getElementById("boutonLancement");
   boutonSortie = document.getElementById("boutonSortie");

   haut = document.getElementById("bouton_haut");
   bas = document.getElementById("bouton_bas");
   gauche = document.getElementById("bouton_gauche");
   droit = document.getElementById("bouton_droit");
   affiche = document.getElementById("afficheFin");
   autreAffiche = document.getElementById("afficheFin1");

   boite = document.getElementById("evolution");
   nouv = document.getElementById("nouv")
   scoreEmplacement = document.getElementById("scoreEmplacement");


   grandeBoite = document.getElementById("plusGrandScore");

   plusGrandScore = localStorage.getItem("plusGrandScore");
   if (plusGrandScore) {
      grandeBoite.innerHTML = plusGrandScore;
   }

   boutonLancement.addEventListener("click", () => {
      commencerJeu
         ()
   });
   boutonSortie.addEventListener("click", () => {
      SorirJeu
         ()
   });

   positionElement();
 // Declaration des images
   piege = new Image();
   tuille = new Image();
   fondEcran = new Image();
   tresor = new Image();
   donjon = new Image();

// Recuperation des images dans le fichier img
   fondEcran.src = "img/fondEcran.png";
   tresor.src = "img/tresor.png";
   donjon.src = "img/donjon.png";
   tuille.src = "img/tuille.png";
   piege.src = "img/piege.png";

}
// Fonction qui donne la position exacte du joueur au debut du jeu
function commencerLeJeu() {
   etat = maximun_boite;
   score = 0;
   positionJoueur = { x: 12, y: 7 };

   miseAjourScore();

   tableau = initialisationTab();

   miseAjourJeu();

   debut = true;
   fin = false;
}
// Initialisation et creation du tableau 
function initialisationTab() {
   let _tableau = [];
   for (let i = 0; i < 15; i++) {
      let col = initialisationRow();
      _tableau.push(col);
   }
   _tableau[positionJoueur.y][positionJoueur.x] = 0;
   return _tableau;
}

function initialisationRow() {
   let _col = [];
   for (let i = 0; i < 25; i++) {
      let valeur = getRandomvaleur();
      _col.push(valeur);
   }
   return _col;
}
// Fonction faisant la generation aleatoire des valeurs
function getRandomvaleur() {
   let donne = [1, 1, 1, 1, 1, 1, 1, 1, 1, 2];
   let random = Math.floor(Math.random() * donne.length);
   return donne[random];
}
function miseAjourJeu() {
   ctx.clearRect(0, 0, width, height);
   for (let y = 0; y < tableau.length; y++) {
      for (let x = 0; x < tableau[y].length; x++) {
         let coordY = y * hauteurInterface;
         let coordX = x * largeurInterface;

         ctx.drawImage(fondEcran, coordX, coordY, largeurInterface, hauteurInterface);

         if (tableau[y][x] == 0) {
            ctx.drawImage(tuille, coordX, coordY, largeurInterface, hauteurInterface);
         }

         switch (tableau[y][x]) {
            case 0:

               ctx.drawImage(tuille, coordX, coordY, largeurInterface, hauteurInterface);
               break;
            case 1:

               ctx.drawImage(piege, coordX, coordY, largeurInterface, hauteurInterface);
               break;
            case 2:

               ctx.drawImage(tresor, coordX, coordY, largeurInterface, hauteurInterface);
               break;
         }
      }
   }

   let positionJoueur_x = positionJoueur.x * largeurInterface;
   let positionJoueur_y = positionJoueur.y * hauteurInterface;

   ctx.drawImage(donjon, positionJoueur_x, positionJoueur_y, largeurInterface, hauteurInterface);
}
// Comportement effectué en fonction d'un sur un bouton precis
function positionElement
   () {
   haut.addEventListener("click", handleMoveUp);
   bas.addEventListener("click", handleMoveDown);
   gauche.addEventListener("click", handleMoveLeft);
   droit.addEventListener("click", handleMoveRight);
   document.addEventListener("keydown", handleMovement);
}
//Switch permettant de d'affecter une reaction en fonction d'un mouvement effectué 
function handleMovement(reaction) {
   switch (reaction.keyCode) {
      case 38:
      case 87:
         handleMoveUp();
         break;
      case 40:
      case 83:
         handleMoveDown();
         break;
      case 37:
      case 65:
         handleMoveLeft();
         break;
      case 39:
      case 68:
         handleMoveRight();
         break;
   }
}

let changement = false;
//Fonction definissant une action apres le clic sur le bouton haut
function handleMoveUp() {
   if (!debut || changement || fin
   ) return;
   if (positionJoueur.y > 0) {
      positionJoueur.y -= 1;
   }
   checkGameScore();
}
//Fonction definissant une action apres le clic sur le bouton bas
function handleMoveDown() {
   if (!debut || changement || fin
   ) return;
   if (positionJoueur.y < tableau.length - 1) {
      positionJoueur.y += 1;
   }
   checkGameScore();
}
//Fonction definissant une action apres le clic sur le bouton gauche
function handleMoveLeft() {
   if (!debut || changement || fin
   ) return;
   if (positionJoueur.x > 0) {
      positionJoueur.x -= 1;
   }
   checkGameScore();
}
//Fonction definissant une action apres le clic sur le bouton droit
function handleMoveRight() {
   if (!debut || changement || fin
   ) return;
   if (positionJoueur.x < tableau[0].length - 1) {
      positionJoueur.x += 1;
   }
   checkGameScore();
}
//Fonction controlant la position du  
async function checkGameScore() {
   let coordX = positionJoueur.x * largeurInterface;
   let coordY = positionJoueur.y * hauteurInterface;
//Switch qui affecte une valeur en fonction de la position ou le joueur se trouve
   switch (tableau[positionJoueur.y][positionJoueur.x]) {
      case 1:
         etat -= 1;
         score -= 50;
         break;
      case 2:
         score += 1000;
         break;
   }

   changement = true;

   if (tableau[positionJoueur.y][positionJoueur.x] != 0) {
      tableau[positionJoueur.y][positionJoueur.x] = 0;
      miseAjourScore();
      checkGameOver();
      miseAjourJeu();
      changement = false;
   } else {
      score -= 10;
      tableau[positionJoueur.y][positionJoueur.x] = 0;
      miseAjourScore();
      checkGameOver();
      miseAjourJeu();
      changement = false;
   }
}
//Mise a jour
function miseAjourScore() {
   let hp = Math.round((etat / maximun_boite) * 100);
   boite.style.width = hp + "%";
   nouv.innerHTML = etat + "/" + maximun_boite;
   scoreEmplacement.innerHTML = score;
}
//Fonction qui controle l'evolution du jeu
function checkGameOver() {
   if (etat <= 1) {
      fin
         = true;

      plusGrandScore = localStorage.getItem("plusGrandScore");
      if (!plusGrandScore || plusGrandScore < score) {
         localStorage.setItem("plusGrandScore", score);
      }

      let laBoiteScore = affiche.querySelector("#laBoiteScore");
      laBoiteScore.innerHTML = score;

      let ferme = affiche.querySelector("#ferme");
      let retry = affiche.querySelector("#retry");
      ferme.addEventListener("click", () => { fermeGame() });
      retry.addEventListener("click", () => { retryGame() });

      let contenu = affiche.querySelector(".contenue");
      contenu.addEventListener("click", (e) => { e.stopPropagation() });

      affiche.classList.add("open");
   }
}
//Fonction permenttan tla fermeture du jeu
function fermeGame() {
   plusGrandScore = localStorage.getItem("plusGrandScore");
   if (plusGrandScore) {
      grandeBoite.innerHTML = plusGrandScore;
   }

   afficheBase.style.display = "block";
   affichageJeu.style.display = "none";
   affiche.classList.remove("open");
   autreAffiche.classList.remove("open");
}
//Fonction pernettant de rejouer
function retryGame() {
   commencerLeJeu();
   affiche.classList.remove("open");
}
//Fonction permettant de sortir du jeu
function SorirJeu
   () {
   let laBoiteScore = autreAffiche.querySelector("#laBoiteScore");
   laBoiteScore.innerHTML = score;

   let ferme = autreAffiche.querySelector("#ferme");
   let cont = autreAffiche.querySelector("#continue");
   ferme.addEventListener("click", () => { fermeGame() });
   cont.addEventListener("click", () => {autreAffiche.classList.remove("open")});

   let contenu = autreAffiche.querySelector(".contenue");
   contenu.addEventListener("click", (e) => { e.stopPropagation() });

   autreAffiche.classList.add("open");
}

function commencerJeu
   () {
   afficheBase.style.display = "none";
   affichageJeu.style.display = "block";
   commencerLeJeu();
}

window.onload = initialisaionJeu();
