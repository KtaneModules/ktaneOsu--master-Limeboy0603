using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KModkit;
using System.Text.RegularExpressions;

public class Osu : MonoBehaviour
{
    //public declearations on bomb
    public KMBombModule Module;
    public KMSelectable canvas, textbox;
    public TextMesh MapInfo_Map;
    public MeshRenderer canvas_image;
    public Texture[] BackgroundImage; // background pictures

    private List<int> checkDuplicates = new List<int>();

    //Bomb ID incrementation for logging
    static int _moduleIdCounter = 1;
    int _moduleID = 0;


    //module variable declerations
    private int random_mapinfo;
    private int[] random_mapBG = new int[5];
    private int canvas_currentimagecounter=0;

    void Awake()
    {
        _moduleID = _moduleIdCounter++;
        canvas.OnInteract += delegate ()
        {
            changeBG();
            return false;
        };
        textbox.OnInteract += delegate ()
        {
            submit();
            return false;
        };
    }

    //Use this for initialization
    void Start()
    {
        init();
    }
    
    void init()
    {
        canvas_currentimagecounter = 0;
        generate_image();
        generate_mapinfo();
    }

    void generate_image()
    {
        int selectedmapBG;
        for (int i = 0 ; i <= 4 ; i++)
        {
            selectedmapBG = Random.Range(0, 101); //change
            random_mapBG[i] = selectedmapBG;
            while(checkDuplicates.Contains(selectedmapBG))
            {
                selectedmapBG = Random.Range(0, 101); //change
            }
            Debug.LogFormat("[osu! #{0}] Generated map background: {1}", _moduleID ,selectedmapBG);
        }
        checkDuplicates.Clear();
        canvas_image.material.mainTexture = BackgroundImage[random_mapBG[0]];
    }

