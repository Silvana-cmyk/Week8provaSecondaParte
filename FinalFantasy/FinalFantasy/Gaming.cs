using FinalFantasy.Core.Entities;
using FinalFantasy.RepositoryEF;
using FinalFantasy.RepositoryMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy
{
    public class Gaming
    {
        //public static RepositoryUserMock repoUserM = new RepositoryUserMock();
        //public static RepositoryWeaponMock repoWeaponM = new RepositoryWeaponMock();
        //public static RepositoryHeroMock repoHeroM = new RepositoryHeroMock();
        //public static RepositoryMonsterMock repoMonsterM = new RepositoryMonsterMock();
        //public static RepositoryLevelMock repoLevelM = new RepositoryLevelMock();

        public static RepositoryUserEF repoUserM = new RepositoryUserEF();
        public static RepositoryWeaponEF repoWeaponM = new RepositoryWeaponEF();
        public static RepositoryHeroEF repoHeroM = new RepositoryHeroEF();
        public static RepositoryMonsterEF repoMonsterM = new RepositoryMonsterEF();
        public static RepositoryLevelEF repoLevelM = new RepositoryLevelEF();

        //MENU INIZIALE DI GESTIONE DELL'UTENTE
        public static bool MenuIniziale()
        {
            Console.WriteLine("1. Accedi");
            Console.WriteLine("2. Registrati");
            Console.WriteLine("3. Esci");
            int scelta = Helper.VerificaInput(3);
            var esito = AnalizzaScelta(scelta);
            return esito;
        }

        private static bool AnalizzaScelta(int scelta)
        {
            bool go = true;
            switch (scelta)
            {
                case 1:
                    Accedi();
                    break;
                case 2:
                    Registrati();
                    break;
                case 3:
                    go = false;
                    break;
                default:
                    go = false;
                    break;
            }
            return go;
        }

        private static void Registrati()
        {
            Console.WriteLine("Scegli nickname utente");
            String nickname = Console.ReadLine();
            User user = null;
            bool flag = true;
            foreach (var item in repoUserM.GetAll())
            {
                if (item.Nickname.Equals(nickname))
                {
                    flag = false;
                }
            }
            if (flag == true)
            {
                user = new User() { Nickname = nickname };
                repoUserM.Add(user);
                Console.WriteLine("Registrazione avvenuta con successo");
                bool continua = true;
                while (continua)
                {
                    continua = MenuGiocatore(user);
                }
            }
            else
            {
                Console.WriteLine("Nickname già esistente");
            }
        }

        private static void Accedi()
        {
            Console.WriteLine("Inserisci nickname utente");
            String nickname = Console.ReadLine();
            bool flag = false;
            User user = null;
            foreach (var item in repoUserM.GetAll())
            {
                if (item.Nickname.Equals(nickname))
                {
                    flag = true;
                    user = item;
                }
            }
            if (flag == true)
            {
                bool continua = true;
                while (continua)
                {
                    continua = MenuGiocatore(user);
                }
            }
            else
            {
                Console.WriteLine("“Nickname errato”");
            }
        }


        //MENU PRINCIPALE DI INIZIO PARTITA
        public static bool MenuGiocatore(User giocatore)
        {
            Console.WriteLine("1. Gioca");
            Console.WriteLine("2. Crea nuovo eroe");
            Console.WriteLine("3. Elimina eroe");
            Console.WriteLine("4. Esci");
            int scelta = Helper.VerificaInput(4);
            var esito = AnalizzaSceltaNonAdmin(scelta, giocatore);
            return esito;
            //ALL'INTERNO DI QUESTO MENU VADO A GESTIRE LE OPERAZIONI
            //INIZIALE DI CREAZIONE PARTITA
            //CREAZIONE EROE
            //SCELTA EROE
            //ELIMINARE EROE
        }

        private static bool AnalizzaSceltaNonAdmin(int scelta, User utente)
        {
            bool go = true;
            switch (scelta)
            {
                case 1:
                    Gioca(utente);
                    break;
                case 2:
                    CreaEroe(utente);
                    break;
                case 3:
                    EliminaEroe(utente);
                    break;
                case 4:
                    go = false;
                    break;
                default:
                    go = false;
                    break;
            }
            return go;
        }

        private static void EliminaEroe(User utente)
        {
            Console.WriteLine("Scegli eroe da eliminare.");
            //if (utente.Heroes.Count == 0)
            //{
            //    Console.WriteLine("Lista vuota");
            //}
            //else
            //{
            //    foreach (var item in utente.Heroes)
            //    {
            //        Console.WriteLine(item.ID + " - " + item.Name);
            //        item.ToString();
            //    }
            foreach (var item in repoHeroM.GetAll())
            {
                if (item.UserID.Equals(utente.Nickname))
                {
                    Console.WriteLine(item.ID + " - " + "Nome: " + item.Name + " " + "Punti: " + item.Score);
                }

            }
            int j = Convert.ToInt32(Console.ReadLine());
                Hero herotodelete = repoHeroM.GetByID(j);
                utente.Heroes.Remove(herotodelete);
                repoHeroM.Delete(herotodelete);
                Console.WriteLine("L’eroe è stato cancellato");
            //}
        }

        private static void CreaEroe(User utente)
        {
            try
            {
                Hero hero;
                Console.WriteLine("Scegli il tipo di eroe");
                Console.WriteLine("1 - Soldato");
                Console.WriteLine("2 - Mago");
                int i = Convert.ToInt32(Console.ReadLine());
                if (i == 1)
                {
                    Random RandomClass = new Random();
                    int random = RandomClass.Next(0, 1000);
                    Console.WriteLine("Inserisci nome");
                    string nome = Console.ReadLine();
                    Console.WriteLine("Scegli arma");
                    Console.WriteLine("1 - Ascia");
                    Console.WriteLine("2 - Mazza");
                    Console.WriteLine("3 - Spada");
                    int arma = Convert.ToInt32(Console.ReadLine());
                    hero = new Hero()
                    {
                        //ID = random,
                        Name = nome,
                        Type = "Soldier",
                        Score = 0,
                        Life = 20,
                        LevelID = 1,
                        //Level = repoLevelM.GetByID(1),
                        //User = utente,
                        UserID = utente.Nickname,
                        //Weapon = repoWeaponM.GetByID(arma),
                        WeaponID = arma
                    };
                    utente.Heroes.Add(hero);
                    repoHeroM.Add(hero);
                }
                if (i == 2)
                {
                    Random RandomClass = new Random();
                    int random = RandomClass.Next(0, 1000);
                    Console.WriteLine("Inserisci nome");
                    string nome = Console.ReadLine();
                    Console.WriteLine("Scegli arma");
                    Console.WriteLine("1 - Arco e frecce");
                    Console.WriteLine("2 - Bacchetta");
                    Console.WriteLine("3 - Bastone magico");
                    int arma = Convert.ToInt32(Console.ReadLine());
                    hero = new Hero()
                    {
                        //ID = random,
                        Name = nome,
                        Type = "Wizard",
                        Score = 0,
                        Life = 20,
                        LevelID = 1,
                        //Level = repoLevelM.GetByID(1),
                        //User = utente,
                        UserID = utente.Nickname,
                        //Weapon = repoWeaponM.GetByID(arma),
                        WeaponID = arma,
                    };
                    utente.Heroes.Add(hero);
                    repoHeroM.Add(hero);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private static void Gioca(User utente)
        {
            Console.WriteLine("Scegli eroe con cui giocare.");
            Console.WriteLine("Eroi creati:");
            //if (utente.Heroes.Count == 0)
            //{
            //    Console.WriteLine("Lista vuota");
            //}
            //else
            //{
                foreach (var item in repoHeroM.GetAll())
                {
                    if(item.UserID.Equals(utente.Nickname))
                    {
                        Console.WriteLine(item.ID + " - " + "Nome: " + item.Name + " " + "Punti: " + item.Score);
                    }
                    
                }
                int eroeScelto = Convert.ToInt32(Console.ReadLine());
                Hero hero = repoHeroM.GetByID(eroeScelto);
                Partita(hero);
            //}
        }

        public static void Partita(Hero eroeScelto)
        {
            //METODO ALL'INTERNO DEL QUALE VADO A GESTIRE 
            //LA LOGICA RELATIVA AD UNA PARTITA
            Random RandomClass = new Random();
            bool continua = true;
            Monster monster = null;
            while(continua)
            {
                int random = RandomClass.Next(1, 6);
                monster = repoMonsterM.GetByID(random);

                if (monster.LevelID <= eroeScelto.LevelID)
                {
                    continua = false;
                    break;
                }
            }
            Battaglia(eroeScelto, monster);
        }

        public static void Battaglia(Hero eroeScelto, Monster mostroSorteggiato)
        {
            //ALL'INTERNO DI QUESTO METODO VENGONO GESTITE LE CASISTICHE DI 
            //VITTORIA-PERDITA DELL'EROE
            //LA BATTAGLIA SI RIPETE FINCHE' L'EROE NON UCCIDE IL MOSTRO O VICEVERSA
            bool continua = true;
            while (continua)
            {
                //Console.WriteLine("Scegli azione:");
                //Console.WriteLine("1 - Attacco");
                //Console.WriteLine("2 - Fuga");
                //int i = Helper.VerificaInput(3);
                bool scelta = SceltaTurno(eroeScelto, mostroSorteggiato);
                if (scelta == true)
                {
                    AttaccoFuga.Attacco(eroeScelto, mostroSorteggiato);
                }
                else
                {
                    int r = AttaccoFuga.Fuga();
                    if (r==1)
                    {
                        Console.WriteLine("Fuga.......");
                        eroeScelto.Score = eroeScelto.Score + mostroSorteggiato.LevelID * 10;
                        break;
                    } 
                }
                if (mostroSorteggiato.Life <= 0)
                {
                    Console.WriteLine("HAI VINTO!");
                    SaltoLivello(eroeScelto);
                    eroeScelto.Score = eroeScelto.Score - mostroSorteggiato.LevelID*5;
                    Rigiocare(eroeScelto);
                    continua = false;
                    break;
                }
                AttaccoFuga.AttaccoMostro(eroeScelto, mostroSorteggiato);
                if (eroeScelto.Life <= 0)
                {
                    Console.WriteLine("Ha vinto il mostro...");
                    eroeScelto.Life = 20; //RIMETTO I PUNTI ALTRIMENTI NON VA
                    eroeScelto.LevelID = 1;
                    eroeScelto.Level = repoLevelM.GetByID(1);
                    Rigiocare(eroeScelto);
                    continua = false;
                    break;
                }
            }

        }

        private static void SaltoLivello(Hero eroeScelto)
        {

            if (eroeScelto.Score >= 30 && eroeScelto.Score <= 59)
            {
                if (eroeScelto.LevelID < 2)
                {
                    repoHeroM.ChangeLevel(eroeScelto.ID, 2, 40);
                }
            }
            if (eroeScelto.Score >= 60 && eroeScelto.Score <= 89)
            {
                if (eroeScelto.LevelID < 3)
                {
                    repoHeroM.ChangeLevel(eroeScelto.ID, 3, 60);
                }
            }
            if (eroeScelto.Score >= 90 && eroeScelto.Score <= 119)
            {
                if (eroeScelto.LevelID < 4)
                {
                    repoHeroM.ChangeLevel(eroeScelto.ID, 4, 80);
                }
            }
            if (eroeScelto.Score >= 120)
            {
                if (eroeScelto.LevelID < 5)
                {
                    repoHeroM.ChangeLevel(eroeScelto.ID, 5, 100);
                }
            }
        }

        public static bool SceltaTurno(Hero eroe, Monster mostro)
        {
            //METODO CHE CHIEDE ALL'UTENTE QUALE MOSSA ESEGUIRE
            //LOTTA O FUGA
            Console.WriteLine("Scegli azione:");
            Console.WriteLine("1 - Attacco");
            Console.WriteLine("2 - Fuga");
            int i = Helper.VerificaInput(2);
            if (i == 1) return true;
            else return false;

        }

        private static void Rigiocare(Hero hero)
        {
            User user = repoUserM.GetByID(hero.UserID);
            Console.WriteLine("Vuoi rigiocare?");
            Console.WriteLine("1 - sì");
            Console.WriteLine("2 - no");
            int i = Helper.VerificaInput(2);
            if (i == 1)
            {
                Console.WriteLine("Vuoi cambiare personaggio?");
                Console.WriteLine("1 - sì");
                Console.WriteLine("2 - no");
                int j = Helper.VerificaInput(2);
                if (j == 1)
                {
                    Gioca(user);
                }
            }
        }
    }
}
