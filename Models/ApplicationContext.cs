using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;

namespace RandaManga.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Manga> MangaCatalog { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        public void FillDataBase()
        {
            Manga souleaterManga = new Manga("Пожиратель душ", "Для борьбы со злобным Кишином, который может ввергнуть мир в пучину безумия," +
            " Шинигами-сама создаёт Академию — место, где проходит совместное обучение Оружий и Повелителей. Первые являются " +
            "тем самым оружием, которое позволит остановить гибель мира; вторые — те, кто будет держать это оружие. Коса Смерти получится," +
            " когда оружие съест 99 злых душ, готовых стать Кишином, и 1 душу ведьмы, а потому все повелители активно соревнуются в создании" +
            " Косы Смерти. Ну что, вы готовы окунуться в мир приключений?", MangaType.Manga, MangaStatus.Completed, "Боевик,Драма,Комедия,Приключения,Психология,Сверхъестественное,Сёнэн,Фэнтези,Этти,Зомби,Демоны,Магия,Боги,Бои на мечах,Борьба за власть,Волшебные существа,ГГ женщина,ГГ мужчина,Дружба,Жестокий мир,Злые духи,Магическая академия,Навыки / способности,Волшебники / маги",
            "https://mangalib.org/soul_eater?section=info", "https://www.mangaread.org/manga/soul-eater/", "souleater", "OHKUBO Atsushi", AgeLimitType.Age16, 2003);
            Manga yuukokunomoriarty = new Manga("Патриотизм Мориарти", "Конец позапрошлого века, Британская империя правит миром, и в основе всего лежит классовая система. И тут внезапно появляется Уильям Джеймс Мориарти — молодой человек, желающий уничтожить зло, проистекающее из классовой дискриминации, и создать идеальную страну."
                , MangaType.Manga, MangaStatus.Completed, "Детектив,Драма,История,Психология,Сёнэн,Триллер,Фантастика,Антигерой,Преступники / Криминал,ГГ мужчина,Жестокий мир,Империи,Насилие / жестокость,Огнестрельное оружие,Скрытие личности,Умный ГГ",
                "https://mangalib.me/yuukoku-no-moriarty?section=info&ui=4199976", "https://www.mangago.me/read-manga/yuukoku_no_moriarty/", "yuukokunomoriarty", "Ryousuke Takeuchi", AgeLimitType.Age16, 2016);
            Manga shinseikievangelion = new Manga("Евангелион", "История происходит через 15 лет после событий «Второго удара», в результате которого погибло миллиарды людей на всей планете, люди находились на грани выживания. Но тех, кто уцелел, ожидали испытания куда страшнее… Земля подвергается нападению огромных неведомых существ, именуемых – «Ангелами», которые появились непонятно откуда. Единственным оружием планеты, способным их остановить, являются человекоподобные роботы – \"Евангелионы\", разработанные с помощью новых технологий. Однако, вступать в бой при помощи этих гигантов, могут лишь 14-летние дети, которые способны целиком «подстроить» себя под машину и манипулировать \"Евангелионом\", подобно своему телу. Эти необыкновенные дети живут и обучаются в городе Токио-3, в штабе \"NERV\" – организации, которая возглавляет оборону Планеты от нападения. У пилотов Рей, Аски и Синдзи крайне сложно складываются отношения. От них зависит судьба человечества и только они способны найти ответ на вопрос: кто такие «Ангелы».",
                MangaType.Manga, MangaStatus.Completed, "Боевик,Драма,Меха,Научная фантастика,Психология,Сёнэн,Трагедия,Безумие,Ангелы,Апокалипсис,Будущее,ГГ мужчина,Жестокий мир,Навыки / способности,Насилие / жестокость,Роботы,Спасение мира,Философия,Япония",
                "https://mangahub.ru/title/neon_genesis_evangelion_1994", "https://www.mangago.me/read-manga/neon_genesis_evangelion/", @"shinseikievangelion", "Yoshiyuki Sadamoto", AgeLimitType.Age18, 1995);
            Manga chainsawman = new Manga("Человек-бензопила", "«Я всегда мечтал жить обычной жизнью: спать в тёплой постели, есть тосты с джемом по утрам, ходить на свидания со своей девушкой и улыбаться каждый день. Но всё изменилось со смертью отца — теперь, Потита, пора убивать!» — с такими словами Дэндзи вместе со своим псом-бензопилой Потитой отправляется на очередной контракт, ведь они — охотники на демонов. Каждый день они убивают ради денег, которые Дэндзи должен отдать одному якудза, иначе долг покойного отца придётся отдать собственной жизнью. Но что ждёт Дэндзи, когда он вернёт весь долг: заживёт обычной жизнью или продолжит спасать мир от демонов? А может, у судьбы свои планы на участь героя?",
                MangaType.Manga, MangaStatus.Completed, "Боевик,Комедия,Романтика,Сверхъестественное,Сёнэн,Трагедия,Ужасы,Фэнтези,Зомби,Антигерой,Монстры,ГГ мужчина,Дружба,Жестокий мир,Насилие / жестокость,Огнестрельное оружие,Скрытие личности",
                "https://mangalib.me/chainsaw-man?section=info&ui=4199976", "https://www.mangaread.org/manga/chainsaw-man/", "chainsawman", "Tatsuki Fujimoto", AgeLimitType.Age18, 2018);
            Manga theirstory = new Manga("Их история", "Вы когда-нибудь влюблялись в того, кто стоял на автобусной остановке, такого чудесного... и милого?.. С той самой остановки и началась эта чудесная, интересная и очень романтичная история о двух девушках, их друзьях, их одноклассниках и об их школе...",
                MangaType.Manhua, MangaStatus.Ongoing, "Сёдзё-ай,Повседневность,Комедия,Романтика,Школа,ГГ женщина,Дружба", "https://readmanga.live/ih_istoriia", "https://www.mangago.me/read-manga/tamen_di_gushi/", "theirstory", "Tan Jiu", AgeLimitType.NoAgeLimit, 2014);
            Manga omniscientrader = new Manga("Всеведущий читатель", "«Я знаю то, что сейчас будет». В тот момент, когда он подумал об этом, мир был уже разрушен, и вдруг открылась новая вселенная. Новая жизнь обычного читателя начинается в мире романа... романа, который смог прочесть лишь он.", MangaType.Manhwa, MangaStatus.Ongoing,
                "Боевик,Боевые искусства,Постапокалиптика,Приключения,Сверхъестественное,Сэйнэн,Триллер,Фантастика,Фэнтези,Исекай,Реинкарнация,Демоны,Зверолюди,Призраки / Духи,Монстры,Выживание,Путешествие во времени,Боги,Ангелы,Апокалипсис,Артефакты,Бои на мечах,Владыка демонов,Волшебные существа,ГГ мужчина,Драконы,Дружба,Жестокий мир,Злые духи,Игровые элементы,Квесты,Легендарное оружие,Навыки / способности,Насилие / жестокость,Подземелья,Разумные расы,Система,Скрытие личности,Спасение мира,Холодное оружие,Шантаж,ГГ имба,Умный ГГ,Потеря памяти",
                "https://mangalib.me/jeonjijeog-dogja-sijeom_?section=info&ui=4199976", "https://www.mangaread.org/manga/omniscient-readers-viewpoint/", "omniscientrader", "Sing-Shong", AgeLimitType.Age16, 2020);
            MangaCatalog.Add(souleaterManga);
            MangaCatalog.Add(yuukokunomoriarty);
            MangaCatalog.Add(shinseikievangelion);
            MangaCatalog.Add(chainsawman);
            MangaCatalog.Add(theirstory);
            MangaCatalog.Add(omniscientrader);
            SaveChanges();
        }
    }
}