    void generate_mapinfo()
    {
        int i = Random.Range(0, 4);
        string map_song="";
        string map_author_mapper="";
        random_mapinfo = i;
        switch (random_mapBG[i])
        {
            case 0:
                map_song = "IMAGE -MATERIAL- <Version 0>";
                map_author_mapper = "Tatsh // Scorpiour";
                break;
            case 1:
                map_song = "Suki ! Yuki ! Maji Magic";
                map_author_mapper = "Mitchie M // Natsu";
                break;
            case 2:
                map_song = "HONESTY";
                map_author_mapper = "GYZE // Chanci";
                break;
            case 3:
                map_song = "Exit This Earth's Atomosphere\n(Camellia's ''PLANETARY//200STEP'' Remix)";
                map_author_mapper = "Camellia // ProfessionalBox";
                break;
            case 4:
                map_song = "Flower Dance";
                map_author_mapper = "DJ OKAWARI // Narcissu";
                break;
            case 5:
                map_song = "Dadadadadadadadadada";
                map_author_mapper = "Hige Driver join. SELEN // spboxer3";
                break;
            case 6:
                map_song = "Holdin On (Skrillex and Nero Remix)";
                map_author_mapper = "I SEE MONSTAS // Sotarks";
                break;
            case 7:
                map_song = "osu!memories";
                map_author_mapper = "SakiZ // DeRandom Otaku";
                break;
            case 8:
                map_song = "Diamond";
                map_author_mapper = "Toyosaki Aki // Fycho";
                break;
            case 9:
                map_song = "Shut Up and osu! With Me (2020 ver.)";
                map_author_mapper = "yomegA // Sonnyc";
                break;
            case 10:
                map_song = "IGNITE (TV size ver.)";
                map_author_mapper = "Aoi Eir // Guy";
                break;
            case 11:
                map_song = "Kataomoi no Melody o short ver.";
                map_author_mapper = "Yamazaki Moe // Asuka_-";
                break;
            case 12:
                map_song = "Granat";
                map_author_mapper = "Drop // diraimur";
                break;
            case 13:
                map_song = "Never Gonna Give You Up 2";
                map_author_mapper = "Rick Astley // LuigiHann";
                break;
            case 14:
                map_song = "Through the Fire and Flames";
                map_author_mapper = "Dragonforce // Ponoyoshi";
                break;
            case 15:
                map_song = "Zen Zen Zense (movie ver.)";
                map_author_mapper = "RADWIMPS // Monstrata";
                break;
            case 16:
                map_song = "Anti-chlorobenzene";
                map_author_mapper = "Kagamine Rin // NatsumeRin";
                break;
            case 17:
                map_song = "Asu no Yozora Shoukaihan";
                map_author_mapper = "Yuaru // Akitoshi";
                break;
            case 18:
                map_song = "Revenge";
                map_author_mapper = "TryHardNinja feat. CaptainSparklez // fieryrage";
                break;
            case 19:
                map_song = "RESISTER (TV Size)";
                map_author_mapper = "ASCA // Doormat";
                break;
            case 20:
                map_song = "Reality Check Through The Skull";
                map_author_mapper = "DM DOKURO // SnowNiNo_";
                break;
            case 21:
                map_song = "No title";
                map_author_mapper = "Reol // VINXIS";
                break;
            case 22:
                map_song = "The Big Black";
                map_author_mapper = "The Quick Brown Fox // Blue Dragon";
                break;
            case 23:
                map_song = "LET'S JUMP";
                map_author_mapper = "Camellia // RikiH_";
                break;
            case 24:
                map_song = "forget-me-not";
                map_author_mapper = "ReoNa // Ryuusei Aika";
                break;
            case 25:
                map_song = "Blue Zenith";
                map_author_mapper = "xi // Asphyxia";
                break;
            case 26:
                map_song = "Boss Rush";
                map_author_mapper = "USAO // Lavender";
                break;
            case 27:
                map_song = "Brain Power";
                map_author_mapper = "NOMA // Jacob";
                break;
            case 28:
                map_song = "rainbow road";
                map_author_mapper = "nanobii // Natsu";
                break;
            case 29:
                map_song = "Highway to Oblivion";
                map_author_mapper = "DragonForce // SILENCE PLAYER";
                break;
            case 30:
                map_song = "Cheat Codes VIP";
                map_author_mapper = "Nitro Fun // xChorse";
                break;
            case 31:
                map_song = "Remote Control";
                map_author_mapper = "Saiya // Garven";
                break;
            case 32:
                map_song = "All Falls Down\n(feat. Noah Cyrus with Digital Farm Animals)";
                map_author_mapper = "Alan Walker // Plaudible";
                break;
            case 33:
                map_song = "BANANA STREET";
                map_author_mapper = "dark cat // Ora";
                break;
            case 34:
                map_song = "Rockefeller Street (Nightcore Mix)";
                map_author_mapper = "Getter Jaani // osuplayer111";
                break;
            case 35:
                map_song = "Highscore";
                map_author_mapper = "Panda Eyes & Teminite // Fort";
                break;
            case 36:
                map_song = "Time Bomb (feat. Vella & Boyinaband)";
                map_author_mapper = "Feint // vipto";
                break;
            case 37:
                map_song = "Jinsei Reset Button";
                map_author_mapper = "Megpoid GUMI // manten";
                break;
            case 38:
                map_song = "HIBANA feat. Hatsune Miku";
                map_author_mapper = "DECO*27 // Pho";
                break;
            case 39:
                map_song = "miragecoordinator";
                map_author_mapper = "07th Expansion // La Cataline";
                break;
            case 40:
                map_song = "rotater";
                map_author_mapper = "zts // tokiko";
                break;
            case 41:
                map_song = "He's a Pirate";
                map_author_mapper = "F-777 // TicClick";
                break;
            case 42:
                map_song = "JINGO JUNGLE";
                map_author_mapper = "MYTH & ROID // Plaudible";
                break;
            case 43:
                map_song = "Witch Doctor";
                map_author_mapper = "Cartoons // Mara";
                break;
            case 44:
                map_song = "Happppy song";
                map_author_mapper = "SOOOO // Kuron-kun";
                break;
            case 45:
                map_song = "Ievan Polkka";
                map_author_mapper = "Hatsune Miku // James";
                break;
            case 46:
                map_song = "Calamity Fortune";
                map_author_mapper = "LeaF // Flower";
                break;
            case 47:
                map_song = "Something Just Like This";
                map_author_mapper = "The Chainsmokers & Coldplay // handsome";
                break;
            case 48:
                map_song = "Hardware Store";
                map_author_mapper = "Weird Al Yankovic // Mr Moseby";
                break;
            case 49:
                map_song = "Cycle Hit";
                map_author_mapper = "KASAI HARCORES // Worminators";
                break;
            case 50:
                map_song = "Everything will freeze";
                map_author_mapper = "UNDEAD CORPORATION // Ekoro";
                break;
            case 51:
                map_song = "Yume Tourou";
                map_author_mapper = "RADWIMPS // Monstrata";
                break;
            case 52:
                map_song = "Teo";
                map_author_mapper = "Onot // Kroytz";
                break;
            case 53:
                map_song = "Tengaku";
                map_author_mapper = "Wagakki Band // Shiro";
                break;
            case 54:
                map_song = "Fury of the Storm";
                map_author_mapper = "DragonForce // Kayne";
                break;
            case 55:
                map_song = "Exit This Earth's Atomosphere";
                map_author_mapper = "Camellia // rrtyui";
                break;
            case 56:
                map_song = "Soldiers of the Wasteland";
                map_author_mapper = "DragonForce // Atsuro";
                break;
            case 57:
                map_song = "Can't Defeat Airman";
                map_author_mapper = "Team Nekokan // Blue Dragon";
                break;
            case 58:
                map_song = "Dark Steering";
                map_author_mapper = "Squarepusher // dsco";
                break;
            case 59:
                map_song = "Memes (Speed Up Ver.)";
                map_author_mapper = "NIVIRO // Asaiga";
                break;
            case 60:
                map_song = "Grand Escape (Movie edit) feat. Miura Touko";
                map_author_mapper = "RADWIMPS // hypercyte";
                break;
            case 61:
                map_song = "Space Battle";
                map_author_mapper = "F-777 // DeRandom Otaku";
                break;
            case 62:
                map_song = "Battle Against a True Hero";
                map_author_mapper = "toby fox vs. Ferdk // Hobbes2";
                break;
            case 63:
                map_song = "Wings of Piano";
                map_author_mapper = "V.K. // FlobuFlobs";
                break;
            case 64:
                map_song = "Snow Drive(01.23)";
                map_author_mapper = "Omoi // Kroytz";
                break;
            case 65:
                map_song = "Frame of Mind";
                map_author_mapper = "Tristam & Braken // Fort";
                break;
            case 66:
                map_song = "Faded";
                map_author_mapper = "Alan Walker // Astarte";
                break;
            case 67:
                map_song = "Till it's Over";
                map_author_mapper = "Tristam // [Luanny]";
                break;
            case 68:
                map_song = "Cold Green Eyes";
                map_author_mapper = "Station Earth // Bearizm";
                break;
            case 69:
                map_song = "Uchiage Hanabi";
                map_author_mapper = "DAOKO x Kenshi Yonezu // Monstrata";
                break;
            case 70:
                map_song = "Burnt Rice (feat. YUNG GEMMY)";
                map_author_mapper = "Shawn Wasabi + YDG // ScubDomino";
                break;
            case 71:
                map_song = "(can you) understand me?";
                map_author_mapper = "Komiya Mao // Sotarks";
                break;
            case 72:
                map_song = "the executioner";
                map_author_mapper = "zts // -kevincela-";
                break;
            case 73:
                map_song = "quaver";
                map_author_mapper = "dj TAKA // Sotarks";
                break;
            case 74:
                map_song = "Wind God Girl";
                map_author_mapper = "Demetori // lkp";
                break;
            case 75:
                map_song = "lastendconductor";
                map_author_mapper = "zts // Yohanes";
                break;
            case 76:
                map_song = "Second Run";
                map_author_mapper = "Nam Goo-Min // bmin11";
                break;
            case 77:
                map_song = "Virtual Paradise";
                map_author_mapper = "AK X LYNX ft. Veela // alacat";
                break;
            case 78:
                map_song = "Tenko";
                map_author_mapper = "iru1919 // Seto Kousuke";
                break;
            case 79:
                map_song = "Crack Traxxxx";
                map_author_mapper = "Lite Show Magic (t+pazolite vs C-Show) /\n/ Fatfan Kolek";
                break;
            case 80:
                map_song = "Cirno's Perfect Math Class";
                map_author_mapper = "IOSYS // Louis Cyphre";
                break;
            case 81:
                map_song = "Kikoku Doukoku Jigokuraku";
                map_author_mapper = "Halozy // Hollow Wings";
                break;
            case 82:
                map_song = "MEGALOVANIA (Camellia Remix)";
                map_author_mapper = "toby fox // Regou";
                break;
            case 83:
                map_song = "Rainbow Tylenol";
                map_author_mapper = "Kitsune^2 // Blue Dragon";
                break;
            case 84:
                map_song = "Kusaregedou to Chocolate";
                map_author_mapper = "PinocchioP // Kenterz9";
                break;
            case 85:
                map_song = "Monochrome Butterfly";
                map_author_mapper = "Aitsuki Nakuru // Settia";
                break;
            case 86:
                map_song = "Algebra";
                map_author_mapper = "Function Phantom // Bonzi";
                break;
            case 87:
                map_song = "Wizdomiot";
                map_author_mapper = "LeaF // Asahina Momoko";
                break;
            case 88:
                map_song = "YoiYoi Kokon";
                map_author_mapper = "REOL // Pho";
                break;
            case 89:
                map_song = "Night of Knights";
                map_author_mapper = "beatMARIO // alacat";
                break;
            case 90:
                map_song = "The Prelude To Bereavement";
                map_author_mapper = "Shadow Of Intent // PoNo";
                break;
            case 91:
                map_song = "Droopy likes ricochet";
                map_author_mapper = "C418 // Bass-chan";
                break;
            case 92:
                map_song = "Toumei Elegy";
                map_author_mapper = "Konuko // Awaken";
                break;
            case 93:
                map_song = "Magic Girl !!";
                map_author_mapper = "Shihori // Frostmourne";
                break;
            case 94:
                map_song = "In the Flame";
                map_author_mapper = "Darren Korb and Ashley Barrett // TheMefisto";
                break;
            case 95:
                map_song = "Castle of Glass";
                map_author_mapper = "Linkin Park // narakucrimson";
                break;
            case 96:
                map_song = "Electrodynamics";
                map_author_mapper = "dj-Nate // CookieBite";
                break;
            case 97:
                map_song = "Airborne Robots";
                map_author_mapper = "F-777 // CookieBite";
                break;
            case 98:
                map_song = "The Nights";
                map_author_mapper = "Avicii // Kazuya";
                break;
            case 99:
                map_song = "TRIPLE PLAY";
                map_author_mapper = "KASAI HARCORES // Chickensio";
                break;
            case 100:
                map_song = "dreamenddischarger";
                map_author_mapper = "zts // EvilElvis";
                break;
        }
        MapInfo_Map.text = map_song + "\n" + map_author_mapper;
        Debug.LogFormat("[osu! #{0}] Generated map song: {1}. Author and creator: {2}", _moduleID, map_song, map_author_mapper);
    }

