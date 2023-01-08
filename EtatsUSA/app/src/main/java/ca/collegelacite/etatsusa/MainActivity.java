package ca.collegelacite.etatsusa;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.ListView;
import android.widget.TextView;

import java.util.ArrayList;

public class MainActivity extends AppCompatActivity {

    // ListView <---> adaptateur <---> données (listeÉtats)

    // Source de données pour l'adaptateur du ListView
    private ArrayList<Etat> listeÉtats;

    //adaptateur pour faire le lien entre les données et notre listView
    private ArrayAdapter<Etat> adaptateur;

    private int positionEtatAffiché;


    // Fonction du cycle de vie invoquée lors de la création de l'activité.
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        // Récupérer les données source requises par l'adaptateur.
        listeÉtats = Etat.lireDonnées(this);

        //création de l'adaptateur
        adaptateur = new ArrayAdapter<Etat>(this, android.R.layout.simple_list_item_1, listeÉtats);

        ListView lv = findViewById(R.id.ListeDesViewId);
        lv.setAdapter(adaptateur);



        lv.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> adapterView, View view, int position, long l) {
                setPositionEtatAffiché(position);

            }
        });

        setPositionEtatAffiché(0);

    }
   //Creation
    @Override
    public boolean onCreateOptionsMenu(Menu menuDesEtats){
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.menu_main, menuDesEtats);

        return true;

    }
    //Sauvegarde
    @Override
    protected void onSaveInstanceState(Bundle bun){
        super.onSaveInstanceState(bun);
        bun.putInt("positionEtat", getPositionEtatAffiché());
    }
      //Restauration
    @Override
    protected  void onRestoreInstanceState(Bundle bun){
        super.onRestoreInstanceState(bun);
        setPositionEtatAffiché(bun.getInt("positionEtat"));
    }




    public int getPositionEtatAffiché() {return positionEtatAffiché;}

    public void setPositionEtatAffiché(int positionEtatAffiché){
        this.positionEtatAffiché = positionEtatAffiché;
        //Declaration et referenciation de la liste des etats
        Etat etat = listeÉtats.get(this.positionEtatAffiché);
        //Declaration et referenciation du Nom des etats
        TextView nomEtat = findViewById(R.id.NomDesEtatsId);
        nomEtat.setText(etat.getNom());
        //Declaration et referenciation du Nom de la capitale
        TextView nomCapictale = findViewById(R.id.CapitaleEtatsId);
        nomCapictale.setText(etat.getCapitale()+"");
        //Declaration et referenciation de la taille de la superficie
        TextView tailleSuperficie = findViewById(R.id.SuperficieEtatsId);
        tailleSuperficie.setText(etat.getSuperficie()+"km");
        //Declaration et referenciation du Nom d'union
        TextView dateUnion = findViewById(R.id.UnionDesEtatsId);
        dateUnion.setText(etat.getUnion()+"");
        //Declaration et referenciation de l'image des etats
        ImageView imageDesEtats = findViewById(R.id.ImageDesEtatsId);
        etat.drapeauDansImageView(imageDesEtats);



    }

    @Override
    public boolean onOptionsItemSelected(MenuItem element) {
        Etat etat = listeÉtats.get(this.positionEtatAffiché);
        switch (element.getItemId()) {
            case R.id.wikiItem:

                Intent intention = new Intent(Intent.ACTION_VIEW);
                intention.setData(Uri.parse(etat.getWikiUrl()));
                startActivity(intention);
                return true;
            default:
                return super.onOptionsItemSelected(element);
        }


    }


}