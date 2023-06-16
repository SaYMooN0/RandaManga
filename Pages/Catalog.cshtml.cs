using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RandaManga.Models;

namespace RandaManga.Pages
{
    public class CatalogModel : PageModel
    {
        public ApplicationContext context;
        internal List<Manga> allMangaList { get; set; } = new();
        internal List<Manga> mangaListToShow { get; set; } = new();
        internal List<string> allTags { get; set; } = new() { };
        internal string[] SelectedTags { get; set; }={ };
        public Filters Filters { get; set; }= new();    
        public CatalogModel(ApplicationContext db)
        {
            this.context = db;
        }
        public void OnGet()
        {
            fillContent();
            mangaListToShow = allMangaList.ToList();
        }
        public void OnPostFiltersApplied(Filters filters)
        {
            this.Filters = filters;
            fillContent();
            FormListToShow();
        }
        public void OnPostTagApplied(string[] selectedTags)
        {
            fillContent();
            this.SelectedTags = selectedTags;
            FormListToShow();

        }
        public void fillContent()
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
            allMangaList = context.MangaCatalog.AsNoTracking().ToList();
            if (allMangaList.Count < 4)
            {
                context.MangaCatalog.Add(souleaterManga);
                context.MangaCatalog.Add(yuukokunomoriarty);
                context.MangaCatalog.Add(shinseikievangelion);
                context.MangaCatalog.Add(chainsawman);
                context.SaveChanges();
                allMangaList = context.MangaCatalog.AsNoTracking().ToList();
            }
            foreach (var item in allMangaList)
            {
                foreach (string tag in item.Tags)
                {
                    if (!allTags.Contains(tag))
                        allTags.Add(tag);
                }
            }
            allTags.Sort();
        }
        private void FormListToShow()
        {
            int coincidences = 0;
            foreach (Manga manga in allMangaList)
            {
                coincidences = 0;
                foreach(string t in manga.Tags)
                {
                    if(SelectedTags.Contains(t))
                        coincidences++;
                }
                if (coincidences == SelectedTags.Length)
                    if(Filters.CheckByReleaseYear(manga.ReleaseYear)&&
                        Filters.CheckByAgeRaiting(manga.AgeLimit))
                        mangaListToShow.Add(manga);
            }
        }
    }
}