    void changeBG()
    {
        canvas_currentimagecounter++;
        if (canvas_currentimagecounter > 4)
            canvas_currentimagecounter = 0;
        canvas_image.material.mainTexture = BackgroundImage[random_mapBG[canvas_currentimagecounter]];
    }

    void submit()
    {
        Debug.LogFormat("[osu! #{0}] Submitted image: {1}. Correct image: {2}", _moduleID, random_mapBG[canvas_currentimagecounter], random_mapBG[random_mapinfo]);
        if (random_mapBG[canvas_currentimagecounter] == random_mapBG[random_mapinfo])
        {
            Module.HandlePass();
            Debug.LogFormat("[osu! #{0}] Submission correct. Module solved. NOW GO CLICK THE CIRCLES!", _moduleID);
        }
        else
        {
            Module.HandleStrike();
            Debug.LogFormat("[osu! #{0}] Submission incorrect. Strike incurred. Boo hoo you suck!", _moduleID);
            init();
        }
    }

#pragma warning disable 414
    private readonly string TwitchHelpMessage = @"Change picture with !{0} change. Submit with !{0} submit.";
#pragma warning restore 414

    KMSelectable[] ProcessTwitchCommand(string command)
    {
        command = command.ToLowerInvariant().Trim();
        if (command.Equals("change"))
            return new KMSelectable[] { canvas };
        else if (command.Equals("submit"))
            return new KMSelectable[] { textbox };
        return null;
    }
}
