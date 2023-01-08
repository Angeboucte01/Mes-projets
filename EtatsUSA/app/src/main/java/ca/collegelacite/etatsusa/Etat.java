package ca.collegelacite.etatsusa;

import android.content.Context;
import android.graphics.drawable.Drawable;
import android.widget.ImageView;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.InputStream;
import java.io.Serializable;
import java.util.ArrayList;

// Classe implantant un descriptif l'état
public class Etat implements Comparable, Serializable {
    private String nom      = null;    // nom de l'état
    private String code     = null;    // code à deux lettres de l'état
    private String capitale = null;    // nom de la capitale de l'état
    private int superficie  = 0;       // superficie de l'état en km carrés
    private String union    = null;    // date d'entrée dans l'Union de l'état
    private String wikiUrl   = null;   // URL du wiki de l'état

    private static Context contexte = null;   // requis pour lire le JSON

    // Constructeur par défaut
    public Etat() {
        this.setNom(null);
        this.setCode(null);
        this.setCapitale(null);
        this.setSuperficie(0);
        this.setUnion(null);
        this.setWikiUrl(null);
    }

    // Constructeur paramétré
    public Etat(String nom, String code, String capitale, int superficie, String union, String wikiUrl) {
        this.setNom(nom);
        this.setCode(code);
        this.setCapitale(capitale);
        this.setSuperficie(superficie);
        this.setUnion(union);
        this.setWikiUrl(wikiUrl);
    }

    // Fonction de comparaison utilisée pour trier la liste de pays après la
    // lecture du JSON.
    @Override
    public int compareTo(Object autrePays) {
        return this.toString().compareTo(autrePays.toString());
    }

    // Accesseur de l'attribut nom
    public String getNom() {
        return nom;
    }

    // Mutateur de l'attribut nom
    public void setNom(String nom) {
        this.nom = nom;
    }

    // Accesseur de l'attribut code
    public String getCode() {
        return code;
    }

    // Mutateur de l'attribut code
    public void setCode(String code) {
        this.code = code;
    }

    // Accesseur de l'attribut capitale
    public String getCapitale() {
        return capitale;
    }

    // Mutateur de l'attribut capitale
    public void setCapitale(String capitale) {
        this.capitale = capitale;
    }

    // Accesseur de l'attribut superficie
    public int getSuperficie() {
        return superficie;
    }

    // Mutateur de l'attribut superficie
    public void setSuperficie(int superficie) {
        this.superficie = superficie;
    }

    // Accesseur de l'attribut wikiUrl
    public String getWikiUrl() {
        return wikiUrl;
    }

    // Mutateur de l'attribut wikiUrl
    public void setWikiUrl(String wikiUrl) {
        this.wikiUrl = wikiUrl;
    }

    // Accesseur de l'attribut union
    public String getUnion() {
        return union;
    }

    // Mutateur de l'attribut union
    public void setUnion(String union) {
        this.union = union;
    }

    // Accesseur de l'attribut drawable
    public String getDrawable() {
        return code;
    }

    // Retourne une chaîne décrivant brièvement le poisson
    @Override
    public String toString() {
        return this.getNom();
    }

    // Fonction permettant d'insérer l'image du drapeau du pays dans un
    // ImageView fourni. L'image du drapeau doit être dans res/drawable et porter
    // un nom correspondant au code du pays.
    public void drapeauDansImageView(ImageView iv) {
        String uri = "@drawable/" + this.getDrawable().toLowerCase();

        int imageResource = contexte.getResources().getIdentifier(uri, null, contexte.getPackageName());

        Drawable res = contexte.getDrawable(imageResource);
        iv.setImageDrawable(res);
    }

    // Désérialiser une liste de poissons d'un fichier JSON
    public static ArrayList<Etat> lireDonnées(Context ctx){
        final String nomFichier     = "usa.json";
        final ArrayList<Etat> liste = new ArrayList<>();

        // Sauvegarder le contexte pour la gestion des drawables.
        contexte = ctx;

        try {
            // Charger les données dans un ArrayList
            String jsonString     = lireJson(nomFichier, contexte);
            JSONObject json       = new JSONObject(jsonString);
            JSONArray personnages = json.getJSONArray("états");

            // Lire chaque personnage du fichier
            for(int i = 0; i < personnages.length(); i++){
                Etat e = new Etat();

                e.nom        = personnages.getJSONObject(i).getString("nom");
                e.code       = personnages.getJSONObject(i).getString("code");
                e.capitale   = personnages.getJSONObject(i).getString("capitale");
                e.superficie = personnages.getJSONObject(i).getInt("superficie");
                e.union      = personnages.getJSONObject(i).getString("union");
                e.wikiUrl    = personnages.getJSONObject(i).getString("wiki");

                liste.add(e);
            }
        } catch (JSONException e) {
            // Une erreur s'est produite (on la journalise)
            e.printStackTrace();
        }

        return liste;
    }

    // Retourne une balise lue d'un fichier JSON
    private static String lireJson(String nomFichier, Context contexte) {
        String json = null;

        try {
            InputStream is = contexte.getAssets().open(nomFichier);
            int size = is.available();
            byte[] buffer = new byte[size];
            is.read(buffer);
            is.close();
            json = new String(buffer, "ISO-8859-1");
        }
        catch (java.io.IOException ex) {
            // Une erreur s'est produite (on la journalise)
            ex.printStackTrace();
            return null;
        }

        return json;
    }
}
