using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KModkit;
using System.Text.RegularExpressions;

public class Osu : MonoBehaviour
{
    //public declearations on bomb
    public KMAudio Audio;
    public KMBombModule Module;
    public KMSelectable canvas, textbox;
    public TextMesh MapInfo_Map;
    public MeshRenderer canvas_image;
    public Texture[] BackgroundImage; // background pictures

    private List<int> checkDuplicates = new List<int>();
    private string[] mapNames =
    {
        "IMAGE -MATERIAL- <Version 0>",
        "Suki ! Yuki ! Maji Magic",
        "HONESTY",
        "Exit This Earth's Atomosphere\n(Camellia's \"PLANETARY//200STEP\" Remix)",
        "Flower Dance",
        "Dadadadadadadadadada",
        "Holdin On (Skrillex and Nero Remix)",
        "osu!memories",
        "Diamond",
        "Shut Up and osu! With Me (2020 ver.)",
        "IGNITE (TV size ver.)",
        "Kataomoi no Melody o short ver.",
        "Granat",
        "Never Gonna Give You Up 2",
        "Through the Fire and Flames",
        "Zen Zen Zense (movie ver.)",
        "Anti-chlorobenzene",
        "Asu no Yozora Shoukaihan",
        "Revenge",
        "RESISTER (TV Size)",
        "Reality Check Through The Skull",
        "No title",
        "The Big Black",
        "LET'S JUMP",
        "forget-me-not",
        "Blue Zenith",
        "Boss Rush",
        "Brain Power",
        "rainbow road",
        "Highway to Oblivion",
        "Cheat Codes VIP",
        "Remote Control",
        "All Falls Down\n(feat. Noah Cyrus with Digital Farm Animals)",
        "BANANA STREET",
        "Rockefeller Street (Nightcore Mix)",
        "Highscore",
        "Time Bomb (feat. Vella & Boyinaband)",
        "Jinsei Reset Button",
        "HIBANA feat. Hatsune Miku",
        "miragecoordinator",
        "rotater",
        "He's a Pirate",
        "JINGO JUNGLE",
        "Witch Doctor",
        "Happppy song",
        "Ievan Polkka",
        "Calamity Fortune",
        "Something Just Like This",
        "Hardware Store",
        "Cycle Hit",
        "Everything will freeze",
        "Yume Tourou",
        "Teo",
        "Tengaku",
        "Fury of the Storm",
        "Exit This Earth's Atomosphere",
        "Soldiers of the Wasteland",
        "Can't Defeat Airman",
        "Dark Steering",
        "Memes (Speed Up Ver.)",
        "Grand Escape (Movie edit) feat. Miura Touko",
        "Space Battle",
        "Battle Against a True Hero",
        "Wings of Piano",
        "Snow Drive(01.23)",
        "Frame of Mind",
        "Faded",
        "Till it's Over",
        "Cold Green Eyes",
        "Uchiage Hanabi",
        "Burnt Rice (feat. YUNG GEMMY)",
        "(can you) understand me?",
        "the executioner",
        "quaver",
        "Wind God Girl",
        "lastendconductor",
        "Second Run",
        "Virtual Paradise",
        "Tenko",
        "Crack Traxxxx",
        "Cirno's Perfect Math Class",
        "Kikoku Doukoku Jigokuraku",
        "MEGALOVANIA (Camellia Remix)",
        "Rainbow Tylenol",
        "Kusaregedou to Chocolate",
        "Monochrome Butterfly",
        "Algebra",
        "Wizdomiot",
        "YoiYoi Kokon",
        "Night of Knights",
        "The Prelude To Bereavement",
        "Droopy likes ricochet",
        "Toumei Elegy",
        "Magic Girl !!",
        "In the Flame",
        "Castle of Glass",
        "Electrodynamics",
        "Airborne Robots",
        "The Nights",
        "TRIPLE PLAY",
        "dreamenddischarger",
        "Winterglade",
        "A Drunkard's Lemuria (Retro Ver.)",
        "A FOOL MOON NIGHT",
        "crossing field",
        "Chikatto Chika Chika (TV Size)",
        "Undertale Boss Themes",
        "Soulless 4",
        "caramel heaven",
        "Stay Stay Stay"
    };
    private string[] mapAuthorsMappers =
    {
        "Tatsh // Scorpiour",
        "Mitchie M // Natsu",
        "GYZE // Chanci",
        "Camellia // ProfessionalBox",
        "DJ OKAWARI // Narcissu",
        "Hige Driver join. SELEN // spboxer3",
        "I SEE MONSTAS // Sotarks",
        "SakiZ // DeRandom Otaku",
        "Toyosaki Aki // Fycho",
        "yomegA // Sonnyc",
        "Aoi Eir // Guy",
        "Yamazaki Moe // Asuka_-",
        "Drop // diraimur",
        "Rick Astley // LuigiHann",
        "Dragonforce // Ponoyoshi",
        "RADWIMPS // Monstrata",
        "Kagamine Rin // NatsumeRin",
        "Yuaru // Akitoshi",
        "TryHardNinja feat. CaptainSparklez // fieryrage",
        "ASCA // Doormat",
        "DM DOKURO // SnowNiNo_",
        "Reol // VINXIS",
        "The Quick Brown Fox // Blue Dragon",
        "Camellia // RikiH_",
        "ReoNa // Ryuusei Aika",
        "xi // Asphyxia",
        "USAO // Lavender",
        "NOMA // Jacob",
        "nanobii // Natsu",
        "DragonForce // SILENCE PLAYER",
        "Nitro Fun // xChorse",
        "Saiya // Garven",
        "Alan Walker // Plaudible",
        "dark cat // Ora",
        "Getter Jaani // osuplayer111",
        "Panda Eyes & Teminite // Fort",
        "Feint // vipto",
        "Megpoid GUMI // manten",
        "DECO*27 // Pho",
        "07th Expansion // La Cataline",
        "zts // tokiko",
        "F-777 // TicClick",
        "MYTH & ROID // Plaudible",
        "Cartoons // Mara",
        "SOOOO // Kuron-kun",
        "Hatsune Miku // James",
        "LeaF // Flower",
        "The Chainsmokers & Coldplay // handsome",
        "Weird Al Yankovic // Mr Moseby",
        "KASAI HARCORES // Worminators",
        "UNDEAD CORPORATION // Ekoro",
        "RADWIMPS // Monstrata",
        "Omoi // Kroytz",
        "Wagakki Band // Shiro",
        "DragonForce // Kayne",
        "Camellia // rrtyui",
        "DragonForce // Atsuro",
        "Team Nekokan // Blue Dragon",
        "Squarepusher // dsco",
        "NIVIRO // Asaiga",
        "RADWIMPS // hypercyte",
        "F-777 // DeRandom Otaku",
        "toby fox vs. Ferdk // Hobbes2",
        "V.K. // FlobuFlobs",
        "Omoi // Kroytz",
        "Tristam & Braken // Fort",
        "Alan Walker // Astarte",
        "Tristam // [Luanny]",
        "Station Earth // Bearizm",
        "DAOKO x Kenshi Yonezu // Monstrata",
        "Shawn Wasabi + YDG // ScubDomino",
        "Komiya Mao // Sotarks",
        "zts // -kevincela-",
        "dj TAKA // Sotarks",
        "Demetori // lkp",
        "zts // Yohanes",
        "Nam Goo-Min // bmin11",
        "AK X LYNX ft. Veela // alacat",
        "iru1919 // Seto Kousuke",
        "Lite Show Magic (t+pazolite vs C-Show) /\n/ Fatfan Kolek",
        "IOSYS // Louis Cyphre",
        "Halozy // Hollow Wings",
        "toby fox // Regou",
        "Kitsune^2 // Blue Dragon",
        "PinocchioP // Kenterz9",
        "Aitsuki Nakuru // Settia",
        "Function Phantom // Bonzi",
        "LeaF // Asahina Momoko",
        "REOL // Pho",
        "beatMARIO // alacat",
        "Shadow Of Intent // PoNo",
        "C418 // Bass-chan",
        "Konuko // Awaken",
        "Shihori // Frostmourne",
        "Darren Korb and Ashley Barrett // TheMefisto",
        "Linkin Park // narakucrimson",
        "dj-Nate // CookieBite",
        "F-777 // CookieBite",
        "Avicii // Kazuya",
        "KASAI HARCORES // Chickensio",
        "zts // EvilElvis",
        "Makkon // Itachi_Uchiha",
        "ZUN // Itachi_Uchiha",
        "The Koxx // Astar",
        "LiSA // Ryafuka",
        "Fujiwara Chika (CV: Kohara Konomi) // -[Pino]-",
        "toby fox // Arphimigon",
        "ExileLord // Woey",
        "yuikonnu // sukiNathan",
        "Taylor Swift // Lissette"
    };

    //Bomb ID incrementation for logging
    static int _moduleIdCounter = 1;
    int _moduleID = 0;
    bool _moduleSolved;

    //module variable declerations
    private int random_mapinfo;
    private int[] random_mapBG = new int[5];
    private int canvas_currentimagecounter = 0;

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
            selectedmapBG = Random.Range(0, BackgroundImage.Length);

            while(checkDuplicates.Contains(selectedmapBG))
                selectedmapBG = Random.Range(0, BackgroundImage.Length);

            checkDuplicates.Add(selectedmapBG);
            random_mapBG[i] = selectedmapBG;
            Debug.LogFormat("[osu! #{0}] Generated map background: {1} [{2}]", _moduleID, mapNames[selectedmapBG], mapAuthorsMappers[selectedmapBG]);
        }
        checkDuplicates.Clear();
        canvas_image.material.mainTexture = BackgroundImage[random_mapBG[0]];
    }

    void generate_mapinfo()
    {
        int i = Random.Range(0, 4);
        string map_song = mapNames[random_mapBG[i]];
        string map_author_mapper = mapAuthorsMappers[random_mapBG[i]];
        random_mapinfo = i;
        MapInfo_Map.text = map_song + "\n" + map_author_mapper;
        Debug.LogFormat("[osu! #{0}] Generated map song: {1}. [{2}]", _moduleID, map_song, map_author_mapper);
    }

    void changeBG()
    {
        if (_moduleSolved)
            return;
        Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, canvas.transform);
        canvas.AddInteractionPunch();
        canvas_currentimagecounter = (canvas_currentimagecounter + 1) % random_mapBG.Length;
        canvas_image.material.mainTexture = BackgroundImage[random_mapBG[canvas_currentimagecounter]];
    }

    void submit()
    {
        if (_moduleSolved)
            return;
        Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, textbox.transform);
        textbox.AddInteractionPunch();
        Debug.LogFormat("[osu! #{0}] Submitted image: {1} [{2}].", _moduleID, mapNames[random_mapBG[canvas_currentimagecounter]], mapAuthorsMappers[random_mapBG[canvas_currentimagecounter]]);
        if (random_mapBG[canvas_currentimagecounter] == random_mapBG[random_mapinfo])
        {
            _moduleSolved = true;
            Debug.LogFormat("[osu! #{0}] Submission correct. Module solved. NOW GO CLICK THE CIRCLES!", _moduleID);
            Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.CorrectChime, Module.transform);
            Module.HandlePass();
        }
        else
        {
            Debug.LogFormat("[osu! #{0}] Submission incorrect. Strike incurred. Boo hoo you suck!", _moduleID);
            Module.HandleStrike();
            init();
        }
    }

#pragma warning disable 414
    private readonly string TwitchHelpMessage = @"Change picture with !{0} change. Submit with !{0} submit.";
#pragma warning restore 414

    IEnumerator ProcessTwitchCommand(string command)
    {
        yield return null;
        command = command.ToLowerInvariant().Trim();
        if (command.Equals("change"))
            canvas.OnInteract();
        else if (command.Equals("submit"))
            textbox.OnInteract();
        yield return null;
    }
}
